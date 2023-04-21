/*** 
 * @Author: NickPansh
 * @Date: 2023-04-21 14:15:46
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-04-21 14:22:49
 * @FilePath: \Unity-Design-Pattern\Assets\GameProgrammingPatterns\15.Event Queue\Scripts\View\ConstDefine\UI.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System;
namespace WenQu.EventQueue
{
    public static class UI
    {

        public static Lazy<UITypeInfo> LazyRewardView = new Lazy<UITypeInfo>(() => new UITypeInfo("Prefabs/UI/pnl_reward", typeof(RewardView)));
        public static Lazy<UITypeInfo> LazyPopUpView = new Lazy<UITypeInfo>(() => new UITypeInfo("Prefabs/UI/pnl_popup", typeof(PopUpView)));
    }

}