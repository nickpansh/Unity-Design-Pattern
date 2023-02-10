## Brief | 概要

> **适配器模式**： 将一个类的接口转换成客户希望的另一个接口。适配器模式让那些接口不兼容的类可以一起工作。

适配器模式包括类适配器和对象适配器。

在对象适配器模式中，适配器与适配者是关联关系。

在类适配器模式中，适配器与适配者是继承关系。

适配器模式更多的是强调对代码的阻止，而不是功能的实现。

在实际开发中，对象适配器模式用的更多。


### The Question | 需求

假设我们在开发一个横屏过关游戏。

玩家携带宠物Pet对抗敌人Enemy。

策划提了一个需求：场景中有一个Boss名字叫动物之灵，当宠物见到他以后，会失去心智——变成他的宠物！从而变成一个敌人来攻击玩家！

代码不难写啊，大概就是当这个boss出现的时候，把pet对象加入Enemy数组。

问题来了——Pet类没有几个Enemy应该有的关键方法啊！

- PlayBeHitSound()

    播放受击音乐（策划说调用一下PlayUnHappySound方法就行了）

- PlayDieAction()

    播放死亡动作（策划说调用一下PlaySleepAction方法就好了）

- BeAttack（）受击打

    （策划说跟其他的Enemy受击打一样就行了啊）

    策划甚至说：你Pet类继承Enemy，然后加这些方法咯。（有这么专业的策划吗？）

问题来了……Pet已经继承Character了，这也没法多重继承啊。

总不能把Enemy改成IAttackable接口吧……那样现有的类改动到天明都改不完。

（或者Pet类已经是屎山了/Pet类代码是dll找不到源文件无法修改了，总之，你有各种各样的原因不能去修改Pet类的源代码）

怎么办呢？

当然是引进适配器模式啦！

**将一个类的接口转换成客户希望的另一个接口。适配器模式让那些接口不兼容的类可以一起工作。**

### Good Code Example | 好代码（用适配器模式实现需求）

PetEnemyAdapter.cs的代码如下：
```c#
public class PetEnemyAdapter : Enemy
{
    public Pet pet;
    public PetEnemyAdapter(Pet pet)
    {
        this.pet = pet;
    }

    public override void PlayBeHitSound()
    {
        pet.PlayUnHappySound();
    }

    public override void PlayDieAction()
    {
        pet.PlaySleepAction();
    }
}
```
当我们要使用Pet作为Enemy的时候，用PetEnemyAdapter：

```c#
PetEnemyAdapter adapter = new PetEnemyAdapter(pet);
enemies.Add(adapter);
```

由此我们就实现了不修改Pet类，也能拓展Pet。

## How To Use | 怎么用

适配器模式在使用上非常简单：当有一个类与预期使用的接口不同时，就实现一个适配器类，使用这个适配器将不合的类转成预期的类接口。

## When To Use | 什么时候用

- 适配器模式在 C# 代码中很常见。 基于一些遗留代码的系统常常会使用该模式。 在这种情况下， 适配器让遗留代码与现代的类得以相互合作。

- 购买了一些第三方类库或者插件，但是没有源码/是类库的命名规范和自己的很不一致/有很多怪异接口，这时候就可以用适配器模式包装一下，作为这些接口的转换器。

## 其他设计模式

[专题 | Unity3D中的设计模式 | 问渠 (wenqu.site)](https://wenqu.site/Unity-Design-Pattern.html)