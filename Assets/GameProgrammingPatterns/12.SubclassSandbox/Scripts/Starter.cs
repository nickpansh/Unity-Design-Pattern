using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WenQu.SubclassSandbox
{
    public class Starter : MonoBehaviour
    {
        SuperPower skill;
        void Start()
        {
            skill = new SkyLaunch();
            skill.Activate();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}