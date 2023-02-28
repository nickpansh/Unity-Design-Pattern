## 概要

> **抽象工厂模式**比工厂方法模式的抽象化程度更高，它提供一个创建一系列相关或相互依赖对象的接口，而无需指定他们的类。

![](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/02/02/abstract_factory.png)


[工厂方法模式]([Unity设计模式—工厂方法模式 | 问渠 (wenqu.site)](https://wenqu.site/Unity设计模式——工厂方法模式.html))解决了简单工厂模式种工厂类职责太重的问题，但由于工厂方法模式中的每个具体工厂只有一个或者一组重载的工厂方法，只能生产一种产品，可能会导致系统中存在大量的工厂类，势必会增加系统的开销。

**有时候可能需要一个工厂能够提供多种产品对象，一个“产品族”都由同一个工厂来生产，这就是抽象工厂模式的基本思想。**


总体来说，抽象工厂模式用的不多，建议大家简单了解下就行。


## 需求

我们继续沿用在[工厂方法模式]([Unity设计模式—工厂方法模式 | 问渠 (wenqu.site)](https://wenqu.site/Unity设计模式——工厂方法模式.html))里提出的需求：

在你的游戏里，有一个装饰系统。

玩家可以生成各种类型的装饰物：

- 建筑Building，继承Item
  - 需要在运行时挂载UnityEngine.AI.NavMeshStacle组件
- 商店Shop，继承BaseBuilding
  - 不要挂载NavMeshStacle
  - 若shop的id==shop_001,需要在运行时额外挂载一个Fog脚本
- 树Tree，继承Item
  - Tree类有一个BeChopDown方法，用于实现被砍伐后的效果
  - 读取本地的配置文件，初始化树的属性（伪代码）
  - 在TreePool里增加这个数（伪代码）



在这个基础上，策划提了一个新需求——

我们准备上架Switch平台和微信小游戏平台了！但是这两个平台上所有的装饰物我们都会进行全新的改版。

它们会有完全不一样的模型，贴图，以及各种进一步的设计。

总而言之，你应该把之前的所有类都拓展一份：SwitchBuiling,SwitchShop,SwitchTree，H5Building,H5Shop,H5Tree

生成完这些对象后，还有许多平台相关的操作需要去做（用伪代码）

游戏启动时，根据平台不同生成对应的Builing:bu_1001,bu_1002,bu_1003,生成商店shop_1001,shop_1002,生成树tree_1001,tree_1002。

### 差代码

我们继续用工厂方法模式，继续构建

- SwitchBuildingFactory
- SwitchShopFactory
- SwitchTreeFactory
- H5BuildingFactory
- H5ShopFactory
- H5TreeFactory
- ……

代码写的头疼吧？

## 好代码（用抽象工厂模式实现需求）

先生成一个抽象工厂AbstractItemFactory

```c#
public abstract class AbstractItemFactory
{

    public abstract Building CreateBuilding(GameObject prefab, string id);
    public abstract Shop CreateShop(GameObject prefab, string id);
    public abstract WenQu.FactoryMethod.Tree CreateTree(GameObject tree, string id);
}
```

再生成具体工厂两个分别是H5ItemFactory , SwitchItemFactory

```c#
 public class H5ItemFactory : AbstractItemFactory
 {
     private int buildingCount = 0;
     private int shopCount = 0;
     private int treeCount = 0;

     private static H5ItemFactory _Instance = new H5ItemFactory();


     public override Building CreateBuilding(GameObject prefab, string id)
     {
         GameObject gameObject = Object.Instantiate(prefab);
         H5Building building = gameObject.AddComponent<H5Building>();
         gameObject.AddComponent<UnityEngine.AI.NavMeshObstacle>();
         building.gameObject.transform.localPosition = new Vector3(buildingCount, 0, buildingCount) * gameObject.transform.localScale.x;
         building.id = id;
         buildingCount++;
         //H5平台创建Building的后续操作
         //
         //
         //
         //
         return building;
     }

     public override Shop CreateShop(GameObject prefab, string id)
     {
         GameObject go = Object.Instantiate(prefab);
         H5Shop shop = go.AddComponent<H5Shop>();
         shop.id = id;
         if (id == "shop_1001")
         {
             go.AddComponent<SphereCollider>();
         }
         shop.gameObject.transform.localPosition = new Vector3(shopCount * shop.gameObject.transform.localScale.x, 3, shopCount * shop.gameObject.transform.localScale.x);
         shopCount++;
         //H5平台创建Shop的后续操作
         //
         //
         //
         //
         return shop;
     }

     public override FactoryMethod.Tree CreateTree(GameObject prefab, string id)
     {
         GameObject gameObject = Object.Instantiate(prefab);
         H5Tree tree = gameObject.AddComponent<H5Tree>();
         LoadConf();
         AddToTreePool();
         tree.gameObject.transform.localPosition = new Vector3(treeCount * gameObject.transform.localScale.x, 6, treeCount * gameObject.transform.localScale.x);
         treeCount++;
         //H5平台创建Tree的后续操作
         //
         //
         //
         //
         return tree;
     }

     private void LoadConf()
     {
         // 伪代码：加载本地文件，读取树的配置
     }

     private void AddToTreePool()
     {
         // 伪代码，加入TreePool
     }
 }
```

生成代码（这里利用了反射+ScriptableObject，有兴趣的可以看[源码](https://github.com/nickpansh/Unity-Design-Pattern)）

```c#
// 演示通过反射生成
Assembly assembly = Assembly.Load("Assembly-CSharp");
foreach (ItemConf conf in confs)
{
    for (int i = 0; i < conf.ids.Length; i++)
    {
        if (conf.prefabs.Length > 0)
        {

            AbstractItemFactory factory;
            cache.TryGetValue(platformConf.factoryClass, out factory);
            if (factory == null)
            {
                factory = assembly.CreateInstance(platformConf.factoryClass) as AbstractItemFactory;
                cache.Add(platformConf.factoryClass, factory);
            }
            Type factoryType = assembly.GetType(platformConf.factoryClass);
            MethodInfo method = factoryType.GetMethod(conf.methodName);
            method?.Invoke(factory, new object[] { conf.prefabs[1], conf.ids[i] });
        }
    }
}
```

## 补充

上面的例子演示了“不同类别的产品族”的生成。

所以都是用类的继承关系实现的（具体工厂类继承抽象工厂类）

实际开发中我们也会遇到“不同功能的产品组”的生成。

这种情况下用接口实现（具体工厂类实现抽象工厂接口），举例如下

#### 需求

我们需要一些工厂来生成"可被玩家点击"和"可被玩家拾取"的物品。

#### 方案

构造一个IClickable接口，可交互的装饰物实现这个接口。

构造一个IPickable接口，可拾取的装饰物实现这个接口。

```c#
public abstract class AbstractFactory{
    public abstract Building CreateBuilding();
    public abstract Shop CreateShop();
    public abstract Tree CreateTree();
}
```

```c#
public class ClickableFactory{
    public override IClickable CreateBuilding(){
        //
    }
    public override IClickable CreateShop(){
        //
    }
    public override IClickable CreateTree(){
        //
    }
}
```

```c#
public class PickableFactory{
    public override IPickable CreateBuilding(){
        //
    }
    public override IPickable CreateShop(){
        //
    }
    public override IPickable CreateTree(){
        //
    }
}
```


## 什么时候用


- **系统中有多于一个的产品族**，而每次只使用其中某一产品族。可以通过配置文件等方式来使得用户可以动态改变产品族，也可以很方便地增加新的产品族。
- **属于同一个产品族的产品将在一起使用，这一约束必须在系统的设计中体现出来**。同一个产品族中的产品可以是没有任何关系的对象，但是它们都具有一些共同的约束，如同一操作系统下的按钮和文本框，按钮与文本框之间没有直接关系，但它们都是属于某一操作系统的，此时具有一个共同的约束条件：操作系统的类型。
- **产品等级结构稳定，设计完成之后，不会向系统中增加新的产品等级结构或者删除已有的产品等级结构**。


## 其他设计模式

[专题 | Unity3D中的设计模式 | 问渠 (wenqu.site)](https://wenqu.site/Unity-Design-Pattern.html)