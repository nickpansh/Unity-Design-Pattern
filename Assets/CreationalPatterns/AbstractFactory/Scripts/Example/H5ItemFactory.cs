/*** 
 * @Author: NickPansh
 * @Date: 2023-02-02 09:49:07
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-20 17:52:52
 * @FilePath: \Unity-Design-Pattern\Assets\CreationalPatterns\AbstractFactory\Scripts\Example\H5ItemFactory.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
using WenQu.DesignPattern;
using WenQu.FactoryMethod;
namespace WenQu.AbstractFactory
{
    public class H5ItemFactory : AbstractItemFactory
    {
        private int buildingCount = 0;
        private int shopCount = 0;
        private int treeCount = 0;

        private static H5ItemFactory _Instance = new H5ItemFactory();


        public override Building CreateBuilding(GameObject prefab, string id)
        {
            GameObject gameObject = Object.Instantiate(prefab);
            H5Building building = gameObject.AddComponent<H5Building>();
            gameObject.AddComponent<UnityEngine.AI.NavMeshObstacle>();
            building.gameObject.transform.localPosition = new Vector3(buildingCount, 0, buildingCount) * gameObject.transform.localScale.x;
            building.id = id;
            buildingCount++;
            // H5平台创建Building的后续操作
            // and other operations to create building on H5 platform
            //
            //
            //
            //
            return building;
        }

        public override Shop CreateShop(GameObject prefab, string id)
        {
            GameObject go = Object.Instantiate(prefab);
            H5Shop shop = go.AddComponent<H5Shop>();
            shop.id = id;
            if (id == "shop_1001")
            {
                go.AddComponent<SphereCollider>();
            }
            shop.gameObject.transform.localPosition = new Vector3(shopCount * shop.gameObject.transform.localScale.x, 3, shopCount * shop.gameObject.transform.localScale.x);
            shopCount++;
            // H5平台创建Shop的后续操作
            // and other operations to create shop on H5 platform
            //
            //
            //
            //
            return shop;
        }

        public override FactoryMethod.Tree CreateTree(GameObject prefab, string id)
        {
            GameObject gameObject = Object.Instantiate(prefab);
            H5Tree tree = gameObject.AddComponent<H5Tree>();
            LoadConf();
            AddToTreePool();
            tree.gameObject.transform.localPosition = new Vector3(treeCount * gameObject.transform.localScale.x, 6, treeCount * gameObject.transform.localScale.x);
            treeCount++;
            // H5平台创建Tree的后续操作
            // and other operations to create tree on H5 platform
            //
            //
            //
            //
            return tree;
        }

        private void LoadConf()
        {
            // 伪代码：加载本地文件，读取树的配置
            // pseudo code: load local file, read tree config
        }

        private void AddToTreePool()
        {
            // 伪代码，加入TreePool
            // pseudo code, add to tree pool
        }
    }
}