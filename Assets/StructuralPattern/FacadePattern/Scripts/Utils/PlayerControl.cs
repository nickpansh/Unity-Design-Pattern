/*** 
 * @Author: NickPansh
 * @Date: 2023-02-10 22:08:19
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-10 22:42:17
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\FacadePattern\Scripts\Utils\PlayerControl.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WenQu.FacadePattern
{
    public class PlayerControl : MonoBehaviour
    {
        public Transform cubeTransform;
        private float moveSpeed = 5;

        private RoomControlFacade _facade;

        void Awake()
        {
            _facade = new RoomControlFacade();
        }

        void Update()
        {

            this.transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime * moveSpeed);
        }

        private void OnTriggerEnter(Collider other)
        {
            _facade.EnterRoom(other);
        }

        private void OnTriggerExit(Collider other)
        {
            _facade.ExitRoom(other);
        }
    }
}