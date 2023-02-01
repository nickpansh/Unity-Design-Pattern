# Design Pattern in Unity3D

[中文](README.md)

This repository is a collection of Design Patterns in Unity,written in C#.

Design patterns are great.Many design patterns are subtle just by looking at them,but for some people (at least me as a beginner), the biggest problems are:


- I don't know what the design pattern is for and when to use it although I understand its definition.

- I used to learn them all, but I basically forgot about them after work.

- I should have used most of them, but I'd like to see how other people (especially the source code of some good projects) use it.

So **I try to explain design patterns in a new form**:

I divide design patterns into two categories, they are:

1. Some design patterns that are not so widely used, you should have heard their names, but it's likely that you don't know when and how to use it.()

2. Some design patterns that you may have used and are widely used, you should have used them.You want to take a deeper look at where the Unity engine uses this design pattern.(e.g. Singleton,Prototype,etc.)


For the first case.
**I will first ask one question: **

**If you throw away all the design patterns, how would you achieve a certain requirement?**


This requirement will be a specific requirement in the field of game development, rather than a vague concept mentioned in many books or examples.(e.g. Making an order in a restaurant,Clone a animal,Suqare and Circle extend Shape,MyShapeFactory and so on.)

Then I will give the bad code and the good code using the Design Pattern to help readers better understand the Design Pattern.

**Hope this form helps you understand Design Patterns better.**

For the second case.

**I will focus on how to use it in Unity and How unity [UnityCSReference](https://github.com/Unity-Technologies/UnityCsReference)(C# part of the Unity engine code) use it.**


I will try to make this example as practical as possible.

It is recommended to read it together with a book listed in the Reference, and then write the code yourself.

Hope this works for you!

---

## What does each part consist of?

### Brief

Basic introduction of the Design Pattern.

### The Question

What is the requirement? (I will try to make this closer to the real requirement)

### Bad Code Example

Putting aside the perception of patterns in your mind, Think about how you would design?
And a bad code example.

### Good Code Example

Code example using the design pattern.

### (Conditional) Let's see the source code

the code from [UnityCSReference](https://github.com/Unity-Technologies/UnityCsReference)

### Post

A link to my blog post, which contains code explanations and detailed ideas.

---
## Content

Examples that have been completed so far are：


**Creational Patterns**
- [x] [Factory Method](./Assets/FactoryMethod/README.md)
- [] Abstract Factory
- [] Builder
- [x] [Prototype](./Assets/Prototype/README.md)
- [x] [Singleton](./Assets/Singleton/README.md)


**Behavioral design patterns**
- [] Chain Of Responsibility
- [] Command
- [] Iterator
- [] Mediator
- [] Memento
- [x] [Observer](./Assets/Observer/README.md)
- [] State
- [] Strategy
- [] Template Method
- [] Visitor

**Structural Patterns**
- [] Adapter
- [] Bridge
- [] Composite
- [] Decorator
- [] Facade
- [x] [Flyweight](./Assets/Flyweight/README.md)
- [] Proxy

## Acknowledgements

The code in Unity-Design-Pattern references part of the source code of:
- ⭐[Habrador/Unity-Programming-Patterns](https://github.com/Habrador/Unity-Programming-Patterns)

A heartfelt thank you to them!

## References and Read More

- [Game Programming Patterns](http://gameprogrammingpatterns.com/)

- [Refactoring.Guru](https://refactoringguru.cn/)

- [C# Design Pattern](https://book.douban.com/subject/30131470/)

- [Design Patterns in Game Development](https://book.douban.com/subject/26952185/)

- [Habrador/Unity-Programming-Patterns](https://github.com/Habrador/Unity-Programming-Patterns)

- [UnityCSReference](https://github.com/Unity-Technologies/UnityCsReference)

- [.NET Framework](https://referencesource.microsoft.com/)
## License

Unity-Design-Pattern is avaiable under the [MIT license](https://opensource.org/licenses/MIT).

Unity-Design-Pattern references part of the source code of other projects, See [License](./LICENSE) for the full license text.