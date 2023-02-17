/*** 
 * @Author: NickPansh
 * @Date: 2023-01-31 18:02:57
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-17 18:07:05
 * @FilePath: \Unity-Design-Pattern\Assets\CreationalPatterns\Prototype\Test\Tree.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System;
namespace WenQu.Prototype
{
    public class Tree : ICloneable
    {
        public string name;
        public float height;
        public Bird bird;
        // 必须实现的接口方法
        // The interface method that must be implemented
        public object Clone()
        {
            Tree tree = new Tree(this.name, this.height);
            tree.bird = (Bird)this.bird.Clone();
            return tree;
        }
        /// <summary>
        /// 浅复制
        /// Shallow copy
        /// </summary>
        /// <returns></returns>
        public Tree ShallowClone()
        {
            return (Tree)this.MemberwiseClone();
        }
        public Tree(string name, float height)
        {
            this.name = name;
            this.height = height;
        }


        public override string ToString()
        {
            return string.Format("{0},height={1},bird age={2}", name, height, bird.age);
        }
    }
}