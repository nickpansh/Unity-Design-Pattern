# Unity3D游戏开发中的设计模式



这个仓库是在Unity3D中实现设计模式的合集，使用C#编写。

- 包含GOF的23种设计模式
- 包含《游戏编程模式》的Unity实现

[Engligh](README-EN.md)



### 背景

设计模式的精妙之处在于它们是一组经过验证和实践的通用解决方案，可以帮助软件工程师提高代码的质量，并简化软件开发的复杂性。

但这些年关于设计模式的争议也不绝于耳。

最主要的原因是设计模式的概念提出距今有接近三十年了，随着现代软件工程的发展，情况有了些变化：

- 随着软件工程的发展，业务拆分更细了，框架与业务时常被完全拆开。设计模式对于框架开发更重要。

- 一些设计模式已经被语言或者是框架所集成。对于使用它们的开发者而言，使用这些语言支持会更方便。

- GOF提出设计模式时没有按照使用频率排序导致了部分误解的产生。

但不管是对于什么水平的程序员，什么类型的代码开发，只要我们追求代码的可复用性，我们就需要修炼好设计模式的内功。


我试图阐述**Unity3D游戏开发领域的设计模式**，包括：
- 按照我的理解对游戏开发中的设计模式进行**重要性排序**。
- 除了23种设计模式外，**引入《游戏编程模式》里的游戏设计模式**。
- 对于每一种设计模式，都提供**游戏开发中使用它的思路和例子**，聚焦游戏开发，目的是加深理解，避免泛泛而谈。
- 对于部分语言/框架：C#/.NET/Unity3D 框架里用得比较多的模式，关注框架里是怎么使用的。**通过[UnityCSReference](https://github.com/Unity-Technologies/UnityCsReference)里的源码来谈对设计模式的理解**。


### 适合谁看

- 对Unity游戏开发有一定了解，想**提升代码质量**的工程师。
- 对Unity游戏开发和设计模式都有一定了解，想**复习设计模式**的工程师。
- 对游戏开发感兴趣，并准备在此领域**深挖**的**初级程序员。
- 对Unity游戏开发完全不了解，但对设计模式感兴趣，想寻找模式**应用例子**的工程师。

### 不适合谁看

- 完全不了解Unity开发，也没听过设计模式的人。（建议分别学习Unity开发和设计模式）
- 觉得设计模式没有用，享受屎山的工程师。


### 目录

目前已经完成的例子有：

- **创建型模式**

  - **重要**

    - [x] **[建造者模式](./Assets/CreationalPatterns/BuilderPattern/README.md)**
    - [x] **[原型模式](./Assets/CreationalPatterns/Prototype/README.md)**
    - [x] **[工厂方法模式](./Assets/CreationalPatterns/FactoryMethod/README.md)**

  - 次要

    - [x] [抽象工厂模式](./Assets/CreationalPatterns/AbstractFactory/README.md)
    - [x] [单例模式](./Assets/CreationalPatterns/Singleton/README.md)

- **结构型模式**

  - **重要**

    - [x] **[代理模式](./Assets/StructuralPattern/Proxy/README.md)**
    - [x] **[组合模式](./Assets/StructuralPattern/CompositePattern/README.md)**
    - [x] **[装饰模式](./Assets/StructuralPattern/DecoratorPattern/README.md)**
    - [x] **[门面模式](./Assets/StructuralPattern/FacadePattern/README.md)**
    - [x] **[享元模式](./Assets/StructuralPattern/Flyweight/README.md)**
    
  - 次要
    - [x] [适配器模式](./Assets/StructuralPattern/AdapterPattern/README.md)
    - [x] [桥接模式](./Assets/StructuralPattern/BridgePattern/README.md)



**行为型模式**

- **重要**
  - [x] **[迭代器](./Assets/BehavioralPattern/Iterator/README.md)**
  - [x] **[观察者模式](./Assets/BehavioralPattern/Observer/README.md)**

- 次要

  - [x] [责任链模式](./Assets/BehavioralPattern/ChainOfResponsibility/READ.md)
- [] Command
- [] Mediator
- [] Memento
- [] State
- [] Strategy
- [] Template Method
- [] Visitor

**访问[专题 | Unity3D中的设计模式](https://www.wenqu.site/Unity-Design-Pattern.html)以查看更多**

### 致谢

本项目参考了以下项目的部分代码：
- [Habrador/Unity-Programming-Patterns](https://github.com/Habrador/Unity-Programming-Patterns)

- [QianMo/Unity-Design-Pattern](https://github.com/QianMo/Unity-Design-Pattern)

  向他们表示衷心的感谢！

  

### 参考资料与了解更多

- [Game Programming Patterns](http://gameprogrammingpatterns.com/)

- [Refactoring.Guru](https://refactoringguru.cn/)

- [C#设计模式（第2版） (豆瓣) (douban.com)](https://book.douban.com/subject/30131470/)

- [设计模式与游戏完美开发 (豆瓣) (douban.com)](https://book.douban.com/subject/26952185/)

- [Habrador/Unity-Programming-Patterns](https://github.com/Habrador/Unity-Programming-Patterns)

- [QianMo/Unity-Design-Pattern](https://github.com/QianMo/Unity-Design-Pattern)

- [UnityCSReference](https://github.com/Unity-Technologies/UnityCsReference)

- [.NET Framework](https://referencesource.microsoft.com/)

## License

本工程使用[MIT授权协议](https://opensource.org/licenses/MIT)。

参考了一些外部工程的源码，查看[License](./LICENSE)以获取全部的授权文本。