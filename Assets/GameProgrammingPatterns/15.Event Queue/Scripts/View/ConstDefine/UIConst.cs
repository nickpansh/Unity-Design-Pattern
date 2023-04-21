/*** 
 * @Author: NickPansh
 * @Date: 2023-04-17 16:15:56
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-04-21 14:29:44
 * @FilePath: \Unity-Design-Pattern\Assets\GameProgrammingPatterns\15.Event Queue\Scripts\View\ConstDefine\UIConst.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */

namespace WenQu.EventQueue
{

    enum PriorityWindowOffset : int
    {
        Normal = 0,
        Dialog = 10 * 10,
        // 继续定义更多
        // XXX = 100 * 10,
    }

    public enum PriorityStandardOffset : int
    {
        BothActiveAndPassive = -PriorityWindowOffset.Dialog,
        ActiveOnly = 0,
    }
    public enum WindowPriority : int
    {
        ////////////////////////////
        /// 以下为预设优先级
        ////////////////////////////
        ActiveWindow = PriorityStandardOffset.ActiveOnly + PriorityWindowOffset.Normal,
        ActiveDialog = PriorityStandardOffset.ActiveOnly + PriorityWindowOffset.Dialog,
        PassiveWindow = PriorityStandardOffset.BothActiveAndPassive + PriorityWindowOffset.Normal,
        PassiveDialog = PriorityStandardOffset.BothActiveAndPassive + PriorityWindowOffset.Dialog,

        ////////////////////////////
        /// 以下为自定义优先级 
        ////////////////////////////


    }
    public enum UILayer
    {   /// <summary>
        /// 广告牌层
        /// </summary>
        Billboard = 0,
        /// <summary>
        /// 菜单层
        /// </summary>
        Menu = 1,
        /// <summary>
        /// 窗口层
        /// </summary>
        Window = 2,
        /// <summary>
        /// 引导层
        /// </summary>
        Guide = 3,
        /// <summary>
        /// 提示层
        /// </summary>
        Tip = 4,
        /// <summary>
        /// 控制台层
        /// </summary>
        Console = 5,
    }
}