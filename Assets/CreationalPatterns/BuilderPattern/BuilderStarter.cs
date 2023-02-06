using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.BuilderPattern
{
    public class BuilderStarter : MonoBehaviour
    {
        /// <summary>
        /// 使用Good Code启动还是使用Bad Code启动
        /// </summary>

        public CodeExample codeSample = CodeExample.Good;

        void Awake()
        {
            if (codeSample == CodeExample.Good)
            {
                this.gameObject.AddComponent<ActorGenreator>();
            }
            else
            {
                this.gameObject.AddComponent<BadActorGenreator>();
            }

        }

    }
}