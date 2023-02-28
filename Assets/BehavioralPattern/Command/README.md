## Brief | 概要

> 命令模式是回调函数的面向对象替代品。它将一个请求封装成一个对象，从而让你可以用不同的请求对客户进行参数化，对请求排队或者记录请求日志以支持可以撤销的操作。

![命令模式](.https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/design-pattern/命令模式.jpg)


更多细节可以查看[命令设计模式 (refactoringguru.cn)](https://refactoringguru.cn/design-patterns/command)

## 什么时候用

- 如果你需要通过操作来参数化对象， 可使用命令模式。
- 如果你想要将操作放入队列中、 操作的执行或者远程执行操作， 可使用命令模式。
- 如果你想要实现操作回滚功能， 可使用命令模式。

如:
- 制作Replay系统
- **建立撤销和重做系统**
- AI命令流
- 一组操作组合成**宏命令**

## 命令模式优缺点

### 优点

- 把请求发送者和请求接收者进行了解耦，发送者和接收者之间不交互。
- 可以方便的设计命令队列或组合命令。
- 为Undo和Redo提供了一种设计与实现。

### 缺点

- 具体命令类有点多，如果没有编辑器和语言的强力支持（如你是用Lua开发），引入命令模式维护成本比较高

## 结构
![](https://refactoringguru.cnhttps://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/patterns/diagrams/command/structure.png)

命令模式包含一个抽象命令类，具体命令类，调用者，和接收者这四个角色。


## Unity中实现

### 需求

玩家通过键盘操作对象。

- 按上箭头放大对象，按下箭头缩小对象
- 按左箭头向左旋转90度，按右箭头向右旋转90度
- WASD控制前左后右移动
- 回车回放
  **（先想一想如果不用设计模式，你的代码会怎么写）**

### 实现

抽象命令类Command.cs声明了Execute()和Undo():
```c#
// 命令模式抽象类
// 这个类应该一直保持这个结构，保持足够通用，不应该引入构造函数，变量
public abstract class Command
{
    public abstract void Execute();

    public abstract void Undo();
}
```

具体命令类继承Command类，会存在很多个具体命令类，这里举例LargerCommand.cs用于放大操作对象：

```c#
public class LargerCommand : AbstractCommand
{
    // 维持一个对操作对象的引用
    public Transform transform;
    public LargerCommand(Transform transform)
    {
        this.transform = transform;
    }
    public override void Execute()
    {
        this.transform.localScale = this.transform.localScale * 2;
    }

    public override void Undo()
    {
        this.transform.localScale = this.transform.localScale / 2;
    }
}
```

调用者通过命令来操作接受者，实现调用者和接受者的解耦：

```c#
// 命令的指针执行XX动作
// 这一句调用是命令模式的精髓——把调用方和接收者进行了解耦
// 如果不用命令模式，这里的代码应该是直接调用接收者的方法，调用方的代码将会很庞大
var cmd = HandleInput();
if (cmd != null)
{
    cmd.Execute();
}
```

以上是基础结构。

维护一个undo栈和一个redo栈即可实现回放:

```c#
Command nextCommand = redoCommands.Pop();
nextCommand.Execute();
// 插入undo栈
undoCommands.Push(nextCommand);
```

可以将多个命令组合成一个命令组，参见：CommandQueue.cs

```c#
public class CommandQueue : AbstractCommand
{
    private List<AbstractCommand> _commands = new List<AbstractCommand>();


    /// <summary>
    /// 添加命令到队列中
    /// </summary>
    /// <param name="command"></param>
    public void AddCommand(AbstractCommand command)
    {
        _commands.Add(command);
    }

    /// <summary>
    /// 从队列中移除命令
    /// </summary>
    /// <param name="command"></param>
    public void RmCommand(AbstractCommand command)
    {
        _commands.Remove(command);
    }
    /// <summary>
    /// 执行
    /// </summary>
    public override void Execute()
    {
        foreach (AbstractCommand cmd in _commands)
        {
            cmd.Execute();
        }
    }
    /// <summary>
    /// 撤销
    /// </summary>
    public override void Undo()
    {
        foreach (AbstractCommand cmd in _commands)
        {
            cmd.Undo();
        }
    }
}
```

### 其他设计模式

[专题 | Unity3D游戏开发中的设计模式 | 问渠 (wenqu.site)](https://wenqu.site/Unity-Design-Pattern.html)


