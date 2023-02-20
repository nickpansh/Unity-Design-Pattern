<!--
 * @Author: NickPansh
 * @Date: 2023-01-31 19:34:13
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-20 17:59:01
 * @FilePath: \Unity-Design-Pattern\Assets\CreationalPatterns\Singleton\README.md
 * @Description: 
 * 
 * Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
-->

## 单例模式的实现

单例模式实现的关注点无外乎：

1. 构造函数必须有private访问权限，这样才能避免被new
2. 对象创建时是否线程安全
3. 是否支持延迟加载
4. GetInstance的性能

具体的实现方案可参见see: [Best Practice of Unity Singleton](https://wenqu.site/Unity%E5%8D%95%E4%BE%8B%E6%A8%A1%E5%BC%8F%E6%9C%80%E4%BD%B3%E5%AE%9E%E8%B7%B5%EF%BC%88%E9%99%84%E4%BB%A3%E7%A0%81%EF%BC%89.html)

但是不建议在项目中滥用单例模式。

## 为什么不建议在项目中使用单例模式

### 问题：

1. **单例模式隐藏类之间的依赖关系**

   不好知道一个类究竟依赖了哪些单例类，单例是面向过程的设计风格

 2. 单例模式影响代码的拓展性

    万一将来有一天想变单例为实例……

3. **影响了代码的可测试性**

   主要是写单元测试代码的时候

4. 单例模式不支持包含参数的构造方法

   虽可通过提供Init()方法/将参数放在Instance()函数中/将参放在全局变量中来实现，但又引发各自的新问题

   

   

## 单例模式的替代方案

- 考虑是否需要这个类

- ~~依赖注入~~

  我不觉得这是好的方案，许多情况传递层级会太深了

- ~~将类限制为单一实例（在构造函数里用assert）~~

  我不觉得这是好方案，单例在编译器就能检查实例个数，这个方案在运行时才能检查
- **静态方法**

  - **一些情况下**这是个比较好的方案，比如Unity对于Log就没有设计成单例类，而是静态方法。如果一个单例里功能不多，可能是考虑用静态方法的时候。
  - 但这也不是银弹，它依旧难以扩展，测试不方便

- **ScriptObject**

  Unity里，配置相关的单例我主张用ScriptObject来做

- **使用服务定位器模式**

  这是推荐做法，参照ToLua框架的AppFacade类
  
  关于服务定位器的更多介绍，参见《TODO:》



## 结论

单例模式的最大问题就是它影响了代码的可拓展性。

综合考虑，我们不需要在游戏里实现单例。

管理类通过服务定位器来调用。

配置类用ScriptObject来实现。

一些通用的方法掉用靠静态类的静态方法来调用。



## 引用

- 《设计模式之美》第6章
- 《游戏编程模式》第6章
