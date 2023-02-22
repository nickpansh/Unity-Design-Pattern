/*** 
 * @Author: NickPansh
 * @Date: 2023-02-22 17:32:30
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-22 18:15:41
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\Memento\Scripts\Example\Apple.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace WenQu.Memento
{
    public class AppleBuilder
    {
        public string prefab;
        public float price;
        public Vector3 startPos;
        public Vector3 endPos;
        /// <summary>
        /// 生成苹果
        /// </summary>
        /// <param name="prefab"></param>
        /// <param name="price"></param>
        /// <param name="startPos"></param>
        /// <param name="endPos"></param>
        /// <returns></returns>
        public AppleBuilder(string prefab)
        {
            this.prefab = prefab;
        }


        public Apple Generate()
        {
            GameObject appleObj = GameObject.Instantiate(Resources.Load<GameObject>(prefab));
            Apple apple = appleObj.GetComponent<Apple>();
            return apple;
        }

    }
    public class Apple : MonoBehaviour
    {
        public Vector3 GetStartPos()
        {
            return this.transform.position;
        }

        public Vector3 GetScale()
        {
            return this.transform.lossyScale;
        }

        public Quaternion GetRotation()
        {
            return this.transform.rotation;
        }

        // 创建备忘录
        // create memento
        internal AppleMemento CreateMemento()
        {
            return new AppleMemento(this);
        }

        // 从备忘录中恢复
        // restore from memento
        internal void Restore(AppleMemento memento)
        {
            transform.position = memento.GetStartPos();
            transform.localScale = memento.GetScale();
            transform.rotation = memento.GetRotation();

        }


    }
}