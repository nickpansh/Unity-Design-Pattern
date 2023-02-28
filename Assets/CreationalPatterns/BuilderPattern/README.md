## Brief | 概要

> **建造者模式**是一种创建型设计模式， 使你能够分步骤创建复杂对象。 该模式允许你使用相同的创建代码生成不同类型和形式的对象。

![](https://pic.wenqu.space/other/design-pattern/builder.png)

建造者模式关注如何逐步创建一个复杂的对象，可以分步骤生成对象， 而且允许你仅使用必须的步骤。 应用该模式后， 你再也不需要将几十个参数塞进构造函数里啦。

## The Question | 需求

我的游戏里有两种类型的角色，分别是Monster和Pet。

他们都由如下部件组成：

- AI，由AIFactory提供，Monster是MonsterAI，Pet是PetAI
- Weapon | 武器，如果weaponId == null，则不添加武器组件
- OnClickBehaviour | 点击后的响应脚本
- Bag | 背包，Pet有背包，Monster没有背包。
- Monster有属性HP,MP,HPMax,MPMax,ID,WeaponId
- Pet有属性ID，followTransform



想想你会怎么写？

### Bad Code Example | 差代码

如果不用设计模式，代码应该是这样的。

```c#
// Bad Code
// 生成一个Monster,没有武器
GameObject gameObject = LoadModel("Prefabs/Monster", "monster_1001");
Monster monster = gameObject.AddComponent<Monster>();
monster.hp = 100;
monster.maxHp = 100;
monster.mp = 0;
monster.maxMp = 50;
gameObject.AddComponent<MonsterAI>();
gameObject.AddComponent<OnClickBehaviour>();

// 生成Monster_1002,携带武器weapon002 
GameObject gameObject2 = LoadModel("Prefabs/Monster", "monster_1002");
Monster monster2 = gameObject2.AddComponent<Monster>();
monster.hp = 100;
monster.maxHp = 100;
monster.mp = 20;
monster.maxMp = 50;
gameObject2.AddComponent<MonsterAI>();
gameObject2.AddComponent<OnClickBehaviour>();
Weapon weapon = gameObject2.AddComponent<Weapon>();
weapon.weaponId = "weapon002";

// 生成一只最基本的Monster，不设置属性
GameObject gameObject3 = LoadModel("Prefabs/Monster", "monster_1003");
Monster monster3 = gameObject3.AddComponent<Monster>();

// 生成一只宠物
GameObject gameObjectPet = LoadModel("Prefabs/Pet", "pet_1001");
Pet pet = gameObjectPet.AddComponent<Pet>();
pet.followTransform = monster3.gameObject.transform;
gameObjectPet.AddComponent<PetAI>();
gameObjectPet.AddComponent<OnClickBehaviour>();
gameObjectPet.AddComponent<Bag>();
```

Monster和Pet的生成会散落在各地。可维护性非常差。

还违反了单一职责原则。

如果我们尝试把创建的代码写到Monster.cs和Pet.cs里的话，会发生这样的情况……

```c#
public Actor(string id,string prefabName,float hp,float maxHp,float mp,float maxMp,float hasBag,string weaponId,Transform followTransform)
{

}
```

我们将获得一个有一串参数的构造方法……

**当你的代码里出现了一串参数的构造方法时，恰恰就是你该考虑建造者模式的时候！**



## Good Code Example | 好代码（用建造者模式实现需求）

创建一个ActorBuilder.cs，作为抽象的创造者基类

```c#
 public abstract class ActorBuilder
 {
     protected Actor actor;

     protected GameObject gameObject;
     public abstract void SetBaseAttr();

     public abstract Component AddWeapon();
     public abstract Component AddAI();

     public abstract Component AddBag();
     public abstract Actor AddActor();

     public abstract GameObject LoadModel();
     public virtual bool HasBag()
     {
         return false;
     }

     public virtual bool HasWeapon()
     {
         return true;
     }

     public virtual void Reset(ActorBuilderParam buildParam)
     {
         this.actor = null;
     }

     public virtual Component AddOnClickBehaviour()
     {
         OnClickBehaviour com = this.gameObject.AddComponent<OnClickBehaviour>();
         return com;
     }

     // 这里省略了Director
     public Actor ConstructFull()
     {

         GameObject go = this.LoadModel();
         actor = this.AddActor();
         this.SetBaseAttr();
         // 钩子方法
         if (this.HasWeapon())
         {
             this.AddWeapon();
         }
         this.AddAI();
         this.AddOnClickBehaviour();
         // 钩子方法
         if (this.HasBag())
         {
             this.AddBag();
         }
         return actor;
     }

     public Actor ConstructMinimal()
     {
         GameObject go = this.LoadModel();
         actor = this.AddActor();
         this.SetBaseAttr();
         return actor;
     }
 }
```

具体的创建者就是这样的：

```c#
 public class MonsterBuilder : ActorBuilder
 {
     private MonsterBuilderParam buildParam;
     public MonsterBuilder(MonsterBuilderParam buildParam)
     {
         this.buildParam = buildParam;
     }


     public override Component AddAI()
     {
         // 可以在这里使用复杂的逻辑，用工厂添加武器
         // 这里做演示，仅仅只是添加空的武器
         MonsterAI com = this.gameObject.AddComponent<MonsterAI>();
         return com;
     }



     public override Component AddWeapon()
     {
         // 可以在这里使用复杂的逻辑，用工厂添加武器
         // 这里做演示，仅仅只是添加空的武器
         Weapon com = this.gameObject.AddComponent<Weapon>();
         com.weaponId = this.buildParam.weaponId;
         return com;
     }

     public override bool HasBag()
     {
         return false;
     }

     public override bool HasWeapon()
     {
         return this.buildParam.weaponId != null;
     }
     public override Component AddBag()
     {
         throw new System.NotImplementedException();
     }
     public override void SetBaseAttr()
     {

         actor.id = this.buildParam.id;

     }

     public override GameObject LoadModel()
     {
         gameObject = (GameObject)Object.Instantiate(Resources.Load(this.buildParam.prefabName));
         this.gameObject.name = this.buildParam.id;
         return gameObject;

     }

     public override Actor AddActor()
     {
         Monster com = this.gameObject.AddComponent<Monster>();
         com.hp = this.buildParam.hp;
         com.mp = this.buildParam.mp;
         com.maxHp = this.buildParam.maxHp;
         com.maxMp = this.buildParam.maxMp;
         return com;
     }

     public override void Reset(ActorBuilderParam buildParam)
     {
         base.Reset(buildParam);
         this.buildParam = (MonsterBuilderParam)buildParam;
     }
 }
```

我们将构造相关的逻辑都交给XXBuilder来实现。

那么生成一个对象的代码将会变得非常简洁。

```c#
  // 生成一个Monster,没有武器
MonsterBuilderParam buildParam1001 = new MonsterBuilderParam("monster_1001", "Prefabs/Monster", 100, 100, 0, 50);
MonsterBuilder monsterBuilder = new MonsterBuilder(buildParam1001);
Monster monster = (Monster)monsterBuilder.ConstructFull();

// 生成Monster_1002,携带武器weapon002 
var buildParam1002 = new MonsterBuilderParam("monster_1002", "Prefabs/Monster", 100, 100, 20, 50, "weapon002");
monsterBuilder.Reset(buildParam1002);
Monster monster2 = (Monster)monsterBuilder.ConstructFull();

// 生成一只最基本的Monster，不设置属性
var buildParam1003 = new MonsterBuilderParam("monster_1003", "Prefabs/Monster");
monsterBuilder.Reset(buildParam1003);
Monster monster3 = (Monster)monsterBuilder.ConstructMinimal();

// 生成一只宠物,注意 这里因为用了自定义的Param，所以传的参数很精炼
PetBuilderParam petBuilderParam = new PetBuilderParam("pet_1001", "Prefabs/Pet", monster3.gameObject.transform);
PetBuilder petBuilder = new PetBuilder(petBuilderParam);
Pet pet = (Pet)petBuilder.ConstructFull();
```

### when to use | 什么时候用

- 使用生成器模式可避免**重叠构造函数** **（**telescoping constructor）” 的出现。

  ```c#
  class Pizza {
      Pizza(int size) { …… }
      Pizza(int size, boolean cheese) { …… }
      Pizza(int size, boolean cheese, boolean pepperoni) { …… }
      // ……
  ```

  

- **当你希望使用代码创建不同形式的产品** （例如石头或木头房屋）时，可使用建造者器模式。

- 使用建造者模式构造**[组合](https://refactoringguru.cn/design-patterns/composite)**树或其他复杂对象。

### Structure | 模式结构

![](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/02/06/20230206170901.png)



## 其他设计模式

[专题 | Unity3D中的设计模式 | 问渠 (wenqu.site)](https://wenqu.site/Unity-Design-Pattern.html)