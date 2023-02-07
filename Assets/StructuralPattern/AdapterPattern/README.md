## Brief | 概要

> **适配器模式**： 将一个类的接口转换成客户希望的另一个接口。适配器模式让那些接口不兼容的类可以一起工作。

适配器模式包括类适配器和对象适配器。

在对象适配器模式中，适配器与适配者是关联关系。

在类适配器模式中，适配器与适配者是继承关系。

适配器模式更多的是强调对代码的阻止，而不是功能的实现。

在实际开发中，对象适配器模式用的更多。

## Let's see the source code | 看看源码

Unity的Logger模块就应用了适配器模式。

我们先来看下背景：

Unity有一个Debug.Log方法，开发者可以通过调用它来输出日志。

这个代码的实现我截取了一部分是这样的：

```c#
public partial class Debug{
    internal static readonly ILogger s_DefaultLogger = new Logger(new DebugLogHandler());

    internal static ILogger s_Logger = new Logger(new DebugLogHandler());
    public static ILogger unityLogger => s_Logger;
    public static void LogFormat(string format, params object[] args)
    {
        unityLogger.LogFormat(LogType.Log, format, args);
    }
}

```

现在思考这个问题：

Unity是不开源的，如果你是Unity引擎的开发者，

你将如何组织你的代码，让开发者可以实现自定义Log——

比如标准的Log是输出到编辑器里的，我们想要修改代码让Log不输出到编辑器，而是输出到文件里。

---

记住原则：对扩展开放，对修改关闭（事实上你根本无法修改，因为没开源）

---

Unity引擎的开发者做了两件事：

1. 提供了一个事件Application.logMessageReceivedThreaded，当Log被执行后，这个事件会被触发。游戏开发者可以通过添加委托的形式实现对Log的一些自定义控制。但这没有实现如何“不输出到编辑器”，只是实现了“输出到编辑器以后可以做什么”
2. 使用对象适配器模式，游戏开发者可以自定义适配者来调用自己的Log，又不破坏整体结构。

![image-20230207112143746](https://wenqu.space/uploads/2023/02/07/image-20230207112143746.png)

游戏开发者可以切换自定义LogHandler适配器来实现对Log的修改。

实现自己的适配者类:

```c#
using System;
using UnityEngine;

public class MyLogHandler : ILogHandler
{
    public void LogException(Exception exception, UnityEngine.Object context)
    {
		// 自定义的LogException方法
    }

    public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
    {
        // 自定义的Log方法
    }
}
```

替换适配者：

```c#
Debug.unityLogger.logHandler = new LogHandler(true);
```

对拓展开放，对修改关闭，完美！



## When To Use | 什么时候用

- 适配器模式在 C# 代码中很常见。 基于一些遗留代码的系统常常会使用该模式。 在这种情况下， 适配器让遗留代码与现代的类得以相互合作。

- 购买了一些第三方类库或者插件，但是没有源码/是类库的命名规范和自己的很不一致/有很多怪异接口，这时候就可以用适配器模式包装一下，作为这些接口的转换器。

## Post | 文章

[wenqu.site](https://wenqu.site/Unity%E8%AE%BE%E8%AE%A1%E6%A8%A1%E5%BC%8F%E2%80%94%E5%BB%BA%E9%80%A0%E8%80%85%E6%A8%A1%E5%BC%8F.html)