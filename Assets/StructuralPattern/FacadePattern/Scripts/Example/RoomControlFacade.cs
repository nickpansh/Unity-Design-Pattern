/*** 
 * @Author: NickPansh
 * @Date: 2023-02-10 22:16:43
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-10 22:27:14
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\FacadePattern\Scripts\Example\RoomControlFacade.cs
 * @Description: 为了将框架的复杂性隐藏在一个简单接口背后，我们创建了一个外观类。它是在
 * @功能性和简洁性之间做出的权衡。
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.FacadePattern
{
    public class RoomControlFacade
    {
        public void EnterRoom(Collider collider)
        {
            float tempeture = WeatherManager.Instance.GetTempeture();
            MusicManager.Instance.PlayMusic(tempeture);
            Application.targetFrameRate = 60;
            // LightSystem.ModifyColor(tempeture);
            // Env.LowComputeCost();
            // hero.Happy()
            // 等等一系列方法
        }

        public void ExitRoom(Collider collider)
        {
            MusicManager.Instance.StopMusic();
            Application.targetFrameRate = 30;
            // Env.HighComputeCost();
            // Application.targetFrameRate = 30;
            // hero.Unhappy()
            // 等等一系列方法
        }
    }
}