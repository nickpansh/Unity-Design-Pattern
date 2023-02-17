/*** 
 * @Author: NickPansh
 * @Date: 2023-02-01 13:33:36
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-02 09:10:31
 * @FilePath: \Unity-Design-Pattern\Assets\FactoryMethod\Scripts\Utils\Tree.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.FactoryMethod
{
    public class Tree : Item
    {
        public void BeChopDown()
        {

        }
    }

    public class TreeFactory : AbstractItemFactory
    {
        private int count = 0;
        public override Item Create(GameObject prefab, string id)
        {
            GameObject gameObject = Object.Instantiate(prefab);
            Item tree = gameObject.AddComponent<Tree>();
            LoadConf();
            AddToTreePool();
            tree.gameObject.transform.localPosition = new Vector3(count * gameObject.transform.localScale.x, 6, count * gameObject.transform.localScale.x);
            count++;
            return tree;
        }

        private void LoadConf()
        {
            // 伪代码：加载本地文件，读取树的配置
            // Pseudo code: load local file, read tree configuration
        }

        private void AddToTreePool()
        {
            // 伪代码，加入TreePool
            // Pseudo code, add to TreePool
        }
    }
}