/*** 
 * @Author: NickPansh
 * @Date: 2023-02-08 17:29:57
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-08 17:42:29
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\BridgePattern\Scripts\Example\Npc.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.BridgePattern
{
    public class Npc : Character
    {
        public override void NavTo(Vector3 pos)
        {
            Vector3[] paths = this.movable.CalcNavPath(pos);
            foreach (var path in paths)
            {
                Debug.Log($"Elf移动到{path}");
            }
            Debug.Log("NPC移动完成转个圈");
        }
    }

}
