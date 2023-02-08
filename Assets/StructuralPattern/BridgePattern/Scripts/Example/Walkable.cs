/*** 
 * @Author: NickPansh
 * @Date: 2023-02-08 17:30:58
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-08 17:48:29
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\BridgePattern\Scripts\Example\Walkable.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.BridgePattern
{
    public class Walkable : IMovable
    {
        public Vector3[] CalcNavPath(Vector3 pos)
        {
            // 伪代码：去掉天空路径，返回地面中路径
            // 这里直接返回一点假的路径
            return new Vector3[3] { Vector3.zero, (Vector3.back) * 5, pos };
        }
    }

}