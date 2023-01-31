/*** 
 * @Author: NickPansh
 * @Date: 2023-01-31 19:23:12
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-01-31 19:31:23
 * @FilePath: \Unity-Design-Pattern\Assets\Scripts\DesignPattern\MonoSingleton.cs
 * @Description: 继承自MonoBehaviour的单例模式泛型类
 * @参考https://github.com/UnityCommunity/UnitySingleton
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */

using UnityEngine;
namespace WenQu.DesignPattern
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {

        #region variable

        private static T _instance;

        /// <summary>
        /// 获取单例对象
        /// </summary>
        public static T Instance
        {
            get
            {
                if (null == _instance)
                {
                    _instance = FindObjectOfType<T>();
                    if (null == _instance)
                    {
                        GameObject go = new GameObject();
                        go.name = typeof(T).Name;
                        _instance = go.AddComponent<T>();
                    }
                }
                return _instance;
            }
        }

        #endregion

        #region method
        protected virtual void Awake()
        {
            if (null == _instance)
            {
                _instance = this as T;

                DontDestroyOnLoad(Instance);
            }
            else
            {
                Debug.LogError("Auto Deleted.MonoSingleton already exists. Did you add this Component twice?");
                Destroy(gameObject);
            }
        }
        #endregion
    }
}