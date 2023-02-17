/*** 
 * @Author: NickPansh
 * @Date: 2023-02-01 16:51:37
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-01 17:26:05
 * @FilePath: \Unity-Design-Pattern\Assets\FactoryMethod\Scripts\BadCodeExample\BadDecorateCtrl.cs
 * @Description: 这个类最大的问题是不符合单一职责原则，DecorateController里塞了太多创建对象的行为
 * @随着项目的增长，这个类会越来越庞大
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.FactoryMethod
{
    public class BadDecorateCtrl : MonoBehaviour
    {
        public GameObject buildingPrefab;
        public GameObject treePrefab;
        public GameObject shopPrefab;
        private int count = 0;
        private void AWake()
        {
            //生成建筑bu_1001,bu_1002,bu_1003
            Building building1 = GenBuilding(buildingPrefab, "bu_1001");
            Building building2 = GenBuilding(buildingPrefab, "bu_1002");
            Building building3 = GenBuilding(buildingPrefab, "bu_1003");

            // 生成Shop shop_1001,shop_1002
            Shop shop1 = GenShop(shopPrefab, "shop_1001");
            Shop shop2 = GenShop(shopPrefab, "shop_1002");

            // 生成树tree_1001,tree_1002
            Tree tree1 = GenTree(treePrefab, "tree_1001");
            Tree tree2 = GenTree(treePrefab, "tree_1001");
        }

        // 生成建筑，不符合单一职责原则：DecorateController后期会存在大量的GenXX方法越来越庞大
        // Generate Building, not follow the Single Responsibility Principle
        private Building GenBuilding(GameObject prefab, string id)
        {
            GameObject gameObject = Object.Instantiate(prefab);
            Building building = gameObject.AddComponent<Building>();
            gameObject.AddComponent<UnityEngine.AI.NavMeshObstacle>();
            building.gameObject.transform.localPosition = new Vector3(count, 0, count) * gameObject.transform.localScale.x;
            building.id = id;
            count++;
            //等等一系列用于Create一个Building的操作
            return building;
        }

        // 生成商店，不符合单一职责原则：DecorateController后期会存在大量的GenXX方法越来越庞大
        // Generate Shop, not follow the Single Responsibility Principle
        private Shop GenShop(GameObject prefab, string id)
        {
            GameObject go = Object.Instantiate(prefab);
            Shop shop = go.AddComponent<Shop>();
            shop.id = id;
            if (id == "shop_1001")
            {
                go.AddComponent<SphereCollider>();
            }
            shop.gameObject.transform.localPosition = new Vector3(count * shop.gameObject.transform.localScale.x, 3, count * shop.gameObject.transform.localScale.x);
            count++;
            return shop;
        }
        // 生成树木，不符合单一职责原则：DecorateController后期会存在大量的GenXX方法越来越庞大
        // Generate Tree, not follow the Single Responsibility Principle
        private Tree GenTree(GameObject prefab, string id)
        {
            GameObject gameObject = Object.Instantiate(prefab);
            Tree tree = gameObject.AddComponent<Tree>();
            TreeLoadConf();
            TreeAddToTreePool();
            tree.gameObject.transform.localPosition = new Vector3(count * gameObject.transform.localScale.x, 6, count * gameObject.transform.localScale.x);
            count++;
            return tree;
        }

        private void TreeLoadConf()
        {
            // 伪代码：加载本地文件，读取树的配置
            // Pseudo code: load local file, read tree configuration
        }

        private void TreeAddToTreePool()
        {
            // 伪代码，加入TreePool
            // Pseudo code, add to TreePool
        }
    }
}