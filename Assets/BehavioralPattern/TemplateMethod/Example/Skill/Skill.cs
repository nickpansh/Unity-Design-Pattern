/*** 
 * @Author: NickPansh
 * @Date: 2023-02-17 10:00:40
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-17 11:02:17
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\TemplateMethod\Example\Skill\Skill.cs
 * @Description:
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.TemplateMethod
{
    public abstract class Skill
    {

        protected float _cd;
        protected Hero _hero;

        public float mp = 0;
        public Skill(Hero hero, float mp)
        {
            this._hero = hero;
            this.mp = mp;
        }

        public void Execute(Hero target)
        {
            if (CanExecute(target))
            {
                _hero.PlayAction();
                ShowExecuteEffect();
                PlayExecuteSound();
                _cd = 0;
            }
            else
            {
                Debug.Log("技能无法释放");
            }
        }
        /// <summary>
        /// 检查是否可以释放技能
        /// check if the skill can be executed
        /// </summary>
        /// <returns></returns>
        protected bool CanExecute(Hero target)
        {
            if (!IsCDAvailable())
            {
                Debug.Log("技能正在CD中");
                return false;
            }
            else if (!IsMPAvailable())
            {
                Debug.Log("魔法值不足");
                return false;
            }
            else if (!isTargetInZone(target))
            {
                Debug.Log("目标不在技能范围内");
                return false;
            }
            else if (!IsTargetAlive(target))
            {
                Debug.Log("目标已死亡");
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// 检查技能是否在CD中
        /// check if the skill is in CD
        /// </summary>
        /// <returns></returns>
        protected bool IsCDAvailable()
        {
            return _cd <= 0;
        }

        /// <summary>
        /// 检查技能是否消耗的魔法值
        /// check is hero has enough MP to execute the skill
        /// </summary>
        /// <returns></returns>
        protected bool IsMPAvailable()
        {
            return this._hero.mp >= mp;
        }

        /// <summary>
        /// 检查目标是否在技能范围内,这里是模板方法，把具体的判断交给子类
        /// check if the target is in the skill zone, this is a template method, the specific check is delegated to the child class
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        protected abstract bool isTargetInZone(Hero target);

        /// <summary>
        /// 检查目标是否存活,这里是模板方法，把具体的判断交给子类
        /// check if the target is alive, this is a template method, the specific check is delegated to the child class
        /// </summary>
        /// <returns></returns>
        protected abstract bool IsTargetAlive(Hero target);

        /// <summary>
        /// 播放技能音效
        /// play the skill sound
        /// </summary>
        protected abstract void PlayExecuteSound();


        /// <summary>
        /// 播放技能特效
        /// play the skill effect
        /// </summary>
        protected abstract void ShowExecuteEffect();

    }
}