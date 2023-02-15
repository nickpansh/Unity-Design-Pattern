/*** 
 * @Author: NickPansh
 * @Date: 2023-01-28 12:35:53
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-01-28 12:40:49
 * @FilePath: \Unity-Programming-Patterns\Assets\Patterns\1. Command\Test\Command\FlipCommand.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by NickPansh nickpansh@yeah.net|wenqu.site, All Rights Reserved. 
 */
using WenQu.DesignPattern;
using UnityEngine;
namespace WenQu.Command
{
    public class RotateRight : AbstractCommand
    {
        // 维持一个对操作对象的引用
        public Transform transform;
        public RotateRight(Transform transform)
        {
            this.transform = transform;
        }
        public override void Execute()
        {
            this.transform.Rotate(new Vector3(0, 90, 0));
        }

        public override void Undo()
        {
            this.transform.Rotate(new Vector3(0, -90, 0));
        }
    }
}