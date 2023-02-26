/*** 
 * @Author: NickPansh
 * @Date: 2023-02-14 15:00:23
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-26 10:15:52
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\State\Scripts\Example\JumpState.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
using UnityEngine.Assertions;

namespace WenQu.State
{
    public class JumpState : IState<Character>
    {
        private int _fullPathHash = Animator.StringToHash("Base Layer.Jump");
        private int _prevHashId = 0;
        public void OnEnter(Character character)
        {
            Assert.IsNotNull(character as IJumpable);
            (character as IJumpable).Jump();
            character.animator.Play(AnimationTriggers.hashIdDefaultJump);
        }

        public void OnExit(Character character)
        {
            //Do Nothing
        }

        public IState<Character> OnUpdate(Character character)
        {
            AnimatorStateInfo animatorStateInfo = character.animator.GetCurrentAnimatorStateInfo(0);

            // 只要开始播放Jump->Idle的过渡动画，就认为跳跃结束
            // as long as the transition animation from Jump to Idle starts, we think the jump is over
            if (_prevHashId == 0)
            {
                _prevHashId = animatorStateInfo.fullPathHash == _fullPathHash ? _fullPathHash : 0;
            }
            else
            {
                if (character.animator.IsInTransition(0))
                {
                    return new IdleState();
                }
            }
            return null;
        }
    }
}