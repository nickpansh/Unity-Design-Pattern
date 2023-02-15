/*** 
 * @Author: NickPansh
 * @Date: 2023-01-31 19:23:12
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-15 18:31:34
 * @FilePath: \Unity-Design-Pattern\Assets\Scripts\DesignPattern\Singleton.cs
 * @Description: Best Practice of Singleton(Demo)
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */

using System;
namespace WenQu.DesignPattern
{
    public sealed class Singleton
    {
        //
        private static readonly Lazy<Singleton> lazy =
            new Lazy<Singleton>(() => new Singleton());

        public static Singleton Instance { get { return lazy.Value; } }

        private Singleton()
        {
        }

    }
}