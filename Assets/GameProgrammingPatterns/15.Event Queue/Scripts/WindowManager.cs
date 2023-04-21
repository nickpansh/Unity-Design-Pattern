using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WenQu.EventQueue
{
    /// <summary>
    /// 窗口管理器
    /// </summary>
    public class WindowManager : UIManager
    {
        /// <summary>
        /// 界面所处的UILayer层级
        /// </summary>
        public override UILayer layer => UILayer.Window;

        // 界面命令队列
        private PriorityQueue<WindowCommand, int> _cmdQueue = new PriorityQueue<WindowCommand, int>();

        // UI栈
        public Stack<WindowBase> _uiStack = new Stack<WindowBase>();

        // 标准优先级，低于该优先级的界面不显示
        private int _horizonLinePriority = (int)PriorityStandardOffset.BothActiveAndPassive;

        private void Start()
        {
            Debug.Log("WindowManager Start");
            WindowCommand.parentTrf = this.transform;
        }

        /// <summary>
        /// 设置标准优先级，低于该值的命令将会被丢弃
        /// </summary>
        /// <param name="priority"></param>
        public void SetHorizonLinePriority(PriorityStandardOffset priority)
        {
            _horizonLinePriority = (int)priority;
        }

        /// <summary>
        /// 入栈界面
        /// </summary>
        /// <param name="uiTypeInfo">界面类型</param>
        /// <param name="windowPriority">界面优先级</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="args">参数</param>
        public void Push(UITypeInfo uiTypeInfo, WindowPriority windowPriority = WindowPriority.ActiveWindow, float timeout = -1, params object[] args)
        {
            int priority = (int)windowPriority;
            // 优先级小于水平优先级，则直接丢弃
            if (priority < _horizonLinePriority)
            {
                return;
            }

            // 创建窗口命令
            var cmd = new WindowCommand(uiTypeInfo, priority, (WindowBase ui) =>
            {
                this._uiStack.Push(ui);
                ui.OnEnter();
            }, timeout, args);

            // 加入界面命令队列中
            _cmdQueue.Enqueue(cmd, priority);
            TryDequeue();
        }

        /// <summary>
        /// 出栈界面
        /// </summary>
        public void Pop()
        {
            if (_uiStack.Count > 0)
            {
                var ui = _uiStack.Pop();
                ui.OnExit();
                ui.Destroy();
            }
            TryDequeue();
        }

        // 尝试出队执行命令
        private void TryDequeue()
        {
            // 检查超时命令
            DequeueTimeoutCommands();
            // 比对优先级
            int topUIPriority = _uiStack.Count > 0 ? _uiStack.Peek().priority : -1;
            int topCmdPriority = _cmdQueue.Count > 0 ? _cmdQueue.Peek().priority : -1;
            if (topCmdPriority >= topUIPriority) //若命令队列里有优先级更高的界面，则显示该界面
            {
                if (topCmdPriority == topUIPriority && _uiStack.Count > 0)
                {
                    // 相同优先级需要先隐藏当前界面
                    _uiStack.Peek().Pause();
                }
                if (_cmdQueue.Count > 0)
                {
                    var cmd = _cmdQueue.Dequeue();
                    cmd.Execute();
                }
            }

            else // 若命令队列里无优先级更高的界面，则显示底下的界面(若有)
            {
                if (_uiStack.Count > 0)
                {
                    _uiStack.Peek().Resume();
                }
            }
        }

        // 检查超时命令并移除
        private void DequeueTimeoutCommands()
        {
            while (_cmdQueue.Count > 0)
            {
                var command = _cmdQueue.Peek();
                // 若已超时，移除该命令
                if (DateTime.Now > command.timeoutDate)
                {
                    _cmdQueue.Dequeue();
                }
                else
                {
                    break;
                }
            }
        }
    }
}