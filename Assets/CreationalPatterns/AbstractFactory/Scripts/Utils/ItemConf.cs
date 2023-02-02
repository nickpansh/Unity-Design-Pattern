/*** 
 * @Author: NickPansh
 * @Date: 2023-02-02 10:18:43
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-02 13:43:15
 * @FilePath: \Unity-Design-Pattern\Assets\Creational Patterns\AbstractFactory\Scripts\Utils\ItemConf.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections.Generic;
using UnityEngine;
using WenQu.FactoryMethod;
namespace WenQu.AbstractFactory
{

    [CreateAssetMenu(fileName = "ItemConf", menuName = "ScriptableObjects/ItemConf", order = 1)]
    public class ItemConf : ScriptableObject
    {
        public string[] ids;
        public GameObject[] prefabs;
        public string methodName;
    }
}