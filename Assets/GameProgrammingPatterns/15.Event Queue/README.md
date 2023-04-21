
# Unity设计模式—命令队列

> 命令队列是一个按照FIFO顺序存储一系列通知或请求的队列。发出通知时系统会将请求置入队列并立即返回，请求处理器随后从命令队列中获取并处理这些请求。请求可由处理器直接处理或转发给对其感兴趣的模块。

**命令队列模式对消息的发送者和受理者进行了解耦，是消息的处理变得动态且非实时。**

*原书这一章叫做EventQueue事件队列。当入队的时命令时，也就是命令队列。命令队列用的比较多。故本文直接写命令队列*

### 需求&差代码

你在开发一个窗口管理器WindowManager。

任务的基本逻辑很简单，需要提供一个Push方法，使用者调用的时候弹出一个窗口。

并且要求弹出窗口的时候隐藏底部的窗口。

三下五除二你就开发好了代码。

```c#
public void PushWindow(UIBase view){
    foreach(var view in views){
        view.SetActive(False)
    }
    view.SetActive(True);
    views.Add(view);
}
```

测试报过来一系列bug：

1. 如果已经有一个系统窗口置于最顶层，就不应该弹出一个普通窗口盖住系统窗口，无论调用时机的先后顺序。
2. 被隐藏的界面的倒计时状态错误了，隐藏期间没有倒计时不会走

为了解决第一个问题，你决定在PushWindow里加入IsSystemWindow的检查，如果已经有系统窗口在最顶层，则把这个窗口插在系统窗口之下。

第二个问题你决定在界面弹出的时候再调用UpdateView，重新获取倒计时。

代码大致是这样的，这里以lua举例，确实是之前项目中经历数次迭代产生的代码……

```lua
local function PushWindow(view)
    local findIndex = 0
    for i = 1, #self.windows do
        if self.windows[i]:GetIsSystemWindow() then
            findIndex = i
        end
    end
    if #self.windows > 0 and view:GetIsSystemWindow() and findIndex > 0 then
        ---当前新入栈系统窗体，并且栈里面有其他系统窗体的时候，不能直接覆盖还在显示的系统窗体
        if self.windows[#self.windows].SetActive then
            self.windows[#self.windows]:SetActive(true)
        end
        if view.SetActive then
            view:SetActive(false)
        end
        table.insert(self.windows, findIndex, view)
    else
        if view.SetActive then
            view:SetActive(true)
            view:UpdateView()
        end
        table.insert(self.windows, view)
    end
    
local function PopWindow()
    if #self.windows > 0 then
        local topWindow = self.windows[#self.windows]
        topWindow.SetActive(True)
        topWindow.UpdateView()
```

到这里代码已经很难看了，PopWindow还要负责刷新底下的界面。

这样若能解决问题倒也罢了……结果是新问题又来了：

测试反馈有一些窗口会在调用UpdateView后发现倒计时已经结束，又触发关闭，策划看了很不满意。

![](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/bucket/202304210934129.jpeg)

于是你准备把SetActive放在UpdateView的回调里……

代码变成了这样

```lua
local function PushWindow(view)
    local findIndex = 0
    for i = 1, #self.windows do
        if self.windows[i]:GetIsSystemWindow() then
            findIndex = i
        end
    end
    if #self.windows > 0 and view:GetIsSystemWindow() and findIndex > 0 then
        ---当前新入栈系统窗体，并且栈里面有其他系统窗体的时候，不能直接覆盖还在显示的系统窗体
        if self.windows[#self.windows].SetActive then
            self.windows[#self.windows]:SetActive(true)
        end
        if view.SetActive then
            view:SetActive(false)
        end
        table.insert(self.windows, findIndex, view)
    else
        if view.SetActive then
            view:SetActive(true)
            view:UpdateView()
        end
        table.insert(self.windows, view)
    end
    
local function PopWindow()
    if #self.windows > 0 then
        local topWindow = self.windows[#self.windows]
        topWindow.UpdateView(function() topWindow.SetActive(True) end)
```

