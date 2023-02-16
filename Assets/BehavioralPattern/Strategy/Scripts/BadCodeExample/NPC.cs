/*** 
 * @Author: NickPansh
 * @Date: 2023-02-16 12:37:02
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-16 21:22:29
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\Strategy\Scripts\BadCodeExample\NPC.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.Strategy.BadCodeExample
{
    public enum NPCType
    {
        /// <summary>
        /// 飞行
        /// </summary>
        Fly,
        /// <summary>
        /// 游泳
        /// </summary>
        Swim,
        /// <summary>
        /// 跳跃
        /// </summary>
        Jump,
        /// <summary>
        /// 直线行走
        /// </summary>
        StraightWalk,
    }
    public class NPC : MonoBehaviour
    {
        private NPCType npcType;

        void Start()
        {

        }

        public Vector3[] GetNavPath()
        {
            switch (npcType)
            {
                case NPCType.Fly:
                    return GetFlyPath();
                case NPCType.Swim:
                    return GetSwimPath();
                case NPCType.Jump:
                    return GetJumpPath();
                case NPCType.StraightWalk:
                    return GetStraightWalkPath();
                default:
                    return null;
            }
        }

        private Vector3[] GetFlyPath()
        {
            return null;
        }

        private Vector3[] GetSwimPath()
        {
            return null;
        }

        private Vector3[] GetJumpPath()
        {
            return null;
        }

        private Vector3[] GetStraightWalkPath()
        {
            return null;
        }
    }

}