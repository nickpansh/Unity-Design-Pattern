# 在Unity3D中使用设计模式

[Engligh](README-EN.md)

这个仓库是在Unity3D中实现设计模式的合集，使用C#编写。

设计模式非常棒。许多的设计模式单单是看起来就很精妙，但对于部分人（起码对于初学时地我）而言，**最大的困扰是不知道为什么以及什么时候用这个设计模式**。

所以**我尝试用一个全新的形式来讲解设计模式**：

对于每一个设计模式，我都会先抛出一个问题：如果抛开所有的设计模式，你会如何实现某一个功能？

然后我会给出坏代码和使用了设计模式的好代码，来帮助读者来更好地理解设计模式。

我会尽可能让这个例子更贴近于实际应用。

建议配合一本参考资料里列出的书一起看，然后再动手自己写一遍代码。x`

希望这能帮助到你们！

---

## 每个部分包含哪些内容？

### Brief

设计模式的基本介绍。

### The Question

需求（我会尽量让这个需求更接近于真实需求）是什么？

### Bad Code Example

抛开脑子里关于模式的认知，想想你会怎么写？
以及一个错误的示例。

### Good Code Example

使用设计模式实现这个需求的代码示例。

### Post
一个我的博客文章的链接，里面会包含代码的详细解释和更多细节。

---

## 内容

目前已经完成的例子有：

**行为型模式**
- [] Chain Of Responsibility
- [] Command
- [] Iterator
- [] Mediator
- [] Memento
- [x] Observer
- [] State
- [] Strategy
- [] Template Method
- [] Visitor

**结构型模式**
- [] Adapter
- [] Bridge
- [] Composite
- [] Decorator
- [] Facade
- [x] 享元模式
- [] Proxy


**创建型模式**
- [] Factory Method
- [] Abstract Factory
- [] Builder
- [] Prototype
- [] Singleton

## 致谢

本项目参考了以下项目的部分代码：
- ⭐[Habrador/Unity-Programming-Patterns](https://github.com/Habrador/Unity-Programming-Patterns)

向他们表示衷心的感谢！

## 参考资料与了解更多

- [Game Programming Patterns](http://gameprogrammingpatterns.com/)

- [Refactoring.Guru](https://refactoringguru.cn/)

- [C#设计模式（第2版） (豆瓣) (douban.com)](https://book.douban.com/subject/30131470/)

- [设计模式与游戏完美开发 (豆瓣) (douban.com)](https://book.douban.com/subject/26952185/)

- [Habrador/Unity-Programming-Patterns](https://github.com/Habrador/Unity-Programming-Patterns)

- [QianMo/Unity-Design-Pattern](https://github.com/QianMo/Unity-Design-Pattern)
## License

本工程使用[MIT授权协议](https://opensource.org/licenses/MIT)。

参考了一些外部工程的源码，查看[License](./LICENSE)以获取全部的授权文本。