但你的领导也没有表扬你，他提了一个灵魂拷问：

底下的界面既然不需要显示，为什么要加载它再销毁它，嫌手机电量太多加载者玩是吧？



怎么办，很自然就想到了命令队列。

之所以上面的代码会那么难维护，就是**消息的发送者与受理者没有解耦**，每个消息(PushWindow)发出，受理者（WindowManager）都立即处理。

而如果我们引入命令队列，将每个PushWindow的消息视作存进一个命令队列，然后再在合适的时机执行队列的Dequeue，就能解决这个问题。

这个就是命令队列的原理。



### 引入命令队列实现

在本例中还实现了几个另外的功能

1. 在部分场景中（如战斗），推送消息不弹出，直接舍弃
2. 引入优先级，高优先级界面直接弹出并隐藏底下的界面，低优先级界面进入队列。

WindowManager类：

```c#
/// <summary>
/// 窗口管理器
/// </summary>
public class WindowManager : UIManager
{
    /// <summary>
    /// 界面所处的UILayer层级
    /// </summary>
    public override UILayer layer => UILayer.Window;

    // 界面命令队列
    private PriorityQueue<WindowCommand, int> _cmdQueue = new PriorityQueue<WindowCommand, int>();

    // UI栈
    public Stack<WindowBase> _uiStack = new Stack<WindowBase>();

    // 标准优先级，低于该优先级的界面不显示
    private int _horizonLinePriority = (int)PriorityStandardOffset.BothActiveAndPassive;

    private void Start()
    {
        Debug.Log("WindowManager Start");
        WindowCommand.parentTrf = this.transform;
    }

    /// <summary>
    /// 设置标准优先级，低于该值的命令将会被丢弃
    /// </summary>
    /// <param name="priority"></param>
    public void SetHorizonLinePriority(PriorityStandardOffset priority)
    {
        _horizonLinePriority = (int)priority;
    }

    /// <summary>
    /// 入栈界面
    /// </summary>
    /// <param name="uiTypeInfo">界面类型</param>
    /// <param name="windowPriority">界面优先级</param>
    /// <param name="timeout">超时时间</param>
    /// <param name="args">参数</param>
    public void Push(UITypeInfo uiTypeInfo, WindowPriority windowPriority = WindowPriority.ActiveWindow, float timeout = -1, params object[] args)
    {
        int priority = (int)windowPriority;
        // 优先级小于水平优先级，则直接丢弃
        if (priority < _horizonLinePriority)
        {
            return;
        }

        // 创建窗口命令
        var cmd = new WindowCommand(uiTypeInfo, priority, (WindowBase ui) =>
        {
            this._uiStack.Push(ui);
            ui.OnEnter();
        }, timeout, args);

        // 加入界面命令队列中
        _cmdQueue.Enqueue(cmd, priority);
        TryDequeue();
    }

    /// <summary>
    /// 出栈界面
    /// </summary>
    public void Pop()
    {
        if (_uiStack.Count > 0)
        {
            var ui = _uiStack.Pop();
            ui.OnExit();
            ui.Destroy();
        }
        TryDequeue();
    }

    // 尝试出队执行命令
    private void TryDequeue()
    {
        // 检查超时命令
        DequeueTimeoutCommands();
        // 比对优先级
        int topUIPriority = _uiStack.Count > 0 ? _uiStack.Peek().priority : -1;
        int topCmdPriority = _cmdQueue.Count > 0 ? _cmdQueue.Peek().priority : -1;
        if (topCmdPriority >= topUIPriority) //若命令队列里有优先级更高的界面，则显示该界面
        {
            if (topCmdPriority == topUIPriority && _uiStack.Count > 0)
            {
                // 相同优先级需要先隐藏当前界面
                _uiStack.Peek().Pause();
            }
            if (_cmdQueue.Count > 0)
            {
                var cmd = _cmdQueue.Dequeue();
                cmd.Execute();
            }
        }

        else // 若命令队列里无优先级更高的界面，则显示底下的界面(若有)
        {
            if (_uiStack.Count > 0)
            {
                _uiStack.Peek().Resume();
            }
        }
    }

    // 检查超时命令并移除
    private void DequeueTimeoutCommands()
    {
        while (_cmdQueue.Count > 0)
        {
            var command = _cmdQueue.Peek();
            // 若已超时，移除该命令
            if (DateTime.Now > command.timeoutDate)
            {
                _cmdQueue.Dequeue();
            }
            else
            {
                break;
            }
        }
    }
}
```

