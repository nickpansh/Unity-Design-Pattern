using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WenQu.ServiceLocator
{
    public class Starter : MonoBehaviour
    {

        void Start()
        {
            // 注册服务
            // Register the service
            AudioManager audioMgr = new AudioManager();
            Locator.AddManager<AudioManager>(audioMgr);
            NetworkManager networkMgr = new NetworkManager();
            Locator.AddManager<NetworkManager>(networkMgr);
        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKey(KeyCode.LeftShift))
            {
                // Shift+按键
                if (Input.GetKeyDown(KeyCode.A))
                {
                    Locator.RemoveManager<AudioManager>();
                    // 调用服务
                    // Call the service
                    Locator.GetManager<AudioManager>().PlaySound("Sound1");
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    Locator.RemoveManager<NetworkManager>();
                    // 调用服务
                    // Call the service
                    Locator.GetManager<NetworkManager>().SendData("Data1");
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    Locator.RemoveManager<NetworkManager>();
                    // 调用服务
                    // Call the service
                    Locator.GetManager<NetworkManager>().ReceiveData("Data2");
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    // 调用服务
                    // Call the service
                    Locator.GetManager<AudioManager>().PlaySound("Sound1");
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    // 调用服务
                    // Call the service
                    Locator.GetManager<NetworkManager>().SendData("Data1");
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    // 调用服务
                    // Call the service
                    Locator.GetManager<NetworkManager>().ReceiveData("Data2");
                }
            }
        }
    }
}