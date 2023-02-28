<!--
 * @Author: NickPansh
 * @Date: 2023-02-16 14:15:46
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-16 14:24:50
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\Strategy\Scripts\README.md
 * @Description: 
 * 
 * Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
-->
# 策略模式

![设计模式](https://pic.wenqu.space/uploads/2023/02/16/%E8%AE%BE%E8%AE%A1%E6%A8%A1%E5%BC%8F.png)

> **策略模式**：定义一系列算法，将每个算法封装起来，并让他们可以相互替换。策略模式让算法可以独立于使用它的客户变化。

策略模式实现了算法定义和算法使用的分离，通过继承和多态的机制实现对算法族的使用和管理。

<!-- more -->



## 结构

![image-20230216114040669](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/02/16/image-20230216114040669.png)



## 我见

策略模式很好地解耦了算法的实现与使用。

但是带来的影响是类的膨胀。因此也有不少人说有Lambda表达式就没必要用策略模式了。

个人觉得这是一个误区——

使用策略模式之前应该清楚，这个**算法究竟是否可复用**

若是可复用的算法，使用面向对象版本的策略模式吧

若是不可复用的算法，用Lambda表达式版本的策略模式就好

二者没有谁强





## 需求&差代码



在你的游戏中，有很多类型的NPC。

有的会飞，有的会有用，有的会跳跃，有的只会研直线走。

需要你用代码实现CalcNavPoints（）方法，返回寻路路径。

直接跳过继承四个FlyNPC，SwimingNPC，JumpNPC，StraightNPC类的想法啊……多用组合而不是继承，记住这个原则。



可以考虑把这四个方法都写成private方法，在Npc里实现。

根据NPC的对象决定具体用哪个方法。

```c#
 public class NPC : MonoBehaviour
{
    public NPCType npcType;

    void Start()
    {

    }

    public Vector3[] GetNavPath()
    {
        switch (npcType)
        {
            case NPCType.Fly:
                return GetFlyPath();
            case NPCType.Swim:
                return GetSwimPath();
            case NPCType.Jump:
                return GetJumpPath();
            case NPCType.StraightWalk:
                return GetStraightWalkPath();
            default:
                return null;
        }
    }

    private Vector3[] GetFlyPath()
    {
        return null;
    }

    private Vector3[] GetSwimPath()
    {
        return null;
    }

    private Vector3[] GetJumpPath()
    {
        return null;
    }

    private Vector3[] GetStraightWalkPath()
    {
        return null;
    }
}
```

能实现需求，但：

- 对修改不友好。策划要求跳过一些swim的路径点，你得改NPC这个类。
- NPC类负担过重。NPC还要承担很多职能，光实现寻路就轻轻松松几百行。

你应该能想到了，我们要把寻路的这些算法给分拆出去。

我们可以考虑用一个NavHelper类来承载这部分逻辑。

这可以解决NPC类负担过重的问题，但没解决第一个问题—要修改一种寻路，依旧要改整个NPCHelper。

**现在我们尝试引进策略者模式将寻路的算法与寻路的调用解耦，并实现寻路算法对拓展开放，对修改关闭。**

## 好的实现（用策略模式实现需求）

定义一个抽象算法类AbstractNavPlanner

```c#
using UnityEngine;
namespace WenQu.Strategy
{
    public abstract class AbstractNavPlanner
    {
        /// <summary>
        /// 获得导航路径
        /// </summary>
        /// <returns></returns>
        public abstract Vector3[] GetNavPath(Vector3 startPos, Vector3 endPos);
    }
}
```

具体算法类距离SwimNavPlanner

```c#
namespace WenQu.Strategy
{
    public class SwimNavPlanner : AbstractNavPlanner
    {
        public override Vector3[] GetNavPath(Vector3 startPos, Vector3 endPos)
        {
            return new Vector3[] { startPos, startPos + endPos / 2 + Vector3.up * -5, endPos };
        }
    }
}
```

算法类调用者NPC类

```c#
namespace WenQu.Strategy
{
    public class NPC
    {
        private AbstractNavPlanner _navPlanner;
        void Start()
        {

        }

        public void SetNavPlanner(AbstractNavPlanner navPlanner)
        {
            this._navPlanner = navPlanner;
        }

        public Vector3[] GetNavPath(Vector3 startPos, Vector3 endPos)
        {
            return _navPlanner.GetNavPath(startPos, endPos);
        }
    }
}
```

调用

```c#
Vector3 startPos = this.transform.position;
Vector3 endPos = new Vector3(10, 0, 10);
// 飞行npc
NPC theFlyNPC = new NPC();
// 这里可以引入建造者模式来分离构造与调用
theFlyNPC.SetNavPlanner(new FlyNavPlanner());

Vector3[] navPaths = theFlyNPC.GetNavPath(startPos, endPos);
foreach (Vector3 navPath in navPaths)
{
    Debug.Log($"flyNpc规划的路径是:{navPath}");
}
```

至此功能实现。





## 再进一步

前面的策略模式实现的很好，是建立在策略可以复用的情况下的。（这些寻路策略对玩家，宠物等同样适用）

很多情况下，我们的一些策略并不需要复用。

那就不需要面向对象提取出那么多类了。

而我们又需要动态地去修改一些算法，怎么办？

可以用Lambda表达式实现策略。



举个例子。

还是类似寻路的要求，要求提供一个SamplePos()方法，功能是把一个点映射到地图上。

只有swimNPC需要被映射到地图下方，其他都是返回原值。

按照策略模式去写的话很麻烦，演示下Lambda表达式。

使用函数委托接收策略

```c#
public class LambdaNPC
{
    private Func<Vector3, Vector3> _sampleStrategy;

    public void SetSampleStrategy(Func<Vector3, Vector3> sampleStrategy)
    {
        this._sampleStrategy = sampleStrategy;
    }

    public Vector3 SamplePos(Vector3 pos)
    {
        return this._sampleStrategy(pos);
    }
}
```



调用

```c#
// 调用
LambdaNPC swimNPC2 = new LambdaNPC();
// 传递一个lambda表达式策略
swimNPC2.SetSampleStrategy((pos) =>
{
    return new Vector3(pos.x, 0, pos.z);
});
```



使用Lambda表达式实现策略模式让我们少写了好多类。

是个很好的实践。


## 其他设计模式

[专题 | Unity3D游戏开发中的设计模式 | 问渠 (wenqu.site)](https://wenqu.site/Unity-Design-Pattern.html)