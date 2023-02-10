/*** 
 * @Author: NickPansh
 * @Date: 2023-01-31 13:27:56
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-10 09:42:14
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\Flyweight\FlyweightStarter.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WenQu.Flyweight
{
    public class FlyweightStarter : MonoBehaviour
    {
        /// <summary>
        /// 使用Good Code启动还是使用Bad Code启动
        /// </summary>
        public CodeExample codeSample = CodeExample.Good;
        private List<SoldierAttr> objectsUseFlyweight = new List<SoldierAttr>();

        private List<HeavySoldierAttr> objectsHeavy = new List<HeavySoldierAttr>();

        const int _enemy_max = 100000;
        void Start()
        {
            // 通过Profiler查看内存开销的区别。
            if (codeSample == CodeExample.Good)
            {
                TestFlyweight();
            }
            else
            {
                TestHeavy();
            }
        }

        private void TestFlyweight()
        {

            AttrFactory factory = new AttrFactory();
            for (int i = 0; i < _enemy_max; i++)
            {
                int gradeV = (int)MathF.Floor(i / (_enemy_max / 4));
                var values = Enum.GetValues(typeof(AttrFactory.AttrType));
                AttrFactory.AttrType attrType = (AttrFactory.AttrType)values.GetValue(gradeV);
                SoldierAttr soldierAttr = factory.GetSoldierAttr(attrType, UnityEngine.Random.Range(0, 100), UnityEngine.Random.Range(155.0f, 190.0f));
                objectsUseFlyweight.Add(soldierAttr);
            }
        }
        private void TestHeavy()
        {
            string[] soundPath = new string[] { "attack.wmv", "hit.wmv", "die.wmv" };
            for (int i = 0; i < _enemy_max; i++)
            {
                int gradeV = (int)MathF.Floor(i / (_enemy_max / 4));
                if (gradeV == 0)
                {
                    HeavySoldierAttr heavySoldierAttr = new HeavySoldierAttr("下士", UnityEngine.Random.Range(0, 100), UnityEngine.Random.Range(155.0f, 190.0f), 100, 1.0, "b.png", soundPath, new Color(1.0f, 0.0f, 1.0f, 1.0f));
                    objectsHeavy.Add(heavySoldierAttr);
                }
                else if (gradeV == 1)
                {
                    HeavySoldierAttr heavySoldierAttr = new HeavySoldierAttr("中士", UnityEngine.Random.Range(0, 100), UnityEngine.Random.Range(155.0f, 190.0f), 200, 2.0, "b.png", soundPath, new Color(1.0f, 0.0f, 1.0f, 1.0f));
                    objectsHeavy.Add(heavySoldierAttr);
                }
                else if (gradeV == 2)
                {
                    HeavySoldierAttr heavySoldierAttr = new HeavySoldierAttr("上士", UnityEngine.Random.Range(0, 100), UnityEngine.Random.Range(155.0f, 190.0f), 500, 3.0, "b.png", soundPath, new Color(1.0f, 0.0f, 1.0f, 1.0f));
                    objectsHeavy.Add(heavySoldierAttr);
                }
                else
                {
                    HeavySoldierAttr heavySoldierAttr = new HeavySoldierAttr("上尉", UnityEngine.Random.Range(0, 100), UnityEngine.Random.Range(155.0f, 190.0f), 1000, 4.0, "a.png", soundPath, new Color(1.0f, 0.0f, 1.0f, 1.0f));
                    objectsHeavy.Add(heavySoldierAttr);
                }


            }
        }
    }
}
