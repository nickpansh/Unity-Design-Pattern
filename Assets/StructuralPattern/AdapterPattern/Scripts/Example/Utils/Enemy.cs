/*** 
 * @Author: NickPansh
 * @Date: 2023-02-08 18:35:16
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-08 18:40:16
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\AdapterPattern\Scripts\Example\Utils\Enemy.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.AdapterPattern
{
    public abstract class Enemy : Character
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void BeAttack()
        {
            Debug.Log("被攻击!");
        }

        public abstract void PlayBeHitSound();
        public abstract void PlayDieAction();
    }
}