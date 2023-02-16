/*** 
 * @Author: NickPansh
 * @Date: 2023-02-14 17:00:17
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-16 16:46:47
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

        /// <summary>
        /// 跳跃动作key，一般情况下应该用hashId版本
        /// jump action key, usually use hashId version
        /// </summary>
        public const string kDefaultJump = "Jump";

        /// <summary>
        /// 闪避动作key，一般情况下应该用hashId版本
        /// elude action key, usually use hashId version
        /// </summary>
        public const string kDefaultElude = "Elude";

        /// <summary>
        /// 技能动作key，一般情况下应该用hashId版本
        /// skill action key, usually use hashId version
        /// </summary>
        public const string kDefaultSkill = "NextSkill";

        private static Dictionary<string, int> _cache = new Dictionary<string, int>();

        /// <summary>
        /// 获取动画hashId
        /// get animation hashId
        /// </summary>
        /// <param name="key">动画key</param>
        /// <returns>动画hashId</returns>
        /// <remarks>
        /// 如果缓存中存在，则直接返回，否则通过Animator.StringToHash(key)获取
        /// if the cache exists, return directly, otherwise get it by Animator.StringToHash(key)
        /// </remarks>
        private static int GetHashId(string key)
        {
            int hashId;
            if (_cache.TryGetValue(key, out hashId))
            {
                return hashId;
            }
            else
            {
                hashId = Animator.StringToHash(key);
                _cache.TryAdd(key, hashId);
                return hashId;
            }
        }
        #region hashIds

        /// <summary>
        /// 跳跃动作hashId
        /// hashId of jump action
        /// </summary>
        public static int hashIdDefaultJump { get { return AnimationTriggers.GetHashId(kDefaultJump); } }

        /// <summary>
        /// 闪避动作hashId
        /// hashid of elude action
        /// </summary>
        public static int hashIdDefaultElude { get { return AnimationTriggers.GetHashId(kDefaultElude); } }

        //技能动作hashId
        public static int hashIdDefaultSkill { get { return AnimationTriggers.GetHashId(kDefaultSkill); } }
        #endregion
    }
}