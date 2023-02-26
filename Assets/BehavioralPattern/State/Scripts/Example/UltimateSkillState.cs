/*** 
 * @Author: NickPansh
 * @Date: 2023-02-16 17:12:50
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-26 10:16:02
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\State\Scripts\Example\UltimateSkillState.cs
 * @Description: 蓄力后大招状态
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

namespace WenQu.State
{
    public class UltimateSkillState : IState<Character>
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

        public IState<Character> OnUpdate(Character t)
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
}