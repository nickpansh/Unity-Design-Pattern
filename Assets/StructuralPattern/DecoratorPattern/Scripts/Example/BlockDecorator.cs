/*** 
 * @Author: NickPansh
 * @Date: 2023-02-10 11:24:16
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-10 11:38:31
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\Decorator\Scripts\Example\BlockDecorator.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.DecoratorPattern.Example
{
    public class BlockDecorator : MonoBehaviour, IDeletable
    {
        public IDeletable deleteConducter;

        public void Delete()
        {
            if (deleteConducter != null)
            {
                deleteConducter.Delete();
            }
        }

        public void Lock()
        {
            if (deleteConducter != null)
            {
                deleteConducter.Lock();
            }
        }

        public void Unlock()
        {
            if (deleteConducter != null)
            {
                deleteConducter.Unlock();
            }
        }
    }
}