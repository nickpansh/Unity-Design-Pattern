/*** 
 * @Author: NickPansh
 * @Date: 2023-01-28 12:29:24
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-15 17:14:06
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\Command\Scripts\Example\Command\SmallerCommand.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by NickPansh nickpansh@yeah.net|wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
using WenQu.DesignPattern;
namespace WenQu.Command
{
    public class SmallerCommand : AbstractCommand
    {
        // 维持一个对操作对象的引用
        public Transform transform;
        public SmallerCommand(Transform transform)
        {
            this.transform = transform;
        }
        public override void Execute()
        {
            this.transform.localScale = this.transform.localScale / 2;
        }

        public override void Undo()
        {
            this.transform.localScale = this.transform.localScale * 2;
        }
    }
}