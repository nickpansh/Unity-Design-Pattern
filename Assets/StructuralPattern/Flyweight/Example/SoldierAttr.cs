/*** 
 * @Author: NickPansh
 * @Date: 2023-01-29 10:42:16
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-01-31 11:01:20
 * @FilePath: \Unity-Design-Pattern\Assets\Flyweight\Example\SoldierAttr.cs
 * @Description: 士兵属性
 * @
 * @Copyright (c) 2023 by NickPansh nickpansh@yeah.net|wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.Flyweight
{
    public class SoldierAttr
    {
        /// <summary>
        /// 当前血量
        /// </summary>
        public int hp { get; set; }
        /// <summary>
        /// 身高
        /// </summary>
        public float height { get; set; }
        public FlyweightAttr flyweightAttr { get; }

        // 构造函数
        public SoldierAttr(FlyweightAttr flyweightAttr, int hp, float height)
        {
            this.flyweightAttr = flyweightAttr;
            this.hp = hp;
            this.height = height;
        }
        /// <summary>
        /// 获取最大血量
        /// </summary>
        /// <returns></returns>
        public int GetMaxHp()
        {
            return flyweightAttr.maxHp;
        }

        /// <summary>
        /// 获取移动速度
        /// </summary>
        /// <returns></returns>
        public double GetMoveSpeed()
        {
            return flyweightAttr.moveSpeed;
        }

        /// <summary>
        /// 获取名字
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return flyweightAttr.name;
        }

        /// <summary>
        /// 获取图片名
        /// </summary>
        /// <returns></returns>
        public string GetPicPath()
        {
            return flyweightAttr.picPath;
        }

        /// <summary>
        /// 获取音频路径
        /// </summary>
        /// <returns></returns>
        public string[] GetSoundPaths()
        {
            return flyweightAttr.soundPaths;
        }

        /// <summary>
        /// 获取颜色
        /// </summary>
        /// <returns></returns>
        public Color GetColor()
        {
            return flyweightAttr.color;
        }
    }
}