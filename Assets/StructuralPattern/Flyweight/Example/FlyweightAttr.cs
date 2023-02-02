/*** 
 * @Author: NickPansh
 * @Date: 2023-01-29 10:19:07
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-01-31 10:59:56
 * @FilePath: \Unity-Design-Pattern\Assets\Flyweight\Example\FlyweightAttr.cs
 * @Description: 基础属性
 * @
 * @Copyright (c) 2023 by NickPansh nickpansh@yeah.net|wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.Flyweight
{
    public class FlyweightAttr
    {
        public int maxHp;
        public double moveSpeed;
        public string picPath;
        public string[] soundPaths;
        public Color color;
        public string name;
        public FlyweightAttr(string name, int maxHp, double moveSpeed, string[] soundPaths, Color color, string picPath)
        {
            this.name = name;
            this.maxHp = maxHp;
            this.moveSpeed = moveSpeed;
            this.soundPaths = soundPaths;
            this.color = color;
            this.picPath = picPath;
        }
    }
}