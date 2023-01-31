/*** 
 * @Author: NickPansh
 * @Date: 2023-01-29 10:22:21
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-01-31 10:49:04
 * @FilePath: \Unity-Design-Pattern\Assets\Flyweight\Example\AttrFactory.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by NickPansh nickpansh@yeah.net|wenqu.site, All Rights Reserved. 
 */
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.Flyweight
{
    public class AttrFactory
    {
        /// <summary>
        /// 属性类型枚举
        /// </summary>
        public enum AttrType : uint
        {
            // 新兵
            Recruit = 0,
            // 中士
            StaffSergeant,
            // 上士
            Sergeant,
            // 上尉
            Captian,
        }
        /// <summary>
        /// 基础属性缓存
        /// </summary>
        private Dictionary<AttrType, FlyweightAttr> _flyweightAttrDB = null;
        public AttrFactory()
        {
            _flyweightAttrDB = new Dictionary<AttrType, FlyweightAttr>();
            string[] soundPath = new string[] { "attack.wmv", "hit.wmv", "die.wmv" };
            _flyweightAttrDB.Add(AttrType.Recruit, new FlyweightAttr("士兵", 100, 1.0, soundPath, new Color(1.0f, 0.0f, 1.0f, 1.0f), "b.png"));
            _flyweightAttrDB.Add(AttrType.StaffSergeant, new FlyweightAttr("中士", 200, 2.0, soundPath, new Color(1.0f, 0.0f, 1.0f, 1.0f), "b.png"));
            _flyweightAttrDB.Add(AttrType.Sergeant, new FlyweightAttr("上士", 500, 3.0, soundPath, new Color(1.0f, 0.0f, 1.0f, 1.0f), "b.png"));
            _flyweightAttrDB.Add(AttrType.Captian, new FlyweightAttr("上尉", 1000, 4.0, soundPath, new Color(1.0f, 0.0f, 1.0f, 1.0f), "a.png"));
        }
        /// <summary>
        /// 获取角色属性
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="hp">血量</param>
        /// <param name="height">身高</param>
        /// <returns></returns>
        public SoldierAttr GetSoldierAttr(AttrType type, int hp, float height)
        {
            if (!_flyweightAttrDB.ContainsKey(type))
            {
                Debug.LogErrorFormat("{0}属性不存在", type);
                return null;
            }
            FlyweightAttr flyweightAttr = _flyweightAttrDB[type];
            SoldierAttr attr = new SoldierAttr(flyweightAttr, hp, height);
            return attr;
        }
    }
}