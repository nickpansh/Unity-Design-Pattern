/*** 
 * @Author: NickPansh
 * @Date: 2023-01-30 15:34:19
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-01-31 13:05:05
 * @FilePath: \Unity-Design-Pattern\Assets\Observer\Different events\UnityEventPublisher.cs
 * @Description:  使用Unity事件实现的Publisher
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System;
using UnityEngine;
using UnityEngine.Events;
namespace WenQu.Observer
{
    [Serializable]
    public class MyUnityEvent : UnityEvent<MyName, MyAge>
    {
        // 不用实现
    }
    public class UnityEventPublisher : MonoBehaviour
    {
        // UnityAction 本质上是delegate
        public event UnityAction<MyName, MyAge> eventUsingUnityAction;
        // UnityEvent本质上是一个类，有AddListener方法，可以在界面上拖。
        // 不带参数的UnityEvent，可以在编辑器里直接拖，这里demo演示直接拖。
        public UnityEvent eventUsingUnityEvent;
        // 带参数的UnityEvent，可以在编辑器里直接拖，这里的demo演示时不拖，用代码实现。
        public MyUnityEvent eventUsingMyUnityEvent;
        private void Awake()
        {


        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                eventUsingUnityEvent?.Invoke();
                eventUsingMyUnityEvent?.Invoke(new MyName("小泥"), new MyAge(17));
                eventUsingUnityAction?.Invoke(new MyName("小泥"), new MyAge(17));
            }
        }
    }
}