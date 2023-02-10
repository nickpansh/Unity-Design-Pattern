/*** 
 * @Author: NickPansh
 * @Date: 2023-02-10 22:02:51
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-10 22:41:58
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\FacadePattern\Scripts\Utils\MusicManager.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System;
using UnityEngine;

namespace WenQu.FacadePattern
{
    public sealed class MusicManager
    {
        private static readonly Lazy<MusicManager> _lazy = new Lazy<MusicManager>(() => new MusicManager());
        public static MusicManager Instance
        {
            get
            {
                return _lazy.Value;
            }
        }

        public void PlayMusic(float tempeture)
        {
            // 播放音乐
            Debug.Log($"播放{tempeture}度音乐");
        }

        public void StopMusic()
        {
            Debug.Log("停止播放音乐");
        }
    }
}