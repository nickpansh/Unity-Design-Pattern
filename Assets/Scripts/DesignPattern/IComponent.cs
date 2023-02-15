/*** 
 * @Author: NickPansh
 * @Date: 2023-02-09 16:47:36
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-15 18:30:42
 * @FilePath: \Unity-Design-Pattern\Assets\Scripts\DesignPattern\IComponent.cs
 * @Description: 组合模式(透明组合模式)
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
namespace WenQu.DesignPattern
{
    public interface IComponent
    {

        // 透明组合模式
        // 添加组件
        public void Add(IComponent c);
        // 移除组件
        public void Remove(IComponent c);
        // 获取组件
        public IComponent GetChild(int i);

        // 非透明组合模式
        // public void Operation();

    }
}