/*** 
 * @Author: NickPansh
 * @Date: 2023-02-16 16:27:15
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-26 10:17:04
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\State\Scripts\Example\EludeState.cs
 * @Description: 闪避阶段
 * @后续可以跟4种状态：Idle,Skill,Max
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.State
{
    public class EludeState : IState<Character>
    {
        // 被打断时长
        // be break duration
        private const float _Break_Accumulation_Duration = 0.5f;

        // 技能2蓄力时长
        // skill 2 accumulation duration
        private const float _Skill_Accumulation_Duration = 2.0f;

        // 蓄力最长时间
        // max accumulation time
        private const float _Max_Accumulation_Time = 3.5f;


        // 累积时间
        // accumulation time
        private float _timeAccumulation = 0f;


        public void OnEnter(Character t)
        {
            t.animator.SetBool(AnimationTriggers.hashIdDefaultElude, true);
        }

        public void OnExit(Character t)
        {
            t.animator.SetBool(AnimationTriggers.hashIdDefaultElude, false);
        }

        public IState<Character> OnUpdate(Character t)
        {
            _timeAccumulation += Time.deltaTime;
            if (_timeAccumulation >= _Max_Accumulation_Time)
            {
                //超时强制释放
                //over max time, force release
                return new UltimateSkillState(3, "Base Layer.UltimateSkill");
            }

            //手指松开，根据蓄力时间决定进入何种状态
            //finger up,  decide which state to enter according to the accumulation time
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                if (_timeAccumulation <= _Break_Accumulation_Duration)
                {
                    //被打断
                    //be break
                    return new IdleState();
                }
                else if (_timeAccumulation <= _Skill_Accumulation_Duration)
                {
                    //技能2蓄力
                    //skill 2 accumulation
                    return new UltimateSkillState(2, "Base Layer.Skill");
                }
                else
                {
                    //超过最大时间，返回Idle状态
                    //over max time, return to idle state
                    return new UltimateSkillState(3, "Base Layer.UltimateSkill");
                }
            }

            return null;
        }
    }
}