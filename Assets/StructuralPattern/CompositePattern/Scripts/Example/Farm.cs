/*** 
 * @Author: NickPansh
 * @Date: 2023-02-09 18:38:47
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-10 10:23:04
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\CompositePattern\Scripts\Example\Farm.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using WenQu.DesignPattern;

namespace WenQu.CompositePattern
{
    public class Farm : ITradable
    {
        private ArrayList crops;
        public Farm()
        {
            crops = new ArrayList();
        }
        public void Add(IComponent c)
        {
            crops.Add(c);
        }
        public void Remove(IComponent c)
        {
            crops.Remove(c);
        }

        public IComponent GetChild(int i)
        {
            return (IComponent)crops[i];
        }

        public float GetPrice()
        {
            float price = 0;
            foreach (ITradable item in crops)
            {
                price += item.GetPrice();
            }
            return price;
        }

        public void QuickHarvest()
        {
            foreach (ITradable item in crops)
            {
                item.QuickHarvest();
            }
        }


        public void Sell()
        {
            foreach (ITradable item in crops)
            {
                item.Sell();
            }
        }
    }
}