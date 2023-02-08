using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WenQu.BridgePattern
{
    public class MyLogHandler : ILogHandler
    {
        public void LogException(Exception exception, UnityEngine.Object context)
        {
            // 自定义的LogException方法
        }



        public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
        {
            // 自定义的Log方法
        }
    }

    public class BridgeStarter : MonoBehaviour
    {

        private void Awake()
        {

            // 调用自己实现的Bridge
            Elf flyElf = new Elf();
            flyElf.movable = new Flyable();
            flyElf.NavTo(new Vector3(10, 5, 10));

            Npc flyNpc = new Npc();
            flyNpc.movable = new Flyable();
            flyNpc.NavTo(new Vector3(10, 5, 10));

            Elf walkElf = new Elf();
            walkElf.movable = new Walkable();
            walkElf.NavTo(new Vector3(10, 0, 10));

            Npc walkNpc = new Npc();
            walkNpc.movable = new Walkable();
            walkNpc.NavTo(new Vector3(10, 0, 10));

            // 自定义Log
            Debug.Log("Before Custom Log...");
            Debug.Log("TestLog");
            Debug.LogWarning("TestWarning");
            Debug.LogError("TestError");
            Debug.LogException(new Exception("TestException"));
            Debug.Log("After Custom Log...");
            Debug.unityLogger.logHandler = new MyLogHandler();
            Debug.Log("TestLog");
            Debug.LogWarning("TestWarning");
            Debug.LogError("TestError");
            Debug.LogException(new Exception("TestException"));

        }

    }
}