WindowCommand类

```c#
/// <summary>
/// 执行窗口UI的命令。
/// </summary>
public class WindowCommand : AbstractExecCommand<WindowBase>
{
    /// <summary>
    /// 父节点Transform。
    /// </summary>
    public static Transform parentTrf;

    /// <summary>
    /// 超时时间。
    /// </summary>
    public DateTime timeoutDate;

    /// <summary>
    /// 优先级。
    /// </summary>
    public int priority;

    /// <summary>
    /// UI类型。
    /// </summary>
    private UITypeInfo _uiTypeInfo;

    /// <summary>
    /// 命令参数。
    /// </summary>
    private object[] _arguments;

    /// <summary>
    /// 构造函数。
    /// </summary>
    /// <param name="uiTypeInfo">UI类型。</param>
    /// <param name="priority">优先级。</param>
    /// <param name="onExecuted">执行完回调函数。</param>
    /// <param name="timeout">超时时间。</param>
    /// <param name="args">命令参数。</param>
    public WindowCommand(UITypeInfo uiTypeInfo, int priority, Action<WindowBase> onExecuted, float timeout = -1, params object[] args)
    {
        this._uiTypeInfo = uiTypeInfo;
        this._arguments = args;
        this.priority = priority;
        this.onExecuted = onExecuted;
        if (timeout > 0)
        {
            timeoutDate = DateTime.Now.AddSeconds(timeout);
        }
        else
        {
            timeoutDate = DateTime.MaxValue;
        }
    }

    /// <summary>
    /// 执行命令。
    /// </summary>
    public override void Execute()
    {
        // 加载Prefab，并实例化
        GameObject prefab = Resources.Load<GameObject>(_uiTypeInfo.prefabPath);
        GameObject windowGo = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity, parentTrf);

        // 创建Window并挂载到GameObject上
        WindowBase windowUI = (WindowBase)windowGo.AddComponent(_uiTypeInfo.scriptType);
        windowUI.priority = priority;
        // 初始化Window
        windowUI.Initialize(_arguments);
        onExecuted?.Invoke(windowUI);
    }
}
```



本例使用了优先队列来做命令缓冲区，是因为要实现优先级排序。

**若没有优先级排序需求，命令队列非常适合使用[环形队列 | 问渠 (wenqu.site)](https://www.wenqu.site/Unity数据结构-队列.html?highlight=环形队列)**

### 我见

命令队列的使用场景还有很多，如《游戏编程模式》中举的SoundManager的例子。

这里罗列几种适合使用命令队列的情况：

- 对请求的处理会阻塞调用者。

  如播放音频，播放特效等需要同步加载的方法，使用命令队列可以更好地控制加载。

- 处理者需要更灵活地受理调用者的请求。

  如音频并发的数量限制，若不解耦调用与受理，会导致并发超过临界值时随机的部分音效无法播放。

- 处理者需要批量地处理请求

  命令队列下处理者可以批量地处理请求，如利用多线程

- 我们想让处理者自定义何时执行命令，而非立即执行

总结：命令队列在接收消息与执行消息中定义了一个缓冲区，这个缓冲区解耦了命令的接收与受理，从而使得命令地处理变得动态且非实时。





## 其他设计模式

[专题 | Unity3D游戏开发中的设计模式 | 问渠 (wenqu.site)](https://wenqu.site/Unity-Design-Pattern.html)