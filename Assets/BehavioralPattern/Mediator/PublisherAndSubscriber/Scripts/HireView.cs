using UnityEngine;

namespace WenQu.Mediator
{
    public class HireView : MonoBehaviour
    {
        private void Update()
        {
            if (Input.anyKeyDown)
            {
                EventParams param = new EventParams();
                param.Put<float>("salary", UnityEngine.Random.Range(500, 1500));
                param.Put<int>("duration", 10);
                EventManager.Instance.Publish(EventConst.Hire_NPC, this, param);
            }
        }
    }
}