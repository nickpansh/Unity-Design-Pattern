/*** 
 * @Author: NickPansh
 * @Date: 2023-02-10 09:32:48
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-10 09:37:50
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\Decorator\Scripts\BadCodeExample\BlockBuilder.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.DecoratorPattern.BadCode
{
    public class BlockBuilder
    {
        public Block Construct(string prefabPath, bool deletable)
        {
            GameObject gameObject = (GameObject)Object.Instantiate(Resources.Load(prefabPath));
            Block block = gameObject.AddComponent<Block>();
            if (deletable)
            {
                gameObject.AddComponent<ConductDelete>();
            }
            return block;
        }
    }
}
