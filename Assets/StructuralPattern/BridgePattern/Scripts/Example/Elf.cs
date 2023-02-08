/*** 
 * @Author: NickPansh
 * @Date: 2023-02-08 17:29:50
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-08 17:42:15
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\BridgePattern\Scripts\Example\Elf.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.BridgePattern
{
    public class Elf : Character
    {
        public override void NavTo(Vector3 pos)
        {
            Vector3[] paths = this.movable.CalcNavPath(pos);
            string prefix = this.movable as Flyable == null ? "Walk" : "Fly";
            foreach (var path in paths)
            {
                Debug.Log($"{prefix}Elf移动到{path}");
            }
        }
    }
}