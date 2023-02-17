/*** 
 * @Author: NickPansh
 * @Date: 2023-02-01 12:57:28
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-01 12:59:01
 * @FilePath: \Unity-Design-Pattern\Assets\FactoryMethod\Utils\Building.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.FactoryMethod
{
    public class Building : Item
    {

    }

    public class BuildingFactory : AbstractItemFactory
    {
        private int count = 0;
        public override Item Create(GameObject prefab, string id)
        {
            GameObject gameObject = Object.Instantiate(prefab);
            Item building = gameObject.AddComponent<Building>();
            gameObject.AddComponent<UnityEngine.AI.NavMeshObstacle>();
            building.gameObject.transform.localPosition = new Vector3(count, 0, count) * gameObject.transform.localScale.x;
            building.id = id;
            count++;
            //等等一系列用于Create一个Building的操作
            //A series of operations for creating a Building
            return building;
        }
    }

}