/*** 
 * @Author: NickPansh
 * @Date: 2023-04-12 08:34:57
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-04-12 08:53:39
 * @FilePath: \Unity-Design-Pattern\Assets\GameProgrammingPatterns\12.Subclass Sandbox\Scripts\Example\SuperPower.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.SubclassSandbox
{
    public abstract class SuperPower
    {

        public abstract void Activate();
        protected void Move(float x, float y, float z)
        {
            Debug.Log("Move to " + x + "," + y + "," + z);
        }

        protected float GetPosY()
        {
            return 0;
        }

        protected void PlaySound(string soundName)
        {
            Debug.Log("Play sound " + soundName);
        }

        protected void SpawnParticles(string particleName)
        {
            Debug.Log("Spawn particles " + particleName);
        }
    }
}