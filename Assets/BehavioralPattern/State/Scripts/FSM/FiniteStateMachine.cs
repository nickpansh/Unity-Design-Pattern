/*** 
 * @Author: NickPansh
 * @Date: 2023-02-26 10:40:38
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-28 14:20:32
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\State\Scripts\FSMExample\FiniteStateMachine.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.State
{
    /// <summary>
    /// 有限状态机
    /// </summary>
    public class FiniteStateMachine<T>
    {
        /// <summary>
        /// 当前状态
        /// </summary>
        public IState<T> currentState { get; private set; }

        /// <summary>
        /// 上一个状态
        /// </summary>
        public IState<T> previousState { get; private set; }

        /// <summary>
        /// 全局状态
        /// </summary>
        public IState<T> globalState { get; private set; }

        /// <summary>
        /// 状态机拥有者
        /// </summary>
        public T owner { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="owner"></param> nm 
        public FiniteStateMachine(T owner)
        {
            this.owner = owner;
        }

        /// <summary>
        /// 设置当前状态
        /// </summary>
        /// <param name="state"></param>
        public void SetCurrentState(IState<T> state)
        {
            currentState = state;
        }

        /// <summary>
        /// 设置全局状态
        /// </summary>
        /// <param name="state"></param>
        public void SetGlobalState(IState<T> state)
        {
            globalState = state;
        }

        /// <summary>
        /// 设置上一个状态
        /// </summary>
        /// <param name="state"></param>
        public void SetPreviousState(IState<T> state)
        {
            previousState = state;
        }

        /// <summary>
        /// 状态翻转
        /// </summary>
        public void RevertToPreviousState()
        {
            ChangeState(previousState);
        }

        /// <summary>
        /// 初始化状态机
        /// </summary>
        /// <param name="owner"></param>
        private void Init(T owner)
        {
            this.owner = owner;
        }


        /// <summary>
        /// 更新状态机
        /// </summary>
        public void Update()
        {
            if (globalState != null)
            {
                globalState.OnUpdate(owner);
            }

            if (currentState != null)
            {
                // 如果当前状态返回了一个新的状态，就切换到新的状态
                if (currentState.OnUpdate(owner) != null)
                {
                    ChangeState(currentState.OnUpdate(owner));
                }
            }
        }

        /// <summary>
        /// 改变状态
        /// </summary>
        /// <param name="newState"></param>
        public void ChangeState(IState<T> newState)
        {
            if (newState == null)
            {
                Debug.LogError("newState is null");
                return;
            }

            previousState = currentState;

            if (currentState != null)
            {
                // Debug.LogFormat("Exit State: {0}", currentState.GetType().Name);
                currentState.OnExit(owner);
            }

            currentState = newState;

            if (currentState != null)
            {
                // Debug.LogFormat("Enter State: {0}", currentState.GetType().Name);
                currentState.OnEnter(owner);
            }
        }

    }
}