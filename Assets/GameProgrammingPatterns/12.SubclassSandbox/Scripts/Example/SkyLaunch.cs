/*** 
 * @Author: NickPansh
 * @Date: 2023-04-12 08:37:41
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-04-12 08:54:23
 * @FilePath: \Unity-Design-Pattern\Assets\GameProgrammingPatterns\12.Subclass Sandbox\Scripts\Example\SkyLaunch.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
namespace WenQu.SubclassSandbox
{
    public class SkyLaunch : SuperPower
    {
        public override void Activate()
        {
            if (GetPosY() == 0)
            {
                PlaySound("Sound_SPRONING");
                SpawnParticles("Particles_DUST");
                Move(0, 100, 0);
            }
            else if (GetPosY() < 10.0f)
            {
                PlaySound("Sound_FLYING");
                Move(0, 0, 10);
            }
            else
            {
                PlaySound("Sound_LANDING");
                SpawnParticles("Particles_DUST");
                Move(0, 0, 0);
            }
        }
    }
}