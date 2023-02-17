/*** 
 * @Author: NickPansh
 * @Date: 2023-02-17 10:50:12
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-17 11:05:16
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\TemplateMethod\Example\Starter.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.TemplateMethod
{
    public class Starter : MonoBehaviour
    {
        public Hero hero;
        public Hero enemy;
        private Skill zoneSkill;
        private Skill pointToSkill;
        void Start()
        {
            hero.mp = 100;
            zoneSkill = new ZoneSkill(hero, 10);

            pointToSkill = new PointToSkill(hero, 5, 10);

        }


        void Update()
        {
            // 按下任意键释放技能
            if (Input.anyKeyDown)
            {
                pointToSkill.Execute(enemy);
                zoneSkill.Execute(enemy);
            }
        }
    }
}