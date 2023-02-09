/*** 
 * @Author: NickPansh
 * @Date: 2023-02-09 18:37:35
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-09 18:49:25
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\CompositePattern\Scripts\CompositeStarter.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.CompositePattern
{
    public class CompositeStarter : MonoBehaviour
    {
        private void Awake()
        {
            ITradable wheat1 = new Wheat(100);
            ITradable fruit1 = new Fruit(150);
            ITradable flower1 = new Flower(200);
            Debug.Log($"wheat1 's price = {wheat1.GetPrice()}");
            Debug.Log($"fruit1 's price = {fruit1.GetPrice()}");
            Debug.Log($"flower1 's price = {flower1.GetPrice()}");

            ITradable farm1 = new Farm();
            farm1.Add(wheat1);
            farm1.Add(fruit1);
            farm1.Add(flower1);
            Debug.Log($"farm1 's price = {farm1.GetPrice()}");

        }
    }
}