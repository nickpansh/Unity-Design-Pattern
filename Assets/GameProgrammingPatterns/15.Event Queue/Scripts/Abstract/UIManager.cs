/*** 
 * @Author: NickPansh
 * @Date: 2023-04-21 14:14:52
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-04-21 14:15:01
 * @FilePath: \Unity-Design-Pattern\Assets\GameProgrammingPatterns\15.Event Queue\Scripts\Abstract\UIManager.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
using UnityEngine.Assertions;
namespace WenQu.EventQueue
{
    /// <summary>
    /// UI抽象管理父类
    /// </summary>
    public abstract class UIManager : MonoBehaviour, IManager
    {
        public abstract UILayer layer { get; }
        protected UIBase CreateUI(UITypeInfo uiTypeInfo)
        {
            // 加载prefab
            GameObject prefab = Resources.Load<GameObject>(uiTypeInfo.prefabPath);
            Assert.IsNotNull(prefab, $"prefab:{uiTypeInfo.prefabPath}不存在");
            GameObject uiGo = Instantiate(prefab, Vector3.zero, Quaternion.identity, this.transform);
            UIBase ui = uiGo.AddComponent(uiTypeInfo.scriptType) as UIBase;
            ui.OnEnter();
            return ui;
        }


    }
}