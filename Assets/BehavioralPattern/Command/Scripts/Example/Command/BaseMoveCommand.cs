/*** 
 * @Author: NickPansh
 * @Date: 2023-02-15 17:22:43
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-15 18:26:39
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\Command\Scripts\Example\Command\BaseMoveCommand.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */

using UnityEngine;
using WenQu.DesignPattern;
namespace WenQu.Command
{
    public class BaseMoveCommand : AbstractCommand
    {
        /// <summary>
        /// 移动的时间间隔
        /// </summary>
        protected static float duration = 1.0f;

        /// <summary>
        /// 移动的距离
        /// </summary>
        private static int scaler = 5;

        // 维持一个对操作对象的引用
        public Transform transform;
        public virtual Vector3 GetDirection()
        {
            return Vector3.zero;
        }
        public BaseMoveCommand(Transform transform)
        {
            this.transform = transform;
        }
        public override void Execute()
        {
            // 移动=原始位置+方向*距离
            this.transform.localPosition = Vector3.MoveTowards(this.transform.position, GetDirection() * scaler, duration);
        }

        public override void Undo()
        {
            // 相反方向移动
            this.transform.localPosition = Vector3.MoveTowards(this.transform.position, -GetDirection() * scaler, duration);
        }
    }
}