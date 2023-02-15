/*** 
 * @Author: NickPansh
 * @Date: 2023-02-15 17:12:10
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-15 18:04:20
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\Command\Scripts\Example\Command\RotateLeftCommand.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WenQu.DesignPattern;
namespace WenQu.Command
{
    public class RotateLeft : AbstractCommand
    {
        // 维持一个对操作对象的引用
        public Transform transform;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="transform"> </param>
        public RotateLeft(Transform transform)
        {
            this.transform = transform;
        }
        /// <summary>
        /// 执行
        /// </summary>
        public override void Execute()
        {
            this.transform.Rotate(new Vector3(0, -90, 0));
        }
        /// <summary>
        /// 撤销
        /// </summary>
        public override void Undo()
        {
            this.transform.Rotate(new Vector3(0, 90, 0));
        }
    }
}