/*** 
 * @Author: NickPansh
 * @Date: 2023-02-09 18:32:12
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-09 18:32:35
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\CompositePattern\Scripts\Utils\Flower.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.CompositePattern
{
    public class Flower : Crop
    {
        public Flower(float price) : base(price)
        {
        }
    }
}