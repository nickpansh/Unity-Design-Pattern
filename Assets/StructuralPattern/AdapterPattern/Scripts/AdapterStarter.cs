/*** 
 * @Author: NickPansh
 * @Date: 2023-02-07 11:46:21
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-08 18:33:18
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\AdapterPattern\AdapterStarter.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.AdapterPattern
{
    public class AdapterStarter : MonoBehaviour
    {
        private ArrayList enemies;
        private Pet pet;
        private bool petBecameEnemy = false;
        private void Awake()
        {
            enemies = new ArrayList();
            var boss = new Boss();
            enemies.Add(boss);
            var dogface = new DogFace();
            enemies.Add(dogface);
            pet = new Pet();
        }

        private void EnemiesBeHitted()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.BeAttack();
                enemy.PlayBeHitSound();
                enemy.PlayDieAction();
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                EnemiesBeHitted();
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                if (!petBecameEnemy)
                {
                    PetEnemyAdapter adapter = new PetEnemyAdapter(pet);
                    enemies.Add(adapter);
                    Debug.Log("pet被加入enemies数组");
                    petBecameEnemy = true;
                }
            }
        }
    }
}