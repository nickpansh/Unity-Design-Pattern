/*** 
 * @Author: NickPansh
 * @Date: 2023-02-02 09:57:30
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-02 09:57:37
 * @FilePath: \Unity-Design-Pattern\Assets\Creational Patterns\AbstractFactory\Scripts\BadCodeExample\SwitchBuildingFactory.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.AbstractFactory.Bad
{
    public class SwitchBuildingFactory
    {
        public SwitchBuilding Create(GameObject tree, string id)
        {
            var building = new SwitchBuilding();

            return building;
        }
    }
}