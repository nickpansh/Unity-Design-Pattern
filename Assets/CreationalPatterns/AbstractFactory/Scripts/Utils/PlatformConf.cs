/*** 
 * @Author: NickPansh
 * @Date: 2023-02-02 13:18:38
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-02 13:22:14
 * @FilePath: \Unity-Design-Pattern\Assets\Creational Patterns\AbstractFactory\Scripts\Utils\PlatformConf.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.AbstractFactory
{

    [CreateAssetMenu(fileName = "PlatformConf", menuName = "ScriptableObjects/PlatformConf", order = 2)]
    public class PlatformConf : ScriptableObject
    {
        public ItemConf buildingConf;
        public ItemConf shopConf;
        public ItemConf treeConf;
        public string factoryClass;
    }
}