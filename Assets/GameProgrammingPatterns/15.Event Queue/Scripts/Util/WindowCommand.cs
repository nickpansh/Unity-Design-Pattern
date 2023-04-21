using System;
using UnityEngine;
using WenQu;
namespace WenQu.EventQueue
{
    /// <summary>
    /// 执行窗口UI的命令。
    /// </summary>
    public class WindowCommand : AbstractExecCommand<WindowBase>
    {
        /// <summary>
        /// 父节点Transform。
        /// </summary>
        public static Transform parentTrf;

        /// <summary>
        /// 超时时间。
        /// </summary>
        public DateTime timeoutDate;

        /// <summary>
        /// 优先级。
        /// </summary>
        public int priority;

        /// <summary>
        /// UI类型。
        /// </summary>
        private UITypeInfo _uiTypeInfo;

        /// <summary>
        /// 命令参数。
        /// </summary>
        private object[] _arguments;

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="uiTypeInfo">UI类型。</param>
        /// <param name="priority">优先级。</param>
        /// <param name="onExecuted">执行完回调函数。</param>
        /// <param name="timeout">超时时间。</param>
        /// <param name="args">命令参数。</param>
        public WindowCommand(UITypeInfo uiTypeInfo, int priority, Action<WindowBase> onExecuted, float timeout = -1, params object[] args)
        {
            this._uiTypeInfo = uiTypeInfo;
            this._arguments = args;
            this.priority = priority;
            this.onExecuted = onExecuted;
            if (timeout > 0)
            {
                timeoutDate = DateTime.Now.AddSeconds(timeout);
            }
            else
            {
                timeoutDate = DateTime.MaxValue;
            }
        }

        /// <summary>
        /// 执行命令。
        /// </summary>
        public override void Execute()
        {
            // 加载Prefab，并实例化
            GameObject prefab = Resources.Load<GameObject>(_uiTypeInfo.prefabPath);
            GameObject windowGo = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity, parentTrf);

            // 创建Window并挂载到GameObject上
            WindowBase windowUI = (WindowBase)windowGo.AddComponent(_uiTypeInfo.scriptType);
            windowUI.priority = priority;
            // 初始化Window
            windowUI.Initialize(_arguments);
            onExecuted?.Invoke(windowUI);
        }
    }
}