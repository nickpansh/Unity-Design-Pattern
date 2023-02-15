using UnityEngine;
namespace WenQu.Mediator
{
    public class NPC : MonoBehaviour
    {
        private Animator _animator;
        private void Awake()
        {
            EventManager.Instance.Subscribe(EventConst.Hire_NPC, PlayHappy);
            _animator = this.gameObject.GetComponent<Animator>();
        }

        private void PlayHappy(object sender, EventParams eventParams)
        {
            Debug.Log($"npc接收到事件sender={sender},param={eventParams}");
            float salary = eventParams.Get<float>("salary");
            if (salary > 1000)
            {
                Debug.Log("salary>1000,播放跳跃动作");
                _animator.SetTrigger(Animator.StringToHash("Jump"));
            }
            else
            {
                Debug.Log("salary<=1000,播放难过动作");
                _animator.SetTrigger(Animator.StringToHash("Unhappy"));
            }
        }
    }
}