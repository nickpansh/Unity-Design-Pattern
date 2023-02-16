/*** 
 * @Author: NickPansh
 * @Date: 2023-02-14 14:05:13
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-16 16:41:15
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\State\Scripts\IState.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WenQu.State
{
    public interface IState
    {
        public IState OnUpdate(Character t);
        public void OnEnter(Character t);
        public void OnExit(Character t);


    }
}