using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.Strategy
{
    public class Starter : MonoBehaviour
    {

        void Start()
        {
            Vector3 startPos = this.transform.position;
            Vector3 endPos = new Vector3(10, 0, 10);
            // 飞行npc
            NPC theFlyNPC = new NPC();
            // 这里可以引入建造者模式来分离构造与调用
            theFlyNPC.SetNavPlanner(new FlyNavPlanner());

            Vector3[] navPaths = theFlyNPC.GetNavPath(startPos, endPos);
            foreach (Vector3 navPath in navPaths)
            {
                Debug.Log($"flyNpc规划的路径是:{navPath}");
            }

            // 游泳npc
            NPC theSwimNPC = new NPC();
            theSwimNPC.SetNavPlanner(new SwimNavPlanner());
            navPaths = theSwimNPC.GetNavPath(startPos, endPos);
            foreach (Vector3 navPath in navPaths)
            {
                Debug.Log($"swimNpc规划的路径是:{navPath}");
            }

            // 跳跃npc
            NPC theJumpNPC = new NPC();
            theJumpNPC.SetNavPlanner(new JumpNavPlanner());
            navPaths = theJumpNPC.GetNavPath(startPos, endPos);
            foreach (Vector3 navPath in navPaths)
            {
                Debug.Log($"jumpNpc规划的路径是:{navPath}");
            }

            // 直线npc
            NPC theStraigNPC = new NPC();
            theStraigNPC.SetNavPlanner(new StraightNavPlanner());
            navPaths = theStraigNPC.GetNavPath(startPos, endPos);
            foreach (Vector3 navPath in navPaths)
            {
                Debug.Log($"straightNpc规划的路径是:{navPath}");
            }

            // Lambda表达式演示SamplePosition
            LambdaNPC commonNPC = new LambdaNPC();
            // 可写建造者模式
            commonNPC.SetSampleStrategy((pos) =>
            {
                return new Vector3(pos.x, pos.y, pos.z);
            });
            Vector3 pos = new Vector3(1, 5, 1);
            Debug.Log($"commonNPC samplePos {pos}->{commonNPC.SamplePos(pos)}");
            pos = new Vector3(2, 5, 2);
            Debug.Log($"commonNPC samplePos {pos}->{commonNPC.SamplePos(pos)}");

            LambdaNPC swimNPC2 = new LambdaNPC();
            swimNPC2.SetSampleStrategy((pos) =>
            {
                return new Vector3(pos.x, 0, pos.z);
            });
            pos = new Vector3(1, 5, 1);
            Debug.Log($"swimNPC2 samplePos {pos}->{swimNPC2.SamplePos(pos)}");
            pos = new Vector3(2, 5, 2);
            Debug.Log($"swimNPC2 samplePos {pos}->{swimNPC2.SamplePos(pos)}");

        }


    }
}