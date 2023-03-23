/*** 
 * @Author: NickPansh
 * @Date: 2023-03-23 17:35:04
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-03-23 17:35:18
 * @FilePath: \Unity-Design-Pattern\Assets\GameProgrammingPatterns\8.DoubleBuffer\Scripts\Starter.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WenQu.DoubleBuffer.BadCodeExample;
namespace WenQu.DoubleBuffer
{
    public class Starter : MonoBehaviour
    {

        /// <summary>
        /// 使用Good Code启动还是使用Bad Code启动
        /// </summary>
        public CodeExample codeSample = CodeExample.Good;

        void Start()
        {
            if (codeSample == CodeExample.Good)
            {
                GetComponent<MapGenerator>().enabled = true;
                GetComponent<BadMapGenerator>().enabled = false;
            }
            else
            {
                GetComponent<MapGenerator>().enabled = false;
                GetComponent<BadMapGenerator>().enabled = true;
            }
        }


    }
}