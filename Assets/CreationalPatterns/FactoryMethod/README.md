# Unity设计模式—工厂方法模式

### Brief | 概要

> **工厂方法模式**是简单工厂模式的延伸，它保留了简单工厂模式优点点，同时还弥补了简单工厂的缺陷：能更好地符合开闭原则要求，在增加新的具体产品对象时无需对已有系统做任何修改。

![](https://wenqu.space/uploads/2023/02/01/factorymethod.png)

这里简单介绍下工厂方法模式和工厂模式的区别：

一言以蔽之，工厂方法模式通过引入抽象工厂类，使得系统更符合开闭原则，比简单工厂模式更好。

<!-- more -->

![factoryVSfactoryMethod_cn](https://wenqu.space/uploads/2023/02/01/factoryVSfactoryMethod_cn.png)


具体不展开，本篇主旨是在Unity中 实现与演示命令模式，有关工厂方法模式的详细介绍可以看:

[工厂方法设计模式 (refactoringguru.cn)](https://refactoringguru.cn/design-patterns/factory-method)

### The Question | 需求

在你的游戏里，有一个装饰系统。

玩家可以生成各种类型的装饰物：

- 建筑Building，继承Item
  - 需要在运行时挂载UnityEngine.AI.NavMeshStacle组件
- 商店Shop，继承BaseBuilding
   - 不要挂载NavMeshStacle
   - 若shop的id==shop_001,需要在运行时额外挂载一个Fog脚本
- 树Tree，继承Item
  - 读取本地的配置文件，初始化树的属性（伪代码）
  - 在TreePool里增加这个数（伪代码）

游戏启动时，生成Builing:bu_1001,bu_1002,bu_1003,生成商店shop_1001,shop_1002,生成树tree_1001,tree_1002

### Bad Code Example | 差代码

不用工厂方法模式，很自然地想到在DecorateController里增加GenBuilding(), GenShop(), GenTree() 三个方法用来实现上述需求。

```c#
 private void AWake()
  {
      //生成建筑bu_1001,bu_1002,bu_1003
      Building building1 = GenBuilding(buildingPrefab, "bu_1001");
      Building building2 = GenBuilding(buildingPrefab, "bu_1002");
      Building building3 = GenBuilding(buildingPrefab, "bu_1003");

      // 生成Shop shop_1001,shop_1002
      Shop shop1 = GenShop(shopPrefab, "shop_1001");
      Shop shop2 = GenShop(shopPrefab, "shop_1002");

      // 生成树tree_1001,tree_1002
      Tree tree1 = GenTree(treePrefab, "tree_1001");
      Tree tree2 = GenTree(treePrefab, "tree_1001");
  }

  // 生成建筑，不符合单一职责原则：DecorateController后期会存在大量的GenXX方法越来越庞大
  private Building GenBuilding(GameObject prefab, string id)
  {
      GameObject gameObject = Object.Instantiate(prefab);
      Building building = gameObject.AddComponent<Building>();
      gameObject.AddComponent<UnityEngine.AI.NavMeshObstacle>();
      building.gameObject.transform.localPosition = new Vector3(count, 0, count) * gameObject.transform.localScale.x;
      building.id = id;
      count++;
      //等等一系列用于Create一个Building的操作
      return building;
  }

  // 生成树木，不符合单一职责原则：DecorateController后期会存在大量的GenXX方法越来越庞大
  private Tree GenTree(GameObject prefab, string id)
  {
      GameObject gameObject = Object.Instantiate(prefab);
      Tree tree = gameObject.AddComponent<Tree>();
      TreeLoadConf();
      TreeAddToTreePool();
      tree.gameObject.transform.localPosition = new Vector3(count * gameObject.transform.localScale.x, 6, count * gameObject.transform.localScale.x);
      count++;
      return tree;
  }

private void TreeLoadConf()
{
    // 伪代码：加载本地文件，读取树的配置
}

private void TreeAddToTreePool()
{
    // 伪代码，加入TreePool
}
```

这个实现方案最大的问题是不符合单一职责原则，DecorateController里塞了太多创建对象的行为
随着项目的增长，这个DecorateController会越来越庞大

### Good Code Example | 好代码（用工厂方法模式实现需求）

先定义一个抽象工厂方法（或者接口也可以）

```c#
namespace WenQu.FactoryMethod
{
    public abstract class AbstractItemFactory
    {
        public abstract Item Create(GameObject prefab, string id);
    }
}
```

然后添加具体的工厂方法，这样我们就把创建相关的代码都放到这个具体的工厂方法内了。

**符合单一职责原则。**

```c#
 public class BuildingFactory : AbstractItemFactory
 {
     private int count = 0;
     public override Item Create(GameObject prefab, string id)
     {
         GameObject gameObject = Object.Instantiate(prefab);
         Item building = gameObject.AddComponent<Building>();
         gameObject.AddComponent<UnityEngine.AI.NavMeshObstacle>();
         building.gameObject.transform.localPosition = new Vector3(count, 0, count) * gameObject.transform.localScale.x;
         building.id = id;
         count++;
         //等等一系列用于Create一个Building的操作
         return building;
     }
 }
```

调用的代码：

```c#
 //生成建筑bu_1001,bu_1002,bu_1003
BuildingFactory buildingFactory = new BuildingFactory();
Building building1 = (Building)buildingFactory.Create(buildingPrefab, "bu_1001");
Building building2 = (Building)buildingFactory.Create(buildingPrefab, "bu_1002");
Building building3 = (Building)buildingFactory.Create(buildingPrefab, "bu_1003");
```

如果我们需要创建新的类型，只需要新写一个Factory集成抽象工厂。

**符合开闭原则。**

### Conclusion | 结论

### When to use | 什么时候用

- 当你在编写代码的过程中， 如果无法预知对象确切类别及其依赖关系时， 可使用工厂方法。

- 如果你希望用户能扩展你软件库或框架的内部组件， 可使用工厂方法。

- 如果你希望复用现有对象来节省系统资源， 而不是每次都重新创建对象， 可使用工厂方法。


## 其他设计模式

[专题 | Unity3D中的设计模式 | 问渠 (wenqu.site)](https://wenqu.site/Unity-Design-Pattern.html)