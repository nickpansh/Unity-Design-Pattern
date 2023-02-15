/*** 
 * @Author: NickPansh
 * @Date: 2023-02-15 17:48:03
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-15 17:49:04
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\Command\Scripts\Example\Command\RightCommand.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.Command
{
    public class RightCommand : BaseMoveCommand
    {
        public RightCommand(Transform transform) : base(transform)
        {
        }
        /// <summary>
        /// 重新定义方向为右
        /// </summary>
        /// <returns></returns>
        public override Vector3 GetDirection()
        {
            return Vector3.right;
        }
    }
}