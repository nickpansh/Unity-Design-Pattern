# 服务定位器模式



## 概要

> 为某服务提供一个全局访问入口来避免使用者与该服务具体实现类耦合

游戏编程中，某些对象或者系统几乎出现在程序的每个角落。如音频，UI管理等。

直接引用对象肯定最差，用单例也不好，更合适的方案是引入服务定位器。

它使用起来像一个更灵活，更可配置的单例模式。


## 类结构

一个**服务类**为一系列操作定义了一个抽象的接口。

若干个具体**服务提供器**实现这个接口。

一个单独的**服务定位器**通过查找合适的提供器来提供这个服务的访问。



## 实现

[jarjin/LuaFramework_UGUI](https://github.com/jarjin/LuaFramework_UGUI)的Facade就是用了服务定位器模式。

我在它的基础上结合《游戏编程模式》的服务定位模式设计了新的服务定位器，**引入了空对象服务**，让整个系统更易于使用。



Locator.cs

```c#
// 服务定位器
public class Locator
{
    private static Dictionary<string, IManager> _managers = new Dictionary<string, IManager>();
    private static Dictionary<string, IManager> _nullManageCache = new Dictionary<string, IManager>()
    {
        {typeof(AudioManager).Name, new NullAudioManager() },
        {typeof(NetworkManager).Name, new NullNetworkManager() },
    };

    static Locator()
    {

    }
    /// <summary>
    /// 获得管理器
    /// </summary>
    /// <typeparam name="T">IManager</typeparam>
    /// <returns></returns>
    public static T GetManager<T>() where T : class, IManager
    {
        string mgrName = typeof(T).Name;
        // 若字典中没有对应的管理器，则返回对应的空管理器
        if (!_managers.ContainsKey(mgrName))
        {

            if (_nullManageCache.TryGetValue(mgrName, out IManager nullMgr))
            {
                return nullMgr as T;
            }
            else
            {
                return default(T);
            }
        }
        return (T)_managers[mgrName];
    }
    /// <summary>
    /// 添加管理器
    /// </summary>
    /// <typeparam name="T">IManager</typeparam>
    /// <param name="mgr">instance of T</param>
    /// <returns></returns>
    public static T AddManager<T>(T mgr) where T : class, IManager
    {
        string mgrName = typeof(T).Name;
        if (_managers.ContainsKey(mgrName))
        {
            _managers[mgrName] = mgr;
        }
        else
        {
            _managers.Add(mgrName, mgr);
        }
        return mgr;
    }

    public static void RemoveManager<T>() where T : class, IManager
    {
        string mgrName = typeof(T).Name;
        if (_managers.ContainsKey(mgrName))
        {
            _managers.Remove(mgrName);
        }
    }
}
```

```c#
public  class AudioManager : IManager
{
    public virtual void PlaySound(string soundName)
    {
        Debug.Log("PlaySound:" + soundName);
    }
}

// 空管理器
// q:为什么它继承自AudioManager而不是声明IAudioManager后NullAudioManager和AudioManager都实现IAudioManager呢？
// a:希望Locator在AddManager<T>()时，传的是AudioManager而不是IAudioManager,所以NullAudioManager必须继承自AudioManager
// 否则 return nullMgr as T;会返回空。比起空Manager持有变量占用内存的缺点而言，更看重Locator调用时方便易懂。
public class NullAudioManager : AudioManager
{
    public override void PlaySound(string soundName)
    {
        // Do nothing
        Debug.Log("Do nothing:");
    }
}
```

调用代码：

```c#
// 注册服务
// Register the service
AudioManager audioMgr = new AudioManager();
Locator.AddManager<AudioManager>(audioMgr);
NetworkManager networkMgr = new NetworkManager();
Locator.AddManager<NetworkManager>(networkMgr);

// 调用管理器
Locator.GetManager<AudioManager>().PlaySound("Sound1");

// 移除管理器
Locator.RemoveManager<NetworkManager>();
```

## 我见

服务定位器模式比单例模式要好得多，它比起单例模式好拓展的多。

- 我们可以通过装饰器模式来装饰一个原有的服务，来轻易地拓展原有的服务。

- 现在我们也不用担心单例的一些初始化步骤在哪里进行—只要用空对象模式即可。
- 我们可以在运行时更换服务。

## 其他设计模式

[专题 | Unity3D游戏开发中的设计模式 | 问渠 (wenqu.site)](https://wenqu.site/Unity-Design-Pattern.html)