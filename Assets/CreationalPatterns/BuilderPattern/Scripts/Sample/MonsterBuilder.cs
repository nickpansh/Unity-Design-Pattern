using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WenQu.BuilderPattern
{
    public class MonsterBuilderParam : ActorBuilderParam
    {
        public float hp;
        public float maxHp;
        public float mp;
        public float maxMp;
        public string weaponId;
        public MonsterBuilderParam(string id, string prefabName, float hp, float maxHp, float mp, float maxMp, string weaponId = null)
        {
            this.id = id;
            this.prefabName = prefabName;
            this.hp = hp;
            this.maxHp = maxHp;
            this.mp = mp;
            this.maxMp = maxMp;
            this.weaponId = weaponId;
        }

        public MonsterBuilderParam(string id, string prefabName)
        {
            this.id = id;
            this.prefabName = prefabName;
        }

    }
    public class MonsterBuilder : ActorBuilder
    {
        private MonsterBuilderParam buildParam;
        public MonsterBuilder(MonsterBuilderParam buildParam)
        {
            this.buildParam = buildParam;
        }


        public override Component AddAI()
        {
            // 可以在这里使用复杂的逻辑，用工厂添加武器
            // 这里做演示，仅仅只是添加空的武器
            MonsterAI com = this.gameObject.AddComponent<MonsterAI>();
            return com;
        }



        public override Component AddWeapon()
        {
            // 可以在这里使用复杂的逻辑，用工厂添加武器
            // 这里做演示，仅仅只是添加空的武器
            Weapon com = this.gameObject.AddComponent<Weapon>();
            com.weaponId = this.buildParam.weaponId;
            return com;
        }

        public override bool HasBag()
        {
            return false;
        }

        public override bool HasWeapon()
        {
            return this.buildParam.weaponId != null;
        }
        public override Component AddBag()
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
            Monster com = this.gameObject.AddComponent<Monster>();
            com.hp = this.buildParam.hp;
            com.mp = this.buildParam.mp;
            com.maxHp = this.buildParam.maxHp;
            com.maxMp = this.buildParam.maxMp;
            return com;
        }

        public override void Reset(ActorBuilderParam buildParam)
        {
            base.Reset(buildParam);
            this.buildParam = (MonsterBuilderParam)buildParam;
        }
    }
}
