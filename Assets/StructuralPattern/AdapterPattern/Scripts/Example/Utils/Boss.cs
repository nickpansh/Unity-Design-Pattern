/*** 
 * @Author: NickPansh
 * @Date: 2023-02-08 18:40:23
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-08 18:43:34
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\AdapterPattern\Scripts\Example\Utils\Boss.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;

namespace WenQu.AdapterPattern
{
    public class Boss : Enemy
    {
        public override void PlayBeHitSound()
        {
            Debug.Log("Play Boss Be Hit Sound");
        }

        public override void PlayDieAction()
        {
            Debug.Log("Play Boss Die Action");
        }
    }
}