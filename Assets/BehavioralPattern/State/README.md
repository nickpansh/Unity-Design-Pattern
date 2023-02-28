# 状态模式

>**状态模式**是一种行为设计模式， 让你能在一个对象的内部状态变化时改变其行为， 使其看上去就像改变了自身所属的类一样。



## 游戏开发中的状态模式

状态模式应用的非常多。就算你不熟悉也应该听过状态机的概念。

即使你没听过状态机你应该也用过Animator，Animator就是状态机的实践。

状态机就是状态模式实现的。

所以本章就直接由游戏中的状态机展开。



### 有限状态机

Demo演示完成一个最基础版本的有限状态机，直接在state里进行状态的切换，未引入State Machine

- 按住左Ctrl蓄力
- 蓄力0.5s 内松开取消蓄力
- 蓄力2.0s 内松开播放技能动作1
- 蓄力2.0s 以上松开播放技能动作2
- 蓄力超过3.5s 播放技能动作2
- 点击空格跳跃

抽象

```c#
public interface IState
{
    public IState OnUpdate(Character t);
    public void OnEnter(Character t);
    public void OnExit(Character t);
}
```

状态机的关键在于控制状态的切换，这里直接在Character里进行相关逻辑控制。

```c#
public class Character : MonoBehaviour
{
    public Animator animator;
    protected IState state;

    public virtual void Update()
    {
        if (null != state)
        {
            IState newState = state.OnUpdate(this);
            //状态切换
            //state switch
            if (null != newState)
            {
                TransitionState(newState);
            }
        }
    }

    /// <summary>
    /// 状态切换
    /// Transition state
    /// </summary>
    /// <param name="newState"></param>
    public void TransitionState(IState newState)
    {
        Debug.Log($"状态变更{newState}");
        newState.OnEnter(this);

        if (null != state)
            state.OnExit(this);
        state = newState;
    }
}
```

演示一个技能类

```c#
public class UltimateSkillState : IState
{
    private int _fullPathHash;
    private int _skillId;
    private float _dt = 0;

    private int _prevHashId = 0;
    public void OnEnter(Character t)
    {
        _dt = 0;
        t.animator.SetInteger(AnimationTriggers.hashIdDefaultSkill, _skillId);

    }
    /// <summary>
    /// 构造
    /// </summary>
    /// <param name="skillId">技能id</param>
    /// <param name="animatorFullPath">动画全路径（如Base Layer.Jump)</param>
    public UltimateSkillState(int skillId, string animatorFullPath)
    {
        _skillId = skillId;
        _fullPathHash = Animator.StringToHash(animatorFullPath);
    }


    public void OnExit(Character t)
    {
        var _animatorStateInfo = t.animator.GetCurrentAnimatorStateInfo(0);
        //恢复默认技能
        t.animator.SetInteger(AnimationTriggers.hashIdDefaultSkill, 0);

    }

    public IState OnUpdate(Character t)
    {
        _dt += Time.deltaTime;
        var _animatorStateInfo = t.animator.GetCurrentAnimatorStateInfo(0);

        //技能播放完毕的判定依据是先播放指定动画，然后再播放到任意其他动作
        if (_prevHashId == 0)
        {
            _prevHashId = t.animator.GetCurrentAnimatorStateInfo(0).fullPathHash == _fullPathHash ? _fullPathHash : 0;
        }
        else
        {
            if (t.animator.GetCurrentAnimatorStateInfo(0).fullPathHash != _prevHashId)
            {
                //技能播放完毕
                return new IdleState();
            }
        }

        return null;
    }
}
```

最终效果

![](https://pic.wenqu.space/uploads/2023/02/16/StateMachine.gif)

## 更多

有限状态机还有一些衍生的设计。
如状态翻转，全局状态，分层状态机等。
代码在FSMExample里，具体的介绍限于篇幅这里不展开，感兴趣的可以查看[UnityAI专题—有限状态机](https://www.wenqu.site/UnityAI%E4%B8%93%E9%A2%98-%E6%9C%89%E9%99%90%E7%8A%B6%E6%80%81%E6%9C%BA.html)


## 其他设计模式

[专题 | Unity3D游戏开发中的设计模式 | 问渠 (wenqu.site)](https://wenqu.site/Unity-Design-Pattern.html)
