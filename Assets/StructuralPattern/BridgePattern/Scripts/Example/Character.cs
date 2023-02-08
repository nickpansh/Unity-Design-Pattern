/*** 
 * @Author: NickPansh
 * @Date: 2023-02-08 17:28:34
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-08 17:57:02
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\BridgePattern\Scripts\Example\Character.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.BridgePattern
{
    public abstract class Character
    {
        public IMovable movable { get; set; }
        public abstract void NavTo(Vector3 pos);
    }
}