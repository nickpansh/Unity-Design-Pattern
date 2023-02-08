/*** 
 * @Author: NickPansh
 * @Date: 2023-02-08 18:43:59
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-08 18:44:09
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\AdapterPattern\Scripts\PetEnemyAdapter.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.AdapterPattern
{
    public class PetEnemyAdapter : Enemy
    {
        public Pet pet;
        public PetEnemyAdapter(Pet pet)
        {
            this.pet = pet;
        }

        public override void PlayBeHitSound()
        {
            pet.PlayUnHappySound();
        }

        public override void PlayDieAction()
        {
            pet.PlaySleepAction();
        }
    }
}