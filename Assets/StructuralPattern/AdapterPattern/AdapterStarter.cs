using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.Adapter
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

    public class AdapterStarter : MonoBehaviour
    {
        void Start()
        {
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