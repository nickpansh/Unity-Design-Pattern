using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.ChainOfResponsibility
{
    public class Starter : MonoBehaviour
    {
        private SkillPhase5 _skillPhase;
        public float mp;
        void Start()
        {
            //初始化技能链
            SkillPhase1 skillPhase1 = new SkillPhase1(null);
            SkillPhase2 skillPhase2 = new SkillPhase2(skillPhase1);
            SkillPhase3 skillPhase3 = new SkillPhase3(skillPhase2);
            SkillPhase4 skillPhase4 = new SkillPhase4(skillPhase3);
            _skillPhase = new SkillPhase5(skillPhase4);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _skillPhase.Handle(mp);
            }
        }

    }
}