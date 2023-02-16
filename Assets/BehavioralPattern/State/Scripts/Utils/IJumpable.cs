/*** 
 * @Author: NickPansh
 * @Date: 2023-02-14 14:25:38
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-16 21:22:57
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\State\Scripts\Utils\IJumpable.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
namespace WenQu.State
{
    public interface IJumpable
    {
        public void Jump();
        public bool IsJumping();
    }
}