/*** 
 * @Author: NickPansh
 * @Date: 2023-03-22 11:00:40
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-03-22 14:18:16
 * @FilePath: \Unity-Design-Pattern\Assets\GameProgrammingPatterns\16.ServiceLocator\Scripts\Locator.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections.Generic;
namespace WenQu.ServiceLocator
{
    // 服务定位器
    public class Locator
    {
        private static Dictionary<string, IManager> _managers = new Dictionary<string, IManager>();
        private static Dictionary<string, IManager> _nullManageCache = new Dictionary<string, IManager>()
        {
            {typeof(AudioManager).Name, new NullAudioManager() },
            {typeof(NetworkManager).Name, new NullNetworkManager() },
        };

        static Locator()
        {

        }
        /// <summary>
        /// 获得管理器
        /// </summary>
        /// <typeparam name="T">IManager</typeparam>
        /// <returns></returns>
        public static T GetManager<T>() where T : class, IManager
        {
            string mgrName = typeof(T).Name;
            // 若字典中没有对应的管理器，则返回对应的空管理器
            if (!_managers.ContainsKey(mgrName))
            {

                if (_nullManageCache.TryGetValue(mgrName, out IManager nullMgr))
                {
                    return nullMgr as T;
                }
                else
                {
                    return default(T);
                }
            }
            return (T)_managers[mgrName];
        }
        /// <summary>
        /// 添加管理器
        /// </summary>
        /// <typeparam name="T">IManager</typeparam>
        /// <param name="mgr">instance of T</param>
        /// <returns></returns>
        public static T AddManager<T>(T mgr) where T : class, IManager
        {
            string mgrName = typeof(T).Name;
            if (_managers.ContainsKey(mgrName))
            {
                _managers[mgrName] = mgr;
            }
            else
            {
                _managers.Add(mgrName, mgr);
            }
            return mgr;
        }

        public static void RemoveManager<T>() where T : class, IManager
        {
            string mgrName = typeof(T).Name;
            if (_managers.ContainsKey(mgrName))
            {
                _managers.Remove(mgrName);
            }
        }
    }
}