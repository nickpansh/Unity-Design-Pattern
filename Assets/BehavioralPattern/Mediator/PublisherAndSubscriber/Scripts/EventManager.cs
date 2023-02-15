/*** 
 * @Author: NickPansh
 * @Date: 2023-02-15 10:20:37
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-15 14:10:03
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\Mediator\PublisherAndSubscriber\Scripts\EventManager.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.Assertions;
using UnityEngine.Events;

namespace WenQu.Mediator
{
    public class EventParams
    {
        private Dictionary<string, object> _dict;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="isNoParameters">if is no parameters</param>
        public EventParams(bool isNoParameters = false)
        {
            if (!isNoParameters)
                _dict = new Dictionary<string, object>();
        }


        /// <summary>
        /// put value into dict
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">key name</param>
        /// <param name="value">value of key</param>
        public void Put<T>(string key, T value)
        {
            _dict.Add(key, value);
        }

        /// <summary>
        /// get value of key in dict
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">key name</param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            _dict.TryGetValue(key, out var result);
            Assert.IsNotNull(result, $"key:{key} not exist in {ToString()}");
            if (null != result)
            {
                return (T)result;
            }
            else
            {
                return default(T);
            }
        }
        /// <summary>
        /// override ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("{ ");
            foreach (var item in _dict)
            {
                sb.AppendFormat("{0}={1} ", item.Key, item.Value);
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
    public sealed class EventManager
    {
        private Dictionary<string, Action<object, EventParams>> _eventDict;
        // Lazy Initialize instance
        private readonly static Lazy<EventManager> _lazy = new Lazy<EventManager>(() => new EventManager());
        public static EventManager Instance
        {
            get
            {
                return _lazy.Value;
            }
        }
        private EventManager()
        {
            _eventDict = new Dictionary<string, Action<object, EventParams>>();
        }

        /// <summary>
        /// Subscribe one event
        /// </summary>
        /// <param name="eventName"> string of the name of event</param>
        /// <param name="listener"> delegate of callback mapped to the event </param>
        public void Subscribe(string eventName, Action<object, EventParams> listener)
        {
            Assert.IsNotNull(eventName, "Subscribe eventName should not be null");
            // new or add delegate to _eventDict
            if (_eventDict.ContainsKey(eventName))
            {
                _eventDict[eventName] += listener;
            }
            else
            {
                _eventDict.Add(eventName, listener);
            }
        }

        /// <summary>
        /// Unsubscribe one event
        /// </summary>
        /// <param name="eventName"> string of the name of event </param>
        /// <param name="listener"> delegate of callback mapped to the event </param>
        public void UnSubscribe(string eventName, Action<object, EventParams> listener)
        {
            Assert.IsNotNull(eventName, "UnSubscribe eventName should not be null");
            Action<object, EventParams> funcDelegate;
            if (_eventDict.TryGetValue(eventName, out funcDelegate))
            {
                funcDelegate -= listener;
            }
        }

        /// <summary>
        /// publish the event
        /// </summary>
        /// <param name="eventName"> string of the name of event</param>
        /// <param name="sender"> object who send the event </param>
        /// <param name="eventParams"> EventParams to send </param>
        public void Publish(string eventName, object sender, EventParams eventParams)
        {
            Assert.IsNotNull(eventName, "Publish eventName should not be null");
            Action<object, EventParams> funcDelegate;
            if (_eventDict.TryGetValue(eventName, out funcDelegate))
            {
                funcDelegate.Invoke(sender, eventParams);
            }
        }
    }
}
