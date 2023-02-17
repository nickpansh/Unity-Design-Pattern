/*** 
 * @Author: NickPansh
 * @Date: 2023-02-17 10:03:54
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-17 10:22:23
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\TemplateMethod\Example\Skill\Hero.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.TemplateMethod
{
    public class Hero : MonoBehaviour
    {
        public float mp;
        public void Attack()
        {
            Debug.Log("Hero Attack");
        }
        public void Move()
        {
            Debug.Log("Hero Move");
        }
        public void PlayAction()
        {
            Debug.Log("Hero PlayAction");
        }

        public bool IsAlive()
        {
            return true;
        }


    }
}