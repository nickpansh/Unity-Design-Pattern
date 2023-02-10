/*** 
 * @Author: NickPansh
 * @Date: 2023-02-10 11:31:22
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-10 11:35:53
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\Decorator\Scripts\Example\BlockBuilder.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WenQu.DecoratorPattern.Example
{
    public class BlockBuilder
    {
        public Block Construct(string prefabPath, bool deletable)
        {
            GameObject gameObject = (GameObject)Object.Instantiate(Resources.Load(prefabPath));
            Block block = gameObject.AddComponent<Block>();
            if (deletable)
            {
                block.deleteConducter = gameObject.AddComponent<ConductDelete>();
            }

            return block;
        }
    }
}
