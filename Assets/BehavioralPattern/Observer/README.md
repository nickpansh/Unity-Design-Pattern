# 观察者模式

> **观察者模式**定义了对象之间的一种一对多的依赖关系，使的每当一个对象状态发生改变时，其相关依赖对象都得到通知并被更新。

观察者模式如此有用以至于C#中直接将观察者模式集成在了语言层面（event关键字）

所以观察者模式的例子我就不讨论观察者模式的具体实现了。

取而代之的，这个例子关注Unity的各种事件如何实现。

## 内容

通过几种不同的使用方式实现了发布-订阅。
分别是：
- C#语言支持的：
	- 使用delegate
	- 使用EventHandler
	- 使用Action
- Unity封装的：
	- UnityAction
	- UnityEvent

其中纯C#写法，推荐用Action。
而UnityAction和Action相比没什么大的区别

```c#
public delegate void Action<in T1,in T2>(T1 arg1, T2 arg2);
```

```c#
public delegate void UnityAction<T0, T1>(T0 arg0, T1 arg1);
```

在性能上UnityAction慢一丢丢，但UnityAction可以和编辑器一起配合使用。
ref:[Event Performance: C# vs. UnityEvent](https://jacksondunstan.com/articles/3335)

而UnityEvent是封装了一层的，本质上是一个类。

## 其他设计模式

[专题 | Unity3D游戏开发中的设计模式 | 问渠 (wenqu.site)](https://wenqu.site/Unity-Design-Pattern.html)