/*** 
 * @Author: NickPansh
 * @Date: 2023-02-01 12:32:36
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-01 15:29:28
 * @FilePath: \Unity-Design-Pattern\Assets\FactoryMethod\Scripts\Example\Factories\AbstractItemFactory.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.FactoryMethod
{
    public abstract class AbstractItemFactory
    {

        public abstract Item Create(GameObject prefab, string id);
    }
}