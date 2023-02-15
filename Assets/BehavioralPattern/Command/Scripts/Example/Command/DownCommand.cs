/*** 
 * @Author: NickPansh
 * @Date: 2023-02-15 17:48:16
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-15 18:23:04
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\Command\Scripts\Example\Command\DownCommand.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.Command
{
    public class DownCommand : BaseMoveCommand
    {
        public DownCommand(Transform transform) : base(transform)
        {
        }
        //重新定义方向为后
        public override Vector3 GetDirection()
        {
            return Vector3.back;
        }
    }
}