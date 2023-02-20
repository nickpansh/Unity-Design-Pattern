/*** 
 * @Author: NickPansh
 * @Date: 2023-02-02 10:11:28
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-20 17:54:42
 * @FilePath: \Unity-Design-Pattern\Assets\CreationalPatterns\AbstractFactory\Scripts\AbstractFactoryStarter.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
using System.Reflection;
using System.Collections.Generic;
using System;

namespace WenQu.AbstractFactory
{
    public class AbstractFactoryStarter : MonoBehaviour
    {
        public PlatformConf platformConf;

        private void Awake()
        {

            Dictionary<string, AbstractItemFactory> cache = new Dictionary<string, AbstractItemFactory>();
            ItemConf[] confs = new ItemConf[]{
                platformConf.buildingConf,
                platformConf.shopConf,
                platformConf.treeConf
            };
            // 演示通过反射生成
            // Demonstrate the generation of objects through reflection
            Assembly assembly = Assembly.Load("Assembly-CSharp");
            foreach (ItemConf conf in confs)
            {
                for (int i = 0; i < conf.ids.Length; i++)
                {
                    if (conf.prefabs.Length > 0)
                    {

                        AbstractItemFactory factory;
                        cache.TryGetValue(platformConf.factoryClass, out factory);
                        if (factory == null)
                        {
                            factory = assembly.CreateInstance(platformConf.factoryClass) as AbstractItemFactory;
                            cache.Add(platformConf.factoryClass, factory);
                        }
                        Type factoryType = assembly.GetType(platformConf.factoryClass);
                        MethodInfo method = factoryType.GetMethod(conf.methodName);
                        method?.Invoke(factory, new object[] { conf.prefabs[1], conf.ids[i] });
                    }
                }
            }
        }
    }
}

