/*** 
 * @Author: NickPansh
 * @Date: 2023-02-02 09:56:42
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-20 17:47:56
 * @FilePath: \Unity-Design-Pattern\Assets\CreationalPatterns\AbstractFactory\Scripts\BadCodeExample\H5BuildingFactory.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.AbstractFactory.Bad
{
    public class H5BuildingFactory
    {
        public H5Building Create(GameObject tree, string id)
        {
            var building = new H5Building();

            return building;
        }
    }
}