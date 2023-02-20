/*** 
 * @Author: NickPansh
 * @Date: 2023-02-02 09:57:15
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-02 09:57:22
 * @FilePath: \Unity-Design-Pattern\Assets\Creational Patterns\AbstractFactory\Scripts\BadCodeExample\SwitchShopFactory.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.AbstractFactory.Bad
{
    public class SwitchShopFactory
    {
        public SwitchShop Create(GameObject tree, string id)
        {
            var shop = new SwitchShop();

            return shop;
        }
    }
}