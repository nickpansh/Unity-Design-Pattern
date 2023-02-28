# 组合模式



### 概要

> **组合多个对象形成树形结构用来表示具有部分—整体关系的层次结构。组合模式让客户端可以统一对待单个对象和组合对象**

组合模式的关键在于定义了一个抽象构件类，它既可以代表叶子，又可以代表容器。

客户端针对该抽象构建类进行编程，无需知道它到底表示的是叶子还是容器，可以对他进行统一的管理。

![组合模式.drawio](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/02/09/%E7%BB%84%E5%90%88%E6%A8%A1%E5%BC%8F.drawio.png)

### 需求

你在开发一款模拟经营游戏。

这款游戏里有农田Farm，农田上可以种水果Fruit，也可以种水稻Wheat，还可以种花Grass。

- 水果/水稻/花都可以卖掉
- 水果/水稻/花都是有价格的，策划需要我们提供一个方法可以获得它们的价格
- 水果/水稻/花都可以快速收获，快速收获可以直接获得相对应的奖励
- 农田是一种建筑，可以被回收（水果/水稻/花不能被回收）

这还不简单嘛，Fruit/Wheat/Grass都继承Crop这个抽象基类，Crop定义Sell(),GetPrice(),QuickHarvest()三个方法。

Farm继承Item这个基类，Item定义了Recycle方法。

然后再给Farm添加一个AddCrop方法和RemoveCrop方法不就搞定了？

策划看你比较闲，又提了个需求：对了我忘了说了，农田也要可以卖掉！

你想了想，哦，也不难嘛。

在Farm里添加一个Sell方法不就好了？

这个Sell方法的实现是遍历crops数组，对于每一个crop都执行sell。

代码是完成了，但你仔细想想，这么写出来的代码，调用方该如何调用Sell方法？



### 坏代码

```c#
// 示例
public void Sell(Component com){
    if(typeof(com) == Item){
        obj.Sell()
    }else if(typeof(com) == Crop){
        obj.Sell()
    }
}
```

管理很不方便，容器（农田）的管理是一套，叶子（作物）的管理是一套。

怎么办？

怎么才能让农田和叶子都能被统一管理呢？

把Crop换成ITradable接口，让农田和水果/水稻/花都实现ITradable接口，从而让容器和叶子都可以被统一管理。

**实际上这个就是组合模式—定义了一个抽象构件类，它既可以代表叶子，又可以代表容器。客户端针对该抽象构建类进行编程，无需知道它到底表示的是叶子还是容器，可以对他进行统一的管理。**



### 好代码（用组合模式实现需求）

![组合模式例子.drawio](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/02/09/%E7%BB%84%E5%90%88%E6%A8%A1%E5%BC%8F%E4%BE%8B%E5%AD%90.drawio.png)


实际上体现了面向接口编程的思想。

```c#
public interface IComponent
{
    public void Add(IComponent c);
    public void Remove(IComponent c);
    public IComponent GetChild(int i);

}
```

```c#
 public interface ITradable : IComponent
 {
     public float GetPrice();
     public void Sell();
     public void QuickHarvest();
 }
```

调用代码

```c#
ITradable wheat1 = new Wheat(100);
ITradable fruit1 = new Fruit(150);
ITradable flower1 = new Flower(200);
Debug.Log($"wheat1 's price = {wheat1.GetPrice()}");
Debug.Log($"fruit1 's price = {fruit1.GetPrice()}");
Debug.Log($"flower1 's price = {flower1.GetPrice()}");

ITradable farm1 = new Farm();
farm1.Add(wheat1);
farm1.Add(fruit1);
farm1.Add(flower1);
Debug.Log($"farm1 's price = {farm1.GetPrice()}");
```



### 什么时候用

-  如果你需要实现树状对象结构， 可以使用组合模式。
- 如果你希望客户端代码以相同方式处理简单和复杂元素， 可以使用该模式。



