/*** 
 * @Author: NickPansh
 * @Date: 2023-02-02 09:56:49
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-02 09:56:55
 * @FilePath: \Unity-Design-Pattern\Assets\Creational Patterns\AbstractFactory\Scripts\BadCodeExample\H5ShopFactory.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.AbstractFactory.Bad
{
    public class H5ShopFactory
    {
        public H5Shop Create(GameObject tree, string id)
        {
            var shop = new H5Shop();

            return shop;
        }
    }
}