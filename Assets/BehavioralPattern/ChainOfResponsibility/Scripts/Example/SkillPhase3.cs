/*** 
 * @Author: NickPansh
 * @Date: 2023-02-15 19:04:26
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-15 19:19:05
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\ChainOfResponsibility\Scripts\Example\SkillPhase3.cs
 * @Description: 技能阶段3
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.ChainOfResponsibility
{
    public class SkillPhase3 : AbstractSkill
    {
        public SkillPhase3(AbstractSkill nextSkill) : base(nextSkill)
        {

        }

        /// <summary>
        /// 能否处理
        /// true or not the skill can be handled
        /// </summary>
        /// <param name="mp"></param>
        /// <returns></returns>
        public override bool CanHandle(float mp)
        {
            return mp >= 50 && mp < 80;
        }
        /// <summary>
        /// 处理技能
        /// handle the skill by mp  value
        /// </summary>
        /// <param name="mp"></param>
        public override void Handle(float mp)
        {
            if (CanHandle(mp))
            {
                //处理相关逻辑
                Debug.Log("处理技能阶段3的相关逻辑");
            }
            else
            {
                base.Handle(mp);
            }
        }
    }
}