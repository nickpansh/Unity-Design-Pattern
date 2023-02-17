using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WenQu.Prototype
{
    public class Starter : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Bird bird = new Bird();
            bird.age = 6;
            Tree treeOrigin = new Tree("Small Tree", 2.35f);
            treeOrigin.bird = bird;

            Tree treeDeepCopy = (Tree)treeOrigin.Clone();
            //深复制
            //Deep copy
            Debug.LogFormat("[Deep Copy]Before vallue modified,originTree={0},treeDeepCopy={1}", treeOrigin, treeDeepCopy);
            treeDeepCopy.height = 5.00f;
            treeDeepCopy.name = "Big Tree";
            treeDeepCopy.bird.age = 100;
            Debug.LogFormat("[Deep Copy]Before vallue modified,originTree={0},treeDeepCopy={1}", treeOrigin, treeDeepCopy);

            //浅复制
            //Shallow copy
            Tree treeShallow = treeOrigin.ShallowClone();
            Debug.LogFormat("[Shallow Copy]Before vallue modified,originTree={0},treeDeepCopy={1}", treeOrigin, treeDeepCopy);
            treeShallow.height = 5.00f;
            treeShallow.name = "Big Tree";
            treeShallow.bird.age = 100;
            //值类型没问题，引用类型会修改原值
            Debug.LogFormat("[Shallow Copy]Before vallue modified,originTree={0},treeDeepCopy={1}", treeOrigin, treeDeepCopy);

        }

    }

}
