using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.DirtyFlag
{
    public class Player : MonoBehaviour
    {

        private readonly float speed = 5f;
        // This is the Dirty Flag
        // 脏标记位
        public bool isSaved { get; private set; } = true;
        public void Move(Vector3 direction)
        {
            transform.Translate(speed * Time.deltaTime * direction);
            isSaved = false;
        }

        public void OnSaved()
        {
            isSaved = true;
        }
    }
}