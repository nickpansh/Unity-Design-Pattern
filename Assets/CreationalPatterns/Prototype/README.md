# Unity设计模式——原型模式

![](https://pic.wenqu.space/other/design-pattern/prototype.png)

## Brief

> 原型模式是一种创造性模式，它通过复制一个已有对象来获取更多相同或者相似地对象。原型模式可以提高相同类型对象的创造效率，简化创建流程。

具体不展开，本篇主旨是在Unity中实现与演示命令模式，有关原型模式的详细介绍可以看:

[Refactoring.Guru]([原型设计模式 (refactoringguru.cn)](https://refactoringguru.cn/design-patterns/prototype))



## Let's see the source code

原型模式应用很广，以至于

- 在.Net框架中，就提供了[Object.MemberwiseClone()]([Object.MemberwiseClone 方法 (System) | Microsoft Learn](https://learn.microsoft.com/zh-cn/dotnet/api/system.object.memberwiseclone?view=net-7.0#system-object-memberwiseclone)) 方法可用于实现浅克隆。

  ```c#
  Person other = (Person) this.MemberwiseClone();
  ```

- 在.Net框架中中，还提供了[ICloneable()]([ICloneable 接口 (System) | Microsoft Learn](https://learn.microsoft.com/zh-cn/dotnet/api/system.icloneable?view=net-7.0))接口可用于实现深克隆。

  ```c#
  Person other = (Person) this.Clone();// notice：要先实现ICloneable接口（）
  ```

  ```c#
  ===========================================================*/
  namespace System {
    
    using System;
    // Defines an interface indicating that an object may be cloned.  Only objects 
    // that implement ICloneable may be cloned. The interface defines a single 
    // method which is called to create a clone of the object.   Object defines a method
    // MemberwiseClone to support default clone operations.
    // 
    [System.Runtime.InteropServices.ComVisible(true)]
    public interface ICloneable
    {
        // Interface does not need to be marked with the serializable attribute
        // Make a new object which is a copy of the object instanced.  This object may be either
        // deep copy or a shallow copy depending on the implementation of clone.  The default
        // Object support for clone does a shallow copy.
        // 
        Object Clone();
    }
  }
  ```

  所以你没必要像一些其他语言一样再去实现一个ICloneable接口。

  看看UnityCSReference里怎么使用它：

  ```c#
      public abstract class PlayableBehaviour : IPlayableBehaviour, ICloneable
    {
        // 省略.....
  
        public virtual object Clone()
        {
            return MemberwiseClone();
        }
    }
  ```

此外，如果你有用过Unity，你应该能想到这个API：[Object.Instantiate](https://docs.unity3d.com/cn/2021.3/ScriptReference/Object.html)

```c#
public static Object Instantiate (Object original);
```

喏，这不就是原型模式的应用吗？接收Object original返回一个克隆的Object。

很可惜这一部分代码在C++端（毕竟Unity的对象主要就是C++对象）没法直接看，不过幸运的是在[[Unity设计模式与游戏开发\]原型模式 | Aladdin的博客 (dingxiaowei.cn)](http://dingxiaowei.cn/2017/05/15/)中找到了对应的代码。

![](http://dingxiaowei.cn/2017/05/15/4.png)



## 原型模式优缺点

### 优点

-  你可以克隆对象， 而无需与它们所属的具体类相耦合。
-  你可以克隆预生成原型， 避免反复运行初始化代码。
-  你可以更方便地生成复杂对象。
-  你可以用继承以外的方式来处理复杂对象的不同配置。

### 缺点

- 克隆包含循环引用的复杂对象可能会非常麻烦。（若对象之间存在多重的嵌套引用，为了实现深克隆，每一层对象的类都必须支持深克隆）

### Code

代码演示了如何使用ICloneable实现深复制，如何使用MemberwiseClone实现浅复制。
以及引用传递和值传递的区别。

特别注意的是：
对于对象语句类型是基本数据类型的成员变量，浅拷贝会直接进行值传递，也就是将该属性值直接复制一份给新对象。
对于数据类型是引用类型的成员变量，那么浅拷贝会进行引用传递。

![](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/01/31/20230131184358.png)

## 其他设计模式

[专题 | Unity3D中的设计模式 | 问渠 (wenqu.site)](https://wenqu.site/Unity-Design-Pattern.html)