/*** 
 * @Author: NickPansh
 * @Date: 2023-02-09 18:34:02
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-09 18:34:10
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\CompositePattern\Scripts\Utils\Fruit.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.CompositePattern
{
    public class Fruit : Crop
    {
        public Fruit(float price) : base(price)
        {
        }
    }
}