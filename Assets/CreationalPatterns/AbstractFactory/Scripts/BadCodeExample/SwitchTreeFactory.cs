/*** 
 * @Author: NickPansh
 * @Date: 2023-02-02 09:57:04
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-20 17:51:02
 * @FilePath: \Unity-Design-Pattern\Assets\CreationalPatterns\AbstractFactory\Scripts\BadCodeExample\SwitchTreeFactory.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.AbstractFactory.Bad
{
    public class SwitchTreeFactory
    {
        public SwitchTree Create(GameObject tree, string id)
        {
            SwitchTree t = new SwitchTree();

            return t;
        }
    }
}