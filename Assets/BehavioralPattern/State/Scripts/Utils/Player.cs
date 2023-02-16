/*** 
 * @Author: NickPansh
 * @Date: 2023-02-14 14:24:49
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-16 21:22:40
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\State\Scripts\Utils\Player.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;

namespace WenQu.State
{
    public class Player : Character, IMovable, IJumpable
    {

        private void Awake()
        {
            this.state = new IdleState();
        }
        public bool IsJumping()
        {
            throw new System.NotImplementedException();
        }

        public void Jump()
        {

        }

        public void Move(Vector3 velocity)
        {
            throw new System.NotImplementedException();
        }

        public void Move(float x, float y, float z)
        {
            throw new System.NotImplementedException();
        }
    }

}