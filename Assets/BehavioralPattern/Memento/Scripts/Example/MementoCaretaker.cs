/*** 
 * @Author: NickPansh
 * @Date: 2023-02-22 18:03:03
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-22 18:48:50
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\Memento\Scripts\Example\MementoCaretaker.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;

namespace WenQu.Memento
{
    public class MementoCaretaker
    {
        private ArrayList _mementoList = new ArrayList();
        internal void AddMemento(AppleMemento memento)
        {
            _mementoList.Add(memento);
        }
        internal AppleMemento GetMemento(int index)
        {
            if (index >= 0 && index < _mementoList.Count)
            {
                return _mementoList[index] as AppleMemento;
            }
            else
            {
                return null;
            }
        }
        internal int GetMementoCount()
        {
            return _mementoList.Count;
        }
    }
}

