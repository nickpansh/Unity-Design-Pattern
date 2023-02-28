# Unity设计模式—桥接模式

## Brief | 概要

> 桥接模式是一种很实用的结构性设计模式，如果系统中某个类存在两个独立变化的维度，通过桥接模式可以将这两个维度分离出来，使两者可以独立扩展。

很多情况下，桥接模式可以取代多层继承，极大地减少了子类的数量

Unity的Logger模块就应用了桥接模式，我们来看看Unity引擎开发者是怎么做的吧！

## Let's see the source code | 看看源码


我们先来了解下背景：

Unity有一个Debug.Log方法，开发者可以通过调用它来输出日志。

现在思考一个问题：

Unity是不开源的（所以开发者不可能去修改源码。就算开源也不推荐直接改源码，记住设计模式有原则：对拓展开放，对修改关闭），如果你是Unity引擎的开发者，

你将如何组织你的代码，让开发者可以实现自定义Log—

这里有两个维度的变化：

1. Log到哪里（比如可以输出到编辑器，也可以输出到文件）
2. Log的格式（如可以选择是否打印堆栈）

---

原则：对扩展开放，对修改关闭

---

糟糕的实现方案是针对第一个变化我们先定义EditorLogger，FileLogger。

为了实现第二个变化，我们继续继承，这时候就有了四个Logger：

- EditorFullLogger 输出到编辑器，输出堆栈
- EditorShortLogger 输出到编辑器，不输出堆栈
- FileFullLogger 输出到文件，输出堆栈
- FileShortLogger 输出到文件，不输出堆栈

这样的实现类会很多，且不易于拓展。深入理解“分离独立变化的维度”，就是桥接模式的作用。

让我们看看Unity引擎是怎么设计的。我画了个UML类图用于说明Unity引擎的设计：



![UnityLogger.drawio](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/02/08/UnityLogger.drawio.svg)



稍微解释下原理：使用桥接模式，把第一个变化（Log到哪里）定义为ILogHandler，把第二个变化（Log的样式）定义为ILogger，再把抽象和实现分离，使用桥接模式把类组合在一起。游戏开发者可以自定义适配者来调用自己的Log，又不破坏整体结构。

摘录部分关键代码如下：

Debug.cs

```c#
public partial class Debug{
    internal static ILogger s_Logger = new Logger(new DebugLogHandler());
    public static ILogger unityLogger => s_Logger;
    public static void LogFormat(string format, params object[] args)
    {
        unityLogger.LogFormat(LogType.Log, format, args);
    }
}
```

Logger.cs

```c#
public class Logger : ILogger
{
    public Logger(ILogHandler logHandler)
    {
        this.logHandler = logHandler;
        this.logEnabled = true;
        this.filterLogType = LogType.Log;
    }
    public ILogHandler logHandler { get; set; }
}
```

ILogHandler.cs

```c#
public interface ILogHandler
{
    void LogFormat(LogType logType, Object context, string format, params object[] args);

    void LogException(Exception exception, Object context);
}
```

DebugLogHandler.cs

```c#
internal partial class DebugLogHandler : ILogHandler
{
    public void LogFormat(LogType logType, Object context, string format, params object[] args)
    {
        Internal_Log(logType, LogOption.None, string.Format(format, args), context);
    }

    public void LogFormat(LogType logType, LogOption logOptions, Object context, string format, params object[] args)
    {
        Internal_Log(logType, logOptions, string.Format(format, args), context);
    }

    public void LogException(Exception exception, Object context)
    {
        if (exception == null)
            throw new ArgumentNullException("exception");

        Internal_LogException(exception, context);
    }
}
```



这样一来，Unity引擎暴露了Debug.unityLogger.logHandler对象给外部。

ILogHandler关注Log到哪里（只有基础方法LogFormat和LogException），

ILogger关注Log的格式

游戏开发者可以切换自定义LogHandler适配器来实现对Log功能的修改而无需改动源代码。



先来看看这样的设计下，我们如何实现自定义Log从而实现输出到文件里而不输出到编辑器

Step1 实现自己的Implementor（LogHandler）:

```c#
using System;
using UnityEngine;

public class MyLogHandler : ILogHandler
{
    public void LogException(Exception exception, UnityEngine.Object context)
    {
        // 自定义的LogException方法，输出到文件
    }

    public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
    {
        // 自定义的Log方法，输出到文件
    }
}
```

Step2 修改Debug.unityLogger的logHandler对象。

```c#
Debug.unityLogger.logHandler = new MyLogHandler();
```

对拓展开放，对修改关闭，完美！

## Requirement | 需求

照例提出一个需求：
我的游戏里有一个Character基类，Npc和Elf都集成它。
这时候策划提出，有一些Npc是走路Npc，有一些NPC是飞行NPC，有一些Elf是走路Elf，有一些Elf是飞行Elf。
如何组织代码？

### Bad Code | 差代码

如果我们不用桥接模式，我们会使用多重集成——
NPC和Elf继承Character。
WalkNpc和FlyNpc继承NPC。
WalkElf和FlyElf继承Elf。

### Good Code Example | 好代码（使用桥接模式）

设计上，我们先分离独立的变化维度。
第一个维度是角色Character
第二个维度是移动的行为IMovable。
摘录部分关键代码：
```c#
public abstract class Character
{
    public IMovable movable { get; set; }
    public abstract void NavTo(Vector3 pos);
}
```

```c#
public class Elf : Character
{
    public override void NavTo(Vector3 pos)
    {
        Vector3[] paths = this.movable.CalcNavPath(pos);
    }
}
```

## When To Use | 什么时候用

- 如果你想要拆分或重组一个具有多重功能的庞杂类 （例如能与多个数据库服务器进行交互的类）， 可以使用桥接模式

- 如果你希望在几个**独立维度**上扩展一个类， 可使用该模式。

- 如果你需要在运行时切换不同实现方法， 可使用桥接模式。

## 桥接模式的优点

- 分离抽象接口及其实现部分。解耦了抽象和实现之间固有的绑定关系。
- 很多情况下，桥接模式可以取代多层继承，极大地减少了子类的数量（注意分辨独立变化的维度）
- 提高了可拓展性，在两个维度中任意拓展一个维度，不需要修改原有代码。
