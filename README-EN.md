# Design Pattern in Unity3D



This repository is a collection of Design Patterns in Unity,written in C#.

Inclues:
- 23 Game of Four Patterns
- 《Game Programming Patterns》 in Unity

[中文](README.md)

### Background

The beauty of design patterns is that they are a set of proven and practiced general solutions that can help software engineers improve the quality of their code and simplify the complexity of software development.

But the controversy about design patterns in recent years has also been endless.

The main reason is that the concept of design patterns has been proposed for nearly thirty years. With the development of modern software engineering, some situation has changed:

- With the development of software engineering, the business split is finer, and the framework and business are often completely disassembled. Some reusable software has migrated to the underlying system/language as toolkits or frameworks—and mostly should be left to the experts.

- Some design patterns are already integrated by languages ​​or frameworks. It is more convenient to use these language support for developers who use them.

- GOF did not sort the design patterns according to the frequency of use, which led to some misunderstandings.

But no matter what level of programmers, what type of code development, as long as we pursue code reusability, we need to practice the internal strength of design patterns.

I'm trying to illustrate **Design Patterns** in the field of Unity3D game development, Includes:

- According to my understanding, sort the design patterns in game development by **importance**.
- In addition to 23 design patterns, **introduce the game design patterns from "Game Programming Patterns"**.
- For each design pattern, **ideas and examples of using it in game development are provided**, focusing on game development, with the purpose of deepening understanding and avoiding generalizations.
- For those patterns wildly used in framework (C#/.Net Frameworks/Unity3D)  , focus on how the framework use the pattern. **Talk about the understanding of design patterns through the source code in [UnityCSReference](https://github.com/Unity-Technologies/UnityCsReference)**.


### For whom

- Engineers who have a basic understanding of Unity game development and want to **improve code quality**.
- Engineers who have a basic understanding of Unity game development and design patterns and want to **review design patterns**.
- junior programmers who are interested in game development and ready to **dive deep** in this field.
- Engineers who don't know anything about Unity3D game development, but are interested in design patterns and want to find **design-patterns examples in game development**.

### Not for whom

- People who don't understand Unity development at all, and have never heard of design patterns. (It is recommended to learn Unity development and design patterns separately)
- Engineers who feel that design patterns are useless and enjoy shit code.


## Catalogue

Examples that have been completed so far are：


- **Creational Patterns**

    - **Core**

        - [x] [Factory Method](./Assets/CreationalPatterns/FactoryMethod/README.md)
        - [x] [Builder](./Assets/CreationalPatterns/BuilderPattern/README.md)
        - [x] [Prototype](./Assets/CreationalPatterns/Prototype/README.md)


    - Peripheral

        - [x] [Abstract Factory](./Assets/CreationalPatterns/AbstractFactory/README.md)
        - [x] [Singleton](./Assets/CreationalPatterns/Singleton/README.md)

- **Structural Patterns**
    - **Core**
        - [x] [Decorator](./Assets/StructuralPattern/DecoratorPattern/README.md)
        - [x] [Facade](./Assets/StructuralPattern/FacadePattern/README.md)
        - [x] [Proxy](./Assets/StructuralPattern/Proxy/README.md)
        - [x] [Composite](./Assets/StructuralPattern/CompositePattern/README.md)
        - [x] [Flyweight](./Assets/StructuralPattern/Flyweight/README.md)

    - Peripheral
        - [x] [Adapter](./Assets/StructuralPattern/AdapterPattern/README.md)
        - [x] [Bridge](./Assets/StructuralPattern/BridgePattern/README.md)



- **Behavioral design patterns**

    - **Core**
        - [x] **[Command](./Assets/BehavioralPattern/Command/README.md)**
        - [x] **[Iterator](./Assets/BehavioralPattern/Iterator/README.md)**
        - [x] **[Observer](./Assets/BehavioralPattern/Observer/README.md)**
        - [x] **[Mediator](./Assets/BehavioralPattern/Mediator/README.md)**

    - Peripheral

        - [x] [Chain Of Responsibility](./Assets/BehavioralPattern/ChainOfResponsibility/READ.md)


- [] Memento
- [] State
- [] Strategy
- [] Template Method
- [] Visitor

**Visit[专题 | Unity3D中的设计模式](https://www.wenqu.site/Unity-Design-Pattern.html)to see more**

## Acknowledgements

The code in Unity-Design-Pattern references part of the source code of:
- [Habrador/Unity-Programming-Patterns](https://github.com/Habrador/Unity-Programming-Patterns)
- [QianMo/Unity-Design-Pattern](https://github.com/QianMo/Unity-Design-Pattern)

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