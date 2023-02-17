/*** 
 * @Author: NickPansh
 * @Date: 2023-02-17 10:11:29
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-17 10:59:31
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\TemplateMethod\Example\Skill\PointToSkill.cs
 * @Description: 指向技能
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.TemplateMethod
{
    public class PointToSkill : Skill
    {
        float skillDistance;
        public PointToSkill(Hero hero, float mp, float skillDistance) : base(hero, mp)
        {
            this.skillDistance = skillDistance;
        }

        /// <summary>
        /// 检查目标是否在技能范围内
        /// check if the target is in skill range
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        protected override bool isTargetInZone(Hero target)
        {
            return Vector3.Distance(target.transform.position, this._hero.transform.position) < skillDistance;
        }

        /// <summary>
        /// 检查目标是否存活
        /// check if the target is alive
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        protected override bool IsTargetAlive(Hero target)
        {
            return target.IsAlive();
        }
        /// <summary>
        /// 播放技能特效
        /// play skill effect
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void ShowExecuteEffect()
        {
            // 指向技能的特效播放
            // throw new System.NotImplementedException();
        }

        /// <summary>
        /// 播放技能音效
        /// play skill sound
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void PlayExecuteSound()
        {
            // 指向技能的音效播放
            // throw new System.NotImplementedException();
        }
    }
}