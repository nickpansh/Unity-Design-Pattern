/*** 
 * @Author: NickPansh
 * @Date: 2023-02-15 19:01:51
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-15 19:18:52
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\ChainOfResponsibility\Scripts\Example\SkillPhase4.cs
 * @Description: 技能阶段4
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.ChainOfResponsibility
{
    public class SkillPhase4 : AbstractSkill
    {
        public SkillPhase4(AbstractSkill nextSkill) : base(nextSkill)
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
            return mp >= 80 && mp < 100;
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
                Debug.Log("处理技能阶段4的相关逻辑");
            }
            else
            {
                base.Handle(mp);
            }
        }
    }
}
