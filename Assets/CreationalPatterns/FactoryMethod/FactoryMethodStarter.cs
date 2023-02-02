/*** 
 * @Author: NickPansh
 * @Date: 2023-02-01 16:54:18
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-01 17:11:01
 * @FilePath: \Unity-Design-Pattern\Assets\FactoryMethod\FactoryMethodStarter.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WenQu;
namespace WenQu.FactoryMethod
{
    public class FactoryMethodStarter : MonoBehaviour
    {
        /// <summary>
        /// 使用Good Code启动还是使用Bad Code启动
        /// </summary>
        private BadDecorateCtrl badDecorateCtrl;
        private DecorateCtrl decorateCtrl;
        public CodeExample codeSample = CodeExample.Good;

        void Start()
        {
            badDecorateCtrl = GetComponent<BadDecorateCtrl>();
            decorateCtrl = GetComponent<DecorateCtrl>();
            badDecorateCtrl.enabled = CodeExample.Good != codeSample;
            decorateCtrl.enabled = CodeExample.Good == codeSample;

        }

        void Update()
        {

        }
    }
}