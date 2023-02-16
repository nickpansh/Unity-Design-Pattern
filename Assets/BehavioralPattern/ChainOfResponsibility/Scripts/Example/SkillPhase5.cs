/*** 
 * @Author: NickPansh
 * @Date: 2023-02-13 19:51:47
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-15 19:02:43
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\ChainOfResponsibility\Scripts\Example\SkillPhase5.cs
 * @Description: 技能阶段5
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.ChainOfResponsibility
{
    public class SkillPhase5 : AbstractSkill
    {
        public SkillPhase5(AbstractSkill nextSkill) : base(nextSkill)
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
            return mp >= 100;
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
                Debug.Log("处理技能阶段5的相关逻辑");
            }
            {
                base.Handle(mp);
            }
        }
    }
}