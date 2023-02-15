/*** 
 * @Author: NickPansh
 * @Date: 2023-02-15 17:01:29
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-15 18:11:58
 * @FilePath: \Unity-Design-Pattern\Assets\Scripts\DesignPattern\CommandQueue.cs
 * @Description: 命令队列
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections.Generic;
namespace WenQu.DesignPattern
{
    public class CommandQueue : AbstractCommand
    {
        private List<AbstractCommand> _commands = new List<AbstractCommand>();


        /// <summary>
        /// 添加命令到队列中
        /// </summary>
        /// <param name="command"></param>
        public void AddCommand(AbstractCommand command)
        {
            _commands.Add(command);
        }

        /// <summary>
        /// 从队列中移除命令
        /// </summary>
        /// <param name="command"></param>
        public void RmCommand(AbstractCommand command)
        {
            _commands.Remove(command);
        }
        /// <summary>
        /// 执行
        /// </summary>
        public override void Execute()
        {
            foreach (AbstractCommand cmd in _commands)
            {
                cmd.Execute();
            }
        }
        /// <summary>
        /// 撤销
        /// </summary>
        public override void Undo()
        {
            foreach (AbstractCommand cmd in _commands)
            {
                cmd.Undo();
            }
        }
    }
}