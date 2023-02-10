/*** 
 * @Author: NickPansh
 * @Date: 2023-02-10 09:23:58
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-10 10:47:35
 * @FilePath: \Unity-Design-Pattern\Assets\StructuralPattern\Decorator\Scripts\BadCodeExample\ConductDelete.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.DecoratorPattern.BadCode
{
    public class ConductDelete : MonoBehaviour
    {
        public int hp = 3;
        private bool _lockStatus;
        private void Awake()
        {
            _lockStatus = false;
        }
        public void Lock()
        {
            _lockStatus = true;
            this.transform.localEulerAngles = Vector3.one * 45;
        }

        public void Unlock()
        {
            _lockStatus = false;
            this.transform.localEulerAngles = Vector3.one;
        }

        public void Delete()
        {
            // 只是用来演示
            this.gameObject.SetActive(false);
        }

        private void OnMouseDown()
        {
            if (_lockStatus)
            {
                return;
            }
            hp--;
            Debug.Log($"当前hp:{hp}");
            if (hp <= 0)
            {
                Debug.Log("被删除咯");
                Delete();
            }
        }
    }
}