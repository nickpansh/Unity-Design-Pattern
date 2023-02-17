/*** 
 * @Author: NickPansh
 * @Date: 2023-02-01 13:29:53
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-01 17:04:38
 * @FilePath: \Unity-Design-Pattern\Assets\FactoryMethod\Scripts\Example\DecorateCtrl.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WenQu.FactoryMethod
{
    public class DecorateCtrl : MonoBehaviour
    {
        public GameObject buildingPrefab;
        public GameObject treePrefab;
        public GameObject shopPrefab;

        private void Awake()
        {
            //生成建筑bu_1001,bu_1002,bu_1003
            //Generate buildings bu_1001, bu_1002, bu_1003
            BuildingFactory buildingFactory = new BuildingFactory();
            Building building1 = (Building)buildingFactory.Create(buildingPrefab, "bu_1001");
            Building building2 = (Building)buildingFactory.Create(buildingPrefab, "bu_1002");
            Building building3 = (Building)buildingFactory.Create(buildingPrefab, "bu_1003");

            // 生成Shop shop_1001,shop_1002
            // Generate Shop shop_1001, shop_1002
            ShopFactory shopFactory = new ShopFactory();
            Shop shop1 = (Shop)shopFactory.Create(shopPrefab, "shop_1001");
            Shop shop2 = (Shop)shopFactory.Create(shopPrefab, "shop_1002");

            // 生成树tree_1001,tree_1002
            // Generate trees tree_1001, tree_1002
            TreeFactory treeFactory = new TreeFactory();
            Tree tree1 = (Tree)treeFactory.Create(treePrefab, "tree_1001");
            Tree tree2 = (Tree)treeFactory.Create(treePrefab, "tree_1001");
        }
    }
}