/*** 
 * @Author: NickPansh
 * @Date: 2023-02-08 18:41:34
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-08 18:43:28
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\AdapterPattern\Scripts\Example\Utils\DogFace.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;

namespace WenQu.AdapterPattern
{
    public class DogFace : Enemy
    {
        public override void PlayBeHitSound()
        {
            Debug.Log("Play DogFace Be Hit Sound");
        }

        public override void PlayDieAction()
        {
            Debug.Log("Play DogFace Die Action");
        }
    }
}