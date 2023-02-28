# 迭代器模式

![迭代器](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/02/14/%E8%BF%AD%E4%BB%A3%E5%99%A8.png)

> **迭代器模式**：提供一种方法顺序访问一个聚合对象中的各个元素，且不暴露该对象的内部表示。

<!-- more -->



## Unity3D中的迭代器

**迭代器模式在Unity游戏开发中用的非常非常多！**

.NET框架提供了IEnumerable和IEnumerator接口（写法比GOF的原始版迭代器模式更简洁）

**划重点：一个collection要支持Foreach进行遍历，就必须实现IEnumerable,并以某种方式返回迭代器对象:IEnumerator。**



#### Array/ArrayList与迭代器

平常用的最多的Array,ArrayList等就使用了迭代器模式。

- 声明IEnumerable接口（Array—IList—ICollection—IEnumerable）
- 实现IEnumerator

```c#
public abstract class Array : ICloneable, IList, IStructuralComparable, IStructuralEquatable     
    // GetEnumerator returns an IEnumerator over this Array.  
    // 
    // Currently, only one dimensional arrays are supported.
    // 
    public IEnumerator GetEnumerator()
    {
        int lowerBound = GetLowerBound(0);
        if (Rank == 1 && lowerBound == 0)
            return new SZArrayEnumerator(this);
        else
            return new ArrayEnumerator(this, lowerBound, Length);
    }
}
```



Tips：

对于IEnumerable和IEnumerator，FCL提供了泛型和非泛型两大类型。因为非泛型装箱两大问题：和拆箱带来的性能开销问题，所以和泛型集合相比，已经变得越来越鸡肋。两大问题：
- 缺乏类型安全性。它返回object类型的引用，然后必须转化为实际类型

- 不希望的装箱操作。


![两种版本](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/01/16/20230116171801.png) 

#### Transform与迭代器

Unity的Transform也使用了迭代器模式。

```c#
public partial class Transform : Component, IEnumerable
{
     //*undocumented* Documented separately
    public IEnumerator GetEnumerator()
    {
        return new Transform.Enumerator(this);
    }

    //Comment by NickPansh:这里Unity用内部类的方式实现IEnumerator，这也是一个聚合关系的常规做法。
    private class Enumerator : IEnumerator
    {
        Transform outer;
        int currentIndex = -1;

        internal Enumerator(Transform outer)
        {
            this.outer = outer;
        }

        //*undocumented*
        public object Current
        {
            get { return outer.GetChild(currentIndex); }
        }

        //*undocumented*
        public bool MoveNext()
        {
            int childCount = outer.childCount;
            return ++currentIndex < childCount;
        }

        //*undocumented*
        public void Reset() { currentIndex = -1; }
    }
}
```



**协程（Coroutine）与迭代器**

Unity的协程也用了迭代器模式。

MonoBehaviour.cs

```
public class MonoBehaviour : Behaviour{
 	// Starts a coroutine.
    public Coroutine StartCoroutine(IEnumerator routine)
    {
        if (routine == null)
            throw new NullReferenceException("routine is null");

        if (!IsObjectMonoBehaviour(this))
            throw new ArgumentException("Coroutines can only be stopped on a MonoBehaviour");

        return StartCoroutineManaged2(routine);
    }
	// Stop a coroutine.
    public void StopCoroutine(IEnumerator routine)
    {
        if (routine == null)
            throw new NullReferenceException("routine is null");

        if (!IsObjectMonoBehaviour(this))
            throw new ArgumentException("Coroutines can only be stopped on a MonoBehaviour");

        StopCoroutineFromEnumeratorManaged(routine);
    }
    extern Coroutine StartCoroutineManaged2(IEnumerator enumerator);
    extern Coroutine StartCoroutineManaged(string methodName, object value);
}
```

Coroutines.cs

```c#
internal class SetupCoroutine
{
    [RequiredByNativeCode]
    [System.Security.SecuritySafeCritical]
    unsafe static public void InvokeMoveNext(IEnumerator enumerator, IntPtr returnValueAddress)
    {
        if (returnValueAddress == IntPtr.Zero)
            throw new ArgumentException("Return value address cannot be 0.", "returnValueAddress");
        (*(bool*)returnValueAddress) = enumerator.MoveNext();
    }

    [RequiredByNativeCode]
    static public object InvokeMember(object behaviour, string name, object variable)
    {
        // We need these stubs because methods marked with [RequiredByNativeCode] must match between scripting backends
        object[] args = null;
        if (variable != null)
        {
            args = new System.Object[1];
            args[0] = variable;
        }
        return behaviour.GetType().InvokeMember(name, BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, behaviour, args, null, null, null);
    }

    static public object InvokeStatic(Type klass, string name, object variable)
    {
        object[] args = null;
        if (variable != null)
        {
            args = new System.Object[1];
            args[0] = variable;
        }
        return klass.InvokeMember(name, BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public, null, null, args, null, null, null);
    }
}
```

由于只是C#端的部分代码，看不全，这里做个解释。

协程的实现分为两部分：

- 协程本体（仅仅是一个能够中间暂停的函数，Unity直接使用了.NET框架的IEnumerator，它可以使用`yield`来暂停，使用`MoveNext()`来继续执行）
- 协程调度（由MonoBehaviour的声明周期调用实现）

Tips：

- Unity原生协程使用普通版本的IEnumerator，但是有些项目（比如倩女幽魂）自己造的协程轮子可能会使用泛型版本的IEnumerator<T>
- 函数调用的本质是压栈，协程的唤醒也一样，调用IEnumerator.MoveNext()时会把协程方法体压入当前的函数调用栈中执行，运行到yield return后再弹栈。Unity中的协程是无栈协程，它不会维护整个函数调用栈，仅仅是保存一个栈帧。

ref:[Unity协程的原理与应用 - 知乎 (zhihu.com)](https://zhuanlan.zhihu.com/p/279383752)



## 结构

这里我直接画.Net框架里的迭代器UML图，以Transform为例。



![迭代器csharp.drawio](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/02/14/%E8%BF%AD%E4%BB%A3%E5%99%A8csharp.drawio.png)

## 动手实现

实际开发中，很少自定义迭代器，一般使用.NET内置的迭代器。

所以就不演示自定义迭代器了。

演示一下用IEnumerator进行遍历。

```c#
var arrList = new ArrayList();
arrList.Add("a");
arrList.Add("b");
arrList.Add("c");
arrList.Add("d");
arrList.Add("e");
arrList.Add("f");
arrList.Add("g");
// foreach (var item in arrList)
// {
//     Debug.Log(item);
// }

// 效果等同于foreach
IEnumerator i = (IEnumerator)arrList.GetEnumerator();
while (i.MoveNext())
{
    Debug.Log(i.Current);
}
```

演示一下不依靠协程，依靠Enumerator代码块实现方法迭代。

```c#
// 演示不依靠协程，也可以使用IEnumerator代码块创建可枚举方法
IEnumerator<int> SumAdd()
{
    int sum = 0;
    while (true)
    {
        yield return sum++;
    }
}
void Update()
{
    if (Input.anyKeyDown)
    {

        _enumerator.MoveNext();
        Debug.Log(_enumerator.Current);
    }
}
```



## 文章

Github无法显示外链，查看[Unity3D游戏开发设计模式——迭代器模式](https://www.wenqu.site/Unity%E8%AE%BE%E8%AE%A1%E6%A8%A1%E5%BC%8F%E2%80%94%E8%BF%AD%E4%BB%A3%E5%99%A8%E6%A8%A1%E5%BC%8F.html)以了解更多。


## 其他设计模式

[专题 | Unity3D游戏开发中的设计模式 | 问渠 (wenqu.site)](https://wenqu.site/Unity-Design-Pattern.html)