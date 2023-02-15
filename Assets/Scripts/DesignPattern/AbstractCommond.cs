/*** 
 * @Author: NickPansh
 * @Date: 2023-01-28 08:17:17
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-15 16:59:34
 * @FilePath: \Unity-Design-Pattern\Assets\Scripts\DesignPattern\AbstractCommond.cs
 * @Description: 命令模式抽象父类
 * @这个类应该一直保持这个结构，保持足够通用，不应该引入构造函数，变量
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
namespace WenQu.DesignPattern
{
    public abstract class AbstractCommand
    {
        public abstract void Execute();

        public abstract void Undo();
    }
}