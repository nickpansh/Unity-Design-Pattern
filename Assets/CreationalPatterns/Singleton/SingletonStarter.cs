/*** 
 * @Author: NickPansh
 * @Date: 2023-01-31 19:23:12
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-17 18:06:13
 * @FilePath: \Unity-Design-Pattern\Assets\CreationalPatterns\Singleton\SingletonStarter.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WenQu.DesignPattern;
namespace WenQu.SingletonPattern
{
    public class SingletonStarter : MonoBehaviour
    {

        void Start()
        {
            TestCSharpSingleton();
            TestUnitySingleton();
        }


        void Update()
        {

        }



        private void TestCSharpSingleton()
        {
            Singleton instance = Singleton.Instance;
            Debug.LogFormat("c# singleton instance1 hashId:{0}", instance.GetHashCode());

            Singleton instance2 = Singleton.Instance;
            Debug.LogFormat("c# singleton instance2 hashId:{0}", instance2.GetHashCode());

            //#ANCHOR1
            //“Singleton.Singleton()”不可访问，因为它具有一定的保护级别 [Assembly-CSharp]csharp(CS0122)
            // Singleton obj = new Singleton();
        }



        private void TestUnitySingleton()
        {
            SoundSingleton instance = SoundSingleton.Instance;
            Debug.LogFormat("mono singleton instance1 hashId:{0}", instance.GetHashCode());

            SoundSingleton instance2 = SoundSingleton.Instance;
            Debug.LogFormat("mono singleton instance2 hashId:{0}", instance2.GetHashCode());

            // 和正统的单例不同(#Anchor1)。继承Mono的单例无法阻止玩家挂脚本，但是可以在玩家生成后立即去销毁并报一个错误
            // different from the csharp singleton(#Anchor1). The inherited Mono singleton cannot prevent the player from hanging up the script, but it can destroy it immediately after the player is generated and report an error
            SoundSingleton instance3 = this.gameObject.AddComponent<SoundSingleton>();
            Debug.LogFormat("mono singleton instance3 hashId:{0}", instance2.GetHashCode());
        }
    }
}
