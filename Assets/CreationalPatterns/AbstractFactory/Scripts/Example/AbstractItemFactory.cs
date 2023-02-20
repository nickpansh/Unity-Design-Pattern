/*** 
 * @Author: NickPansh
 * @Date: 2023-02-02 09:45:54
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-02 09:50:32
 * @FilePath: \Unity-Design-Pattern\Assets\Creational Patterns\AbstractFactory\Scripts\Example\IFactory.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
using WenQu.FactoryMethod;
namespace WenQu.AbstractFactory
{
    public abstract class AbstractItemFactory
    {

        public abstract WenQu.FactoryMethod.Building CreateBuilding(GameObject prefab, string id);
        public abstract WenQu.FactoryMethod.Shop CreateShop(GameObject prefab, string id);
        public abstract WenQu.FactoryMethod.Tree CreateTree(GameObject tree, string id);
    }
}
