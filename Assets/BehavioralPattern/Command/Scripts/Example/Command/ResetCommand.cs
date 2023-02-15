/*** 
 * @Author: NickPansh
 * @Date: 2023-01-28 13:06:54
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-01-28 13:06:55
 * @FilePath: \Unity-Programming-Patterns\Assets\Patterns\1. Command\Test\Command\ResetCommand.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by NickPansh nickpansh@yeah.net|wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
using WenQu.DesignPattern;
namespace WenQu.Command
{
    public class ResetCommand : AbstractCommand
    {
        // 维持一个对操作对象的引用
        public Transform transform;
        // 构造方法
        public ResetCommand(Transform transform)
        {
            this.transform = transform;
        }
        public override void Execute()
        {
            this.transform.localScale = Vector3.one;
            this.transform.localEulerAngles = Vector3.zero;
        }
        public override void Undo()
        {
            throw new System.NotImplementedException();
        }
    }
}