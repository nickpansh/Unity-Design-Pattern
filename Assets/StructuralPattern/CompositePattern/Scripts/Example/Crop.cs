/*** 
 * @Author: NickPansh
 * @Date: 2023-02-09 18:27:55
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-09 18:28:02
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\CompositPattern\Scripts\Utils\Crop.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
using WenQu.DesignPattern;

namespace WenQu.CompositePattern
{
    public class Crop : ITradable
    {
        private float _price;
        public Crop(float price)
        {
            _price = price;
        }

        public float GetPrice()
        {
            return _price;
        }
        public void QuickHarvest()
        {

        }

        public void Sell()
        {

        }

        public void Add(IComponent c)
        {
            throw new System.NotImplementedException();
        }

        public IComponent GetChild(int i)
        {
            throw new System.NotImplementedException();
        }
        public void Remove(IComponent c)
        {
            throw new System.NotImplementedException();
        }

    }
}