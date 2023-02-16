/*** 
 * @Author: NickPansh
 * @Date: 2023-02-14 14:16:30
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-16 21:22:49
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\State\Scripts\Utils\IMovable.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.State
{
    public interface IMovable
    {
        public void Move(Vector3 velocity);
        public void Move(float x, float y, float z);

    }
}