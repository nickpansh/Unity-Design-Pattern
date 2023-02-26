/*** 
 * @Author: NickPansh
 * @Date: 2023-02-26 10:13:59
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-26 10:17:18
 * @FilePath: \Unity-Design-Pattern\Assets\Scripts\DesignPattern\IStateTemplate.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.State
{
    /// <summary>
    /// 泛型状态接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IState<T>
    {
        public IState<T> OnUpdate(T t);
        public void OnEnter(T t);
        public void OnExit(T t);
    }
}