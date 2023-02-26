/*** 
 * @Author: NickPansh
 * @Date: 2023-02-14 17:00:17
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-26 09:14:04
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\State\Scripts\Utils\AnimationTriggers.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.State
{
    public class AnimationTriggers
    {
        #region hashIds

        /// <summary>
        /// 跳跃动作hashId
        /// hashId of jump action
        /// </summary>
        public static readonly int hashIdDefaultJump = Animator.StringToHash("Jump");



        /// <summary>
        /// 闪避动作hashId
        /// hashid of elude action
        /// </summary>
        public static readonly int hashIdDefaultElude = Animator.StringToHash("Elude");
        //技能动作hashId
        public static readonly int hashIdDefaultSkill = Animator.StringToHash("NextSkill");

        #endregion

    }
}