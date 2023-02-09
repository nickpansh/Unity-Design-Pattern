/*** 
 * @Author: NickPansh
 * @Date: 2023-02-09 18:34:51
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-09 18:34:51
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\CompositePattern\Example\ITradable.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using WenQu.DesignPattern;
namespace WenQu.CompositePattern
{
    public interface ITradable : IComponent
    {
        public float GetPrice();
        public void Sell();
        public void QuickHarvest();
    }
}