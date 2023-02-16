/*** 
 * @Author: NickPansh
 * @Date: 2023-02-16 12:53:50
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-16 14:13:39
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\Strategy\Scripts\Example\NPC.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.Strategy
{
    public class NPC
    {
        private AbstractNavPlanner _navPlanner;

        /// <summary>
        /// 设置导航策略
        /// </summary>
        /// <param name="navPlanner"></param>
        public void SetNavPlanner(AbstractNavPlanner navPlanner)
        {
            this._navPlanner = navPlanner;
        }

        /// <summary>
        /// 获取导航路径
        /// </summary>
        /// <param name="startPos"></param>
        /// <param name="endPos"></param>
        /// <returns></returns>
        public Vector3[] GetNavPath(Vector3 startPos, Vector3 endPos)
        {
            return _navPlanner.GetNavPath(startPos, endPos);
        }

    }
}