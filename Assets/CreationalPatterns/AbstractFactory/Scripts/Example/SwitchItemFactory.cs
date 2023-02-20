/*** 
 * @Author: NickPansh
 * @Date: 2023-02-02 09:49:07
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-02 11:17:57
 * @FilePath: \Unity-Design-Pattern\Assets\Creational Patterns\AbstractFactory\Scripts\Example\SwitchItemFactory.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
using WenQu.FactoryMethod;
namespace WenQu.AbstractFactory
{
    public class SwitchItemFactory : AbstractItemFactory
    {

        private int buildingCount = 0;
        private int shopCount = 0;
        private int treeCount = 0;


        public override Building CreateBuilding(GameObject prefab, string id)
        {
            GameObject gameObject = Object.Instantiate(prefab);
            SwitchBuilding building = gameObject.AddComponent<SwitchBuilding>();
            gameObject.AddComponent<UnityEngine.AI.NavMeshObstacle>();
            building.gameObject.transform.localPosition = new Vector3(buildingCount, 0, buildingCount) * gameObject.transform.localScale.x;
            building.id = id;
            buildingCount++;
            // Switch平台创建Building的后续操作
            // and other operations to create building on Switch platform
            //
            //
            //
            //
            return building;
        }

        public override Shop CreateShop(GameObject prefab, string id)
        {
            GameObject go = Object.Instantiate(prefab);
            SwitchShop shop = go.AddComponent<SwitchShop>();
            shop.id = id;
            if (id == "shop_1001")
            {
                go.AddComponent<SphereCollider>();
            }
            shop.gameObject.transform.localPosition = new Vector3(shopCount * shop.gameObject.transform.localScale.x, 3, shopCount * shop.gameObject.transform.localScale.x);
            shopCount++;
            // Switch平台创建Shop的后续操作
            // and other operations to create shop on Switch platform
            //
            //
            //
            //
            return shop;
        }

        public override FactoryMethod.Tree CreateTree(GameObject prefab, string id)
        {
            GameObject gameObject = Object.Instantiate(prefab);
            SwitchTree tree = gameObject.AddComponent<SwitchTree>();
            LoadConf();
            AddToTreePool();
            tree.gameObject.transform.localPosition = new Vector3(treeCount * gameObject.transform.localScale.x, 6, treeCount * gameObject.transform.localScale.x);
            treeCount++;
            //Switch平台创建Tree的后续操作
            // and other operations to create tree on Switch platform
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
            // pseudo code, add to TreePool
        }
    }
}