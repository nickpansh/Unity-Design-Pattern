/*** 
 * @Author: NickPansh
 * @Date: 2023-02-22 17:39:02
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-22 18:35:12
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\Memento\Scripts\Example\AppleMemento.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.Memento
{
    internal class AppleMemento
    {
        private Vector3 _scale;
        private Vector3 _startPos;
        private Quaternion _rotation;

        public AppleMemento(Apple apple)
        {
            _startPos = apple.GetStartPos();
            _scale = apple.GetScale();
            _rotation = apple.GetRotation();
        }

        public Vector3 GetStartPos()
        {
            return _startPos;
        }

        public Vector3 GetScale()
        {
            return _scale;
        }

        public Quaternion GetRotation()
        {
            return _rotation;
        }
    }
}