/*** 
 * @Author: NickPansh
 * @Date: 2023-01-30 14:26:03
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-15 09:39:52
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\Observer\DifferentEvents\Subscriber.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

namespace WenQu.Observer
{
    public class Subscriber : MonoBehaviour
    {
        public CSharpPublisher publisher_csharp;

        public UnityEventPublisher publisher_unity;
        private void Awake()
        {

            publisher_csharp.myDelegate += DisplayCallUsingCustomDelegate;
            publisher_csharp.eventUsingEventHandler += DisplayCall;
            publisher_csharp.eventUsingEventHandlerPlusParam += DisplayCallWithOneParam;
            publisher_csharp.eventUsingAction += DisplayCallCustomParameters;
            publisher_unity.eventUsingMyUnityEvent.AddListener(DisplayUnityCallMyEvent);
            publisher_unity.eventUsingUnityAction += DisplayUnityCallCustomParameters;

            // 演示event关键字带来的赋值约束

            // 这一行会报错——不允许直接赋值事件
            // The event 'CSharpPublisher.eventUsingEventHandlerPlusParam' can only appear on the left hand side of += or -= (except when used from within the type 'CSharpPublisher')
            // publisher_csharp.eventUsingEventHandlerPlusParam = DisplayCallWithOneParam;
            // 这一行也会报错——不允许直接赋值事件
            // 同上
            // publisher_csharp.eventUsingAction = DisplayCallCustomParameters;
            // 这一行也会报错——不允许直接赋值事件   
            // 同上
            // publisher_unity.eventUsingUnityAction = DisplayUnityCallCustomParameters;

            // 这一行不会报错，所以如果不小心把+=，-=写成了=会很危险
            // publisher_csharp.myDelegate = DisplayCallUsingCustomDelegate;
        }

        #region // 被调用的函数

        private void DisplayCall(object sender, EventArgs args)
        {
            Debug.Log("使用无参EventHandler实现的监听执行");
        }

        private void DisplayCallWithOneParam(object sender, InconvenientMyName args)
        {
            Debug.Log($"使用单参数EventHandler实现的监听执行，传递的参数是 {args.name}");
        }

        private void DisplayCallUsingCustomDelegate(MyName myName, MyAge myAge)
        {
            Debug.Log($"使用自定义Delegate实现的的监听执行，传递的参数是 {myName.name},{myAge.age}");
        }
        private void DisplayCallCustomParameters(MyName myName, MyAge myAge)
        {
            Debug.Log($"使用Action实现的的监听执行，传递的参数是 {myName.name},{myAge.age}");
        }

        private void DisplayUnityCallCustomParameters(MyName myName, MyAge myAge)
        {
            Debug.Log($"使用UnityAction实现的的监听执行，传递的参数是 {myName.name},{myAge.age}");
        }

        public void DisplayUnityCall()
        {
            Debug.Log("使用无参的UnityEvent实现的监听执行");
        }

        public void DisplayUnityCallMyEvent(MyName myName, MyAge myAge)
        {
            Debug.Log($"使用带参数的UnityEvent实现的监听执行，传递的参数是  {myName.name},{myAge.age}");
        }
        #endregion

    }
}