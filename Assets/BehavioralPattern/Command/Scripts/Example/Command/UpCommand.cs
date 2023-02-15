/*** 
 * @Author: NickPansh
 * @Date: 2023-02-15 17:48:11
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-15 18:21:51
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\Command\Scripts\Example\Command\UpCommand.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;

namespace WenQu.Command
{
    public class UpCommand : BaseMoveCommand
    {
        public UpCommand(Transform transform) : base(transform)
        {
        }
        /// <summary>
        /// 重新定义方向为前
        /// </summary>
        /// <returns></returns>
        public override Vector3 GetDirection()
        {
            return Vector3.forward;
        }
    }
}