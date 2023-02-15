/*** 
 * @Author: NickPansh
 * @Date: 2023-01-28 11:05:04
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-01-28 12:28:10
 * @FilePath: \Unity-Programming-Patterns\Assets\Patterns\1. Command\Test\Command\LargerCommand.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by NickPansh nickpansh@yeah.net|wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
using WenQu.DesignPattern;
namespace WenQu.Command
{
    public class LargerCommand : AbstractCommand
    {
        // 维持一个对操作对象的引用
        public Transform transform;
        public LargerCommand(Transform transform)
        {
            this.transform = transform;
        }
        public override void Execute()
        {
            this.transform.localScale = this.transform.localScale * 2;
        }

        public override void Undo()
        {
            this.transform.localScale = this.transform.localScale / 2;
        }
    }
}