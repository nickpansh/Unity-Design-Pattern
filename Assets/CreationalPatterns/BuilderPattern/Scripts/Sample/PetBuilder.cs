/*** 
 * @Author: NickPansh
 * @Date: 2023-02-06 11:24:44
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-06 16:27:02
 * @FilePath: \Unity-Design-Pattern\Assets\CreationalPatterns\BuilderPattern\Scripts\Sample\PetBuilder.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WenQu.BuilderPattern
{
    public class PetBuilderParam : ActorBuilderParam
    {
        public Transform followTarget;
        public PetBuilderParam(string id, string prefabName, Transform followTarget = null)
        {
            this.id = id;
            this.prefabName = prefabName;
            this.followTarget = followTarget;
        }
    }
    public class PetBuilder : ActorBuilder
    {

        private PetBuilderParam buildParam;
        public PetBuilder(PetBuilderParam buildParam)
        {
            this.buildParam = buildParam;
        }


        public override Component AddAI()
        {
            // 可以在这里使用复杂的逻辑，用工厂添加武器
            // 这里做演示，仅仅只是添加空的武器
            PetAI com = this.gameObject.AddComponent<PetAI>();
            return com;
        }

        public override Component AddBag()
        {
            Bag com = this.gameObject.AddComponent<Bag>();
            return com;
        }
        public override bool HasBag()
        {
            return true;
        }

        public override bool HasWeapon()
        {
            return false;
        }

        public override Component AddWeapon()
        {
            throw new System.NotImplementedException();
        }

        public override void SetBaseAttr()
        {
            actor.id = this.buildParam.id;

        }

        public override GameObject LoadModel()
        {
            gameObject = (GameObject)Object.Instantiate(Resources.Load(this.buildParam.prefabName));
            this.gameObject.name = this.buildParam.id;
            return gameObject;
        }

        public override Actor AddActor()
        {
            Pet com = this.gameObject.AddComponent<Pet>();
            com.followTransform = this.buildParam.followTarget;
            return com;
        }

    }

}