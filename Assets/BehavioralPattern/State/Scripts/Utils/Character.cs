/*** 
 * @Author: NickPansh
 * @Date: 2023-02-14 14:12:16
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-16 18:56:02
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\State\Scripts\Utils\Character.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.State
{
    public class Character : MonoBehaviour
    {
        public Animator animator;
        protected IState state;

        public virtual void Update()
        {
            if (null != state)
            {
                IState newState = state.OnUpdate(this);
                //状态切换
                //state switch
                if (null != newState)
                {
                    TransitionState(newState);
                }
            }
        }

        /// <summary>
        /// 状态切换
        /// Transition state
        /// </summary>
        /// <param name="newState"></param>
        public void TransitionState(IState newState)
        {
            Debug.Log($"状态变更{newState}");
            newState.OnEnter(this);

            if (null != state)
                state.OnExit(this);
            state = newState;
        }
    }
}
