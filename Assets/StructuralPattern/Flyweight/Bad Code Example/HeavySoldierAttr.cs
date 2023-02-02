/*** 
 * @Author: NickPansh
 * @Date: 2023-01-29 11:18:15
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-01-31 11:09:18
 * @FilePath: \Unity-Design-Pattern\Assets\Flyweight\Bad Code Example\HeavySoldierAttr.cs
 * @Description: Bad Code，没有用Flyweight
 * @
 * @Copyright (c) 2023 by NickPansh nickpansh@yeah.net|wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.Flyweight
{
    public class HeavySoldierAttr
    {
        public int hp { get; set; }
        public float height { get; set; }
        public int maxHp { get; set; }
        public double moveSpeed { get; set; }
        public string picPath;
        public string[] soundPaths;
        public Color color;
        public string name { get; set; }
        public HeavySoldierAttr(string name, int hp, float height, int maxHp, double moveSpeed, string picPath, string[] soundPaths, Color color)
        {
            this.hp = hp;
            this.height = height;
            this.maxHp = maxHp;
            this.moveSpeed = moveSpeed;
            this.name = name;
            this.picPath = picPath;
            this.soundPaths = soundPaths;
            this.color = color;
        }
    }
}