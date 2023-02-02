/*** 
 * @Author: NickPansh
 * @Date: 2023-01-28 08:17:17
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-01-30 16:00:08
 * @FilePath: \Unity-Programming-Patterns\Assets\Patterns\3. Observer\Test\Different events\CSharpPublisher.cs
 * @Description: 分别使用C#的delegate，event，EventHandler，Action来实现事件
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WenQu.Observer
{
    public delegate void MyDelegate(MyName myName, MyAge myAge);

    //分别使用C#的delegate，event，EventHandler，Action来实现事件
    public class CSharpPublisher : MonoBehaviour
    {
        // 最原始版本，使用delegate
        // 要先声明一个delegate(line 10)类型，再声明一个delegate对象，很麻烦
        public MyDelegate myDelegate;

        // 改进一些，用EventHandler

        //  C# 内置的 EventHandler，只支持不传参或传一个参，而且这个参数必须继承自EventArgs
        //  https://learn.microsoft.com/zh-cn/dotnet/api/system.eventhandler-1?view=net-7.0
        //  Requires "using System;"
        /// <summary>
        /// 不带参数的EventHandler
        /// </summary>
        public event EventHandler eventUsingEventHandler;
        /// <summary>
        /// 带一个参数的EventHandler
        /// </summary>
        public event EventHandler<InconvenientMyName> eventUsingEventHandlerPlusParam;

        // 再改进一些，用Action

        // C# 内置的 Action，支持传参，一般用这个
        public event Action<MyName, MyAge> eventUsingAction;


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                myDelegate?.Invoke(new MyName("小泥"), new MyAge(17));

                eventUsingEventHandler?.Invoke(this, null);

                eventUsingEventHandlerPlusParam?.Invoke(this, new InconvenientMyName("小泥"));

                eventUsingAction?.Invoke(new MyName("小泥"), new MyAge(17));

            }
        }
    }


    /// <summary>
    /// 复杂的MyName（由于用了EventHandler，传参必须继承自EventArgs)
    /// </summary>
    public class InconvenientMyName : EventArgs
    {
        public string name;

        public InconvenientMyName(string name)
        {
            this.name = name;
        }
    }

    public class MyName : EventArgs
    {
        public string name;

        public MyName(string name)
        {
            this.name = name;
        }
    }

    public class MyAge
    {
        public int age;

        public MyAge(int age)
        {
            this.age = age;
        }
    }
}
