using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.EventQueue
{
    public class Starter : MonoBehaviour
    {
        private WindowManager _windowManager;
        private void Awake()
        {
            _windowManager = GetComponent<WindowManager>();
        }

        void Start()
        {
            _windowManager.Push(UI.LazyPopUpView.Value, WindowPriority.ActiveDialog);
            _windowManager.Push(UI.LazyRewardView.Value);

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _windowManager.Pop();
            }

        }
    }
}