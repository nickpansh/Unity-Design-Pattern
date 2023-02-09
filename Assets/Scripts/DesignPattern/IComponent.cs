/*** 
 * @Author: NickPansh
 * @Date: 2023-02-09 16:47:36
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-09 18:53:32
 * @FilePath: \Unity-Design-Pattern\Assets\Scripts\DesignPattern\IComponent.cs
 * @Description: 组合模式(透明组合模式)
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
namespace WenQu.DesignPattern
{
    public interface IComponent
    {
        public void Add(IComponent c);
        public void Remove(IComponent c);
        public IComponent GetChild(int i);

    }
}