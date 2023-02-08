/*** 
 * @Author: NickPansh
 * @Date: 2023-02-08 18:36:59
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-08 18:37:16
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\AdapterPattern\Scripts\Example\Utils\Pet.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.AdapterPattern
{
    public class Pet : Character
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void PlayUnHappySound()
        {
            Debug.Log("Play Pet UnHappy Sound");
        }

        public void PlaySleepAction()
        {
            Debug.Log("Play Pet Sleep Sound");
        }
    }
}