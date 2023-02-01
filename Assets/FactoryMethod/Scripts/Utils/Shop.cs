/*** 
 * @Author: NickPansh
 * @Date: 2023-02-01 13:09:37
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-01 16:33:01
 * @FilePath: \Unity-Design-Pattern\Assets\FactoryMethod\Scripts\Utils\Shop.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.FactoryMethod
{
    public class Shop : Building
    {

    }

    public class ShopFactory : AbstractItemFactory
    {
        private int count = 0;
        public override Item Create(GameObject prefab, string id)
        {
            GameObject go = Object.Instantiate(prefab);
            Item shop = go.AddComponent<Shop>();
            shop.id = id;
            if (id == "shop_1001")
            {
                go.AddComponent<SphereCollider>();
            }
            shop.gameObject.transform.localPosition = new Vector3(count * shop.gameObject.transform.localScale.x, 3, count * shop.gameObject.transform.localScale.x);
            count++;
            return shop;
        }
    }
}