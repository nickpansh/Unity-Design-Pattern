# 模板方法模式

>**模板方法模式**：在一个操作方法中定义算法的流程，其中某些步骤由子类完成。模板方法模式让子类在不变更原有算法**流程**的情况下，还能够重新定义其中的步骤。

**模板方法定义了一个操作中的算法的骨架，而将一些步骤延迟到子类中。**



## 需求&模板方法实现

公司准备研发一个MOBA游戏，派你去制作技能系统。

众所周知，法术能否释放涉及一系列的检查，以下是策划罗列的一些点：

- 先判断CD是否已冷却完毕
- 再判断魔法值是否足够
- 再判断攻击目标是否在技能范围内（非指向性技能无需判断）
- 再判断攻击对象是否还活着（非指向性技能无需判断）

判断结束后，播放技能遵循一定的顺序。

- 先主角PlayAction
- 再播放音效
- 再播放特效

那么首先，定义一个Skill类,再按照技能大类，我们可以划分为指向性技能PointToSkill和ZoneSkill范围技能。

抽象技能类,Execute方法定义了一个执行模板，CanExecute里的IsTargetAlive和isTargetInZone也是模板方法。

```c#
public abstract class Skill
{

    protected float _cd;
    protected Hero _hero;

    public float releaseMp;
    public Skill(Hero hero)
    {
        this._hero = hero;
    }

    protected void Execute(Hero target)
    {
        if (CanExecute(target))
        {
            _hero.PlayAction();
            ShowExecuteEffect();
            PlayExecuteSound();
            _cd = 0;
        }
    }
    /// <summary>
    /// 检查是否可以释放技能
    /// check if the skill can be executed
    /// </summary>
    /// <returns></returns>
    protected bool CanExecute(Hero target)
    {
        if (IsCDAvailable() && IsMPAvailable() && IsTargetAlive(target) && isTargetInZone(target))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 检查技能是否在CD中
    /// check if the skill is in CD
    /// </summary>
    /// <returns></returns>
    protected bool IsCDAvailable()
    {
        return _cd < 0;
    }

    /// <summary>
    /// 检查技能是否消耗的魔法值
    /// check is hero has enough MP to execute the skill
    /// </summary>
    /// <returns></returns>
    protected bool IsMPAvailable()
    {
        return this._hero.mp >= releaseMp;
    }

    /// <summary>
    /// 检查目标是否在技能范围内,这里是模板方法，把具体的判断交给子类
    /// check if the target is in the skill zone, this is a template method, the specific check is delegated to the child class
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    protected abstract bool isTargetInZone(Hero target);

    /// <summary>
    /// 检查目标是否存活,这里是模板方法，把具体的判断交给子类
    /// check if the target is alive, this is a template method, the specific check is delegated to the child class
    /// </summary>
    /// <returns></returns>
    protected abstract bool IsTargetAlive(Hero target);

    /// <summary>
    /// 播放技能音效
    /// play the skill sound
    /// </summary>
    protected abstract void PlayExecuteSound();


    /// <summary>
    /// 播放技能特效
    /// play the skill effect
    /// </summary>
    protected abstract void ShowExecuteEffect();

}
```

指向技能PointSkill

```c#
public class PointToSkill : Skill
{
    float skillDistance;
    public PointToSkill(Hero hero) : base(hero)
    {
        skillDistance = 10;
    }

    /// <summary>
    /// 检查目标是否在技能范围内
    /// check if the target is in skill range
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    protected override bool isTargetInZone(Hero target)
    {
        return Vector3.Distance(target.transform.position, this._hero.transform.position) < skillDistance;
    }

    /// <summary>
    /// 检查目标是否存活
    /// check if the target is alive
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    protected override bool IsTargetAlive(Hero target)
    {
        return target.IsAlive();
    }
    /// <summary>
    /// 播放技能特效
    /// play skill effect
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    protected override void ShowExecuteEffect()
    {
        // 指向技能的特效播放
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// 播放技能音效
    /// play skill sound
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    protected override void PlayExecuteSound()
    {
        // 指向技能的音效播放
        throw new System.NotImplementedException();
    }
}
```



模板方法的方式让我们通过在父类里定义步骤，在子类里实现细节，很好地贯彻了开闭原则。代码也更为清晰了。







## 我见

模板方法用到的也不少。

其实就算不知道模板方法，有一定工作经验的程序员也会自然而然的写出模板方法：
这么设计能较好地把一些步骤延迟到子类中。

##### 模板方法和策略模式

谈模板方法就不得不提策略模式，他们在目的上有一定相似性。

模板方法模式是基于继承允许我们通过拓展子类中的部分内容来改变部分算法。

策略模式是基于组合机制允许我们提供不同的策略来改变对象的部分算法。

一般来说当我想要写模板方法的时候我会先考虑下这个继承是不是合理的……

如果继承是合理的。

再看下是不是需要**定义步骤**,如果是“按一定步骤执行，只需要定义子类细节”的，那就用模板方法。



## 源码

完整代码已上传至[nickpansh/Unity-Design-Pattern | GitHub](https://github.com/nickpansh/Unity-Design-Pattern)

## 其他设计模式

[专题 | Unity3D游戏开发中的设计模式 | 问渠 (wenqu.site)](https://wenqu.site/Unity-Design-Pattern.html)
