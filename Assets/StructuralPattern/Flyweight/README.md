<!--
 * @Author: NickPansh
 * @Date: 2023-01-31 13:27:56
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-10 12:05:25
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\Flyweight\README.md
 * @Description: 
 * 
 * Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
-->
# 享元模式Flyweight


## Brief

> **享元模式**是一种结构型设计模式， 它摒弃了在每个对象中保存所有数据的方式， 通过共享多个对象所共有的相同状态， 让你能在有限的内存容量中载入更多对象。

See More:[Refactoring.Guru](https://refactoring.guru/design-patterns/flyweight)

## The Question

在游戏中，同时有一万个敌人。

暂时不考虑渲染压力，单纯设计一个敌人属性的实现。

敌人的属性包括：

- 敌人的血量（各不相同）
- 敌人的身高（各不相同）
- 敌人的名字（根据职级不同而不同，职级有四种：新兵，中士，上士，上尉）
- 敌人的图片路径（上尉是a.png,其他都是b.png）
- 敌人死亡，攻击，受击时播放的音效（全都一样，string[3]）
- 敌人的颜色（全都是Color.New(128,0,128,255))
- 敌人的血量上限（根据职级不同而变，依次是100，200，500，1000）
- 敌人的移动速度（ 根据职级不同而变，依次是 1.0 , 2.0 , 3.0, 4.0，double类型)

你会怎么实现？

## Bad Code Example

查看 Bad Code里的代码

---

若你考虑用枚举实现，查看[博客详解](https://wenqu.site/Unity%E8%AE%BE%E8%AE%A1%E6%A8%A1%E5%BC%8F%E2%80%94%E4%BA%AB%E5%85%83%E6%A8%A1%E5%BC%8F%EF%BC%88%E9%99%84%E4%BB%A3%E7%A0%81%EF%BC%89.html)

## Good Code Example

查看 Example 里的代码。

## 内存开销对比

不用享元:
![](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/01/31/20230131114215.png)

用享元模式:
![](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/01/31/20230131114910.png)

## 其他设计模式

[专题 | Unity3D中的设计模式 | 问渠 (wenqu.site)](https://wenqu.site/Unity-Design-Pattern.html)

---