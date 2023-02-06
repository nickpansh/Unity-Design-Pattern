/*** 
 * @Author: NickPansh
 * @Date: 2023-02-06 11:08:21
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-06 16:08:43
 * @FilePath: \Unity-Design-Pattern\Assets\CreationalPatterns\BuilderPattern\Scripts\Sample\ActorBuilder.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.BuilderPattern
{
    // 引进这个类的目的是更贴近真实需求，参数总归是要传进来的，而不是类里写死的，而且会非常多
    public abstract class ActorBuilderParam
    {
        public string id;
        public string prefabName;

    }
    public abstract class ActorBuilder
    {
        protected Actor actor;

        protected GameObject gameObject;
        public abstract void SetBaseAttr();

        public abstract Component AddWeapon();
        public abstract Component AddAI();

        public abstract Component AddBag();
        public abstract Actor AddActor();

        public abstract GameObject LoadModel();
        public virtual bool HasBag()
        {
            return false;
        }

        public virtual bool HasWeapon()
        {
            return true;
        }

        public virtual void Reset(ActorBuilderParam buildParam)
        {
            this.actor = null;
        }

        public virtual Component AddOnClickBehaviour()
        {
            OnClickBehaviour com = this.gameObject.AddComponent<OnClickBehaviour>();
            return com;
        }

        // 这里省略了Director
        public Actor ConstructFull()
        {

            GameObject go = this.LoadModel();
            actor = this.AddActor();
            this.SetBaseAttr();
            // 钩子方法
            if (this.HasWeapon())
            {
                this.AddWeapon();
            }
            this.AddAI();
            this.AddOnClickBehaviour();
            // 钩子方法
            if (this.HasBag())
            {
                this.AddBag();
            }
            return actor;
        }

        public Actor ConstructMinimal()
        {
            GameObject go = this.LoadModel();
            actor = this.AddActor();
            this.SetBaseAttr();
            return actor;
        }
    }
}