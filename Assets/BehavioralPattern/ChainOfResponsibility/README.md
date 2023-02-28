---
title: Unity3D游戏开发设计模式——责任链模式
date: 2022-01-31 17:56:05
categories:
- 心得 | 分享
- 内功
- 设计模式
tags:
- 设计模式

---

<meta name="referrer" content="no-referrer"/>

# 责任链模式


> **责任链模式**：避免将一个请求的发送者与接收者耦合在一起，让多个对象都有机会处理请求。将接受者的对象连接成一条线，并且沿着这条链传递请求，知道有一个对象能够处理它为止。

<!-- more -->

## 结构

责任链的结构比较简单，核心在于引入了一个抽象handle。

![责任链.drawio](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/02/13/%E8%B4%A3%E4%BB%BB%E9%93%BE.drawio.png)



## 需求&差代码

你在开发一款塔防游戏。

现在策划要你制作一个智能塔，长这样：

![image-20230213191716237](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/02/13/image-20230213191716237.png)

这个塔有能量条，会伴随时间自动恢复能量。

它有五个技能阶段：

- 当能量 == 100的时候，会释放AOE
- 当能量介于80-100的时候，释放范围只有一半的AOE
- 当能量介于50-80的时候，一次可以攻击三个敌人
- 当能量介于20-50的时候，一次只可攻击一个敌人，且伤害减半
- 当能量小于20的时候，无法使用

玩家通过点击它，可以触发相应的阶段技能。

策划方案写的很简单，于是你三下无除二就完成了初版：

```c#
if(mp>=100){
    // 省略一堆代码
}else if(mp>= 80){
    // 省略一堆代码
}else if(mp>=50){
    // 省略一堆代码
}else if(mp>=20){
    // 省略一堆代码
}else{
    // do nothing
}
```

五个if，还凑合吧。

刚准备提交，策划说：且慢

![](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/02/13/20230213193034.png)

我们策划组讨论了一下，我要修改一下mp介于20-50的行为：一次可以统计两个敌人，伤害不减半。

好嘛改改改。

```c#
if(mp>=100){
    // 省略一堆代码
}else if(mp>= 80){
    // 省略一堆代码
}else if(mp>=50){
    // 删掉这一段
    // V2版本，新的执行
}else if(mp>=20){
    // 省略一堆代码
}else{
    // do nothing
}
```

刚写完，策划又来了。我们又想改xxxxx。你决定不能这样下去。

每次改代码都小心翼翼地，这个类的逻辑已经很复杂啦，包含5个阶段的各种处理。

稍不留神改动一个阶段就会导致另一个阶段产生bug，不符合开闭原则。

你决定分拆逻辑，把不同的阶段拆到不同的类里去，这样就算新的改动产生bug，也只会影响那一个阶段的改动。

## 好代码（用责任链模式）

抽象技能

```c#
public abstract class AbstractSkill
{
    /// <summary>
    /// 下一个技能
    /// </summary>
    protected AbstractSkill _nextSkill;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="handler"></param>
    /// <returns></returns>
    public AbstractSkill(AbstractSkill nextSkill)
    {
        this._nextSkill = nextSkill;
    }

    /// <summary>
    /// 是否能处理
    /// </summary>
    /// <param name="mp"></param>
    /// <returns></returns>
    public abstract bool CanHandle(float mp);

    /// <summary>
    /// 处理技能
    /// </summary>
    /// <param name="mp"></param>
    public virtual void Handle(float mp)
    {
        if (null != _nextSkill)
        {
            _nextSkill.Handle(mp);
        }
    }


}
```

具体技能

```c#
public class SkillPhase2 : AbstractSkill
{
    public SkillPhase2(AbstractSkill nextSkill) : base(nextSkill)
    {

    }
    /// <summary>
    /// 能否处理
    /// </summary>
    /// <param name="mp"></param>
    /// <returns></returns>
    public override bool CanHandle(float mp)
    {
        return mp >= 20 && mp < 50;
    }
    /// <summary>
    /// 处理技能
    /// </summary>
    /// <param name="mp"></param>
    public override void Handle(float mp)
    {
        if (CanHandle(mp))
        {
            //处理相关逻辑
            Debug.Log("处理技能阶段2的相关逻辑");
        }
        else
        {
            base.Handle(mp);
        }
    }
}
```
组装技能链
```c#
//初始化技能链
SkillPhase1 skillPhase1 = new SkillPhase1(null);
SkillPhase2 skillPhase2 = new SkillPhase2(skillPhase1);
SkillPhase3 skillPhase3 = new SkillPhase3(skillPhase2);
SkillPhase4 skillPhase4 = new SkillPhase4(skillPhase3);
_skillPhase = new SkillPhase5(skillPhase4);
```



## 我见

责任链模式用的也不多，一般用在重构的时候。

而且用不好的话坑非常多。

有的时候做拦截器是不错的选择。



## 责任链优缺点

### 优点

- 一个对象无需知道是其他哪一个对象处理请求，降低了系统耦合。
- 请求对象仅持有一个后继者的引用，而不关心其他，简化了对象之间的连接。
- 再给对象分配指责时，责任链可带来更高灵活性。
- 在系统中增加一个心得具体请求时无需修改原有系统的代码，符合开闭原则。

### 缺点

- 由于一个请求没有明确的接收者，那就不能保证它一定会被处理
- 性能不太好，调试不太方便
- 写错的话循环调用造成死循环


## 其他设计模式

[专题 | Unity3D游戏开发中的设计模式 | 问渠 (wenqu.site)](https://wenqu.site/Unity-Design-Pattern.html)
