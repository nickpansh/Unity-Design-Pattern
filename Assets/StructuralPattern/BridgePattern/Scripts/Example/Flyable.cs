/*** 
 * @Author: NickPansh
 * @Date: 2023-02-08 17:30:45
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-08 17:48:13
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\BridgePattern\Scripts\Example\Flyable.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.BridgePattern
{
    public class Flyable : IMovable
    {
        public Vector3[] CalcNavPath(Vector3 pos)
        {
            // 伪代码：去掉陆地路径，返回天空中路径
            // 这里直接返回一点假的路径
            return new Vector3[3] { Vector3.up * 5, (Vector3.up + Vector3.back) * 5, pos };
        }
    }
}