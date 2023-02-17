/*** 
 * @Author: NickPansh
 * @Date: 2023-01-31 18:06:22
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-01-31 18:39:06
 * @FilePath: \Unity-Design-Pattern\Assets\Prototype\Test\Bird.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System;
namespace WenQu.Prototype
{
    // 如果有嵌套，嵌套的子层也需要实现ICloneable
    // If there is a nesting, the nested sublayer also needs to implement ICloneable
    public class Bird : ICloneable
    {
        public int age;
        public object Clone()
        {
            Bird bird = new Bird();
            bird.age = this.age;
            return bird;
        }
    }
}