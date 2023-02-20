/*** 
 * @Author: NickPansh
 * @Date: 2023-02-02 09:56:55
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-02 09:57:01
 * @FilePath: \Unity-Design-Pattern\Assets\Creational Patterns\AbstractFactory\Scripts\BadCodeExample\H5Tree.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.AbstractFactory.Bad
{
    public class H5TreeFactory
    {
        public H5Tree Create(GameObject tree, string id)
        {
            var t = new H5Tree();

            return t;
        }
    }
}