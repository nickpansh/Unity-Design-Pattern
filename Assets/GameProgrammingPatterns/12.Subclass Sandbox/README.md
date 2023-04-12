## Unity设计模式—子类沙盒

> 一个基类定义了一个抽象的沙河方法和一些预定义的操作集合。通过将它们设置为受保护的状态已确定它们仅供子类使用。每个派生的沙盒子类根据父类提供的操作来实现沙盒操作。

子类沙盒的名字比较生僻，其实内容非常常见，平常用的很多，而且往往是已经用上了。

如果你在定义一个抽象方法，这个类中又有这个抽象方法在子类实现时要调用的的非抽象方法，那你就已经在使用这个模式了。



这种设计模式出现的背景是纵深长的继承树非常难用，比不上扁平的继承树。

**核心是使用基类提供的操作集合来定义子类中的行为。**



## 实现

父类负责实现，并提供抽象方法让子类去实现。

```c#
public abstract class SuperPower
{

    public abstract void Activate();
    protected void Move(float x, float y, float z)
    {
        Debug.Log("Move to " + x + "," + y + "," + z);
    }

    protected float GetPosY()
    {
        return 0;
    }

    protected void PlaySound(string soundName)
    {
        Debug.Log("Play sound " + soundName);
    }

    protected void SpawnParticles(string particleName)
    {
        Debug.Log("Spawn particles " + particleName);
    }
}
```

子类调用父类方法。

```c#
public class SkyLaunch : SuperPower
{
    public override void Activate()
    {
        if (GetPosY() == 0)
        {
            PlaySound("Sound_SPRONING");
            SpawnParticles("Particles_DUST");
            Move(0, 100, 0);
        }
        else if (GetPosY() < 10.0f)
        {
            PlaySound("Sound_FLYING");
            Move(0, 0, 10);
        }
        else
        {
            PlaySound("Sound_LANDING");
            SpawnParticles("Particles_DUST");
            Move(0, 0, 0);
        }
    }
}
```





## 设计决策

子类沙盒模式是一个“温和的”，及其简单的设计模式。

关注点在于设计思想以及一些具体的设计决策。

我们应通过设计缓解最终基类塞满了方法的窘境。



#### 什么时候用

- 你有一个带有大量子类的基类
- 基类能够提供所有子类可能需要执行的操作集合
- 在子类之间有重叠的代码，你希望在他们之间更简便地共享代码
- 你希望使这些继承类与程序其他代码之间的耦合最小化



#### 基类提供什么操作

- 如果操作只被一个或少数几个子类锁使用，不必把操作放入基类。

  这将增加基类的复杂度，同时影响所有子类，却只有少数几个子类从中受益。

  可以考虑搭配使用组件模式，子类直接调用外部系统

- 如果提供的操作仅仅是对一些外部系统进行简单的二次封装，那么也不比把操作放入基类。



#### 考虑转移操作

将一系列相同的操作转移到其他类中，可以缓解基类的臃肿。



#### 基类如何获取所需的状态

如何传入对象给基类，又不暴露给子类？

- 将对象静态化，在较早的位置调用父类的Init方法传入对象即可。
- 使用服务定位器



#### 其他要点

- 模板方法模式和子类沙盒模式正好相反

​		模板方法模式是在父类定义函数骨干，在子类进行实现

​		而子类沙盒模式是把实现放在父类，函数在子类中



## 其他设计模式

[专题 | Unity3D游戏开发中的设计模式 | 问渠 (wenqu.site)](https://wenqu.site/Unity-Design-Pattern.html)