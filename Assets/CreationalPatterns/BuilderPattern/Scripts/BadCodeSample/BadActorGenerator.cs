using UnityEngine;
namespace WenQu.BuilderPattern
{
    public class BadActorGenreator : MonoBehaviour
    {
        private void Awake()
        {
            // Bad Code
            // 很明显看到，创建化的代码散落在各地，各种复制粘贴，很不好
            // 也违背了单一职责原则
            // 以下方法如果写到Monster类里的话，传参也会很长，依然不好看
            // 这里演示在调用方构造

            // 生成一个Monster,没有武器
            GameObject gameObject = LoadModel("Prefabs/Monster", "monster_1001");
            Monster monster = gameObject.AddComponent<Monster>();
            monster.hp = 100;
            monster.maxHp = 100;
            monster.mp = 0;
            monster.maxMp = 50;
            gameObject.AddComponent<MonsterAI>();
            gameObject.AddComponent<OnClickBehaviour>();

            // 生成Monster_1002,携带武器weapon002 
            GameObject gameObject2 = LoadModel("Prefabs/Monster", "monster_1002");
            Monster monster2 = gameObject2.AddComponent<Monster>();
            monster.hp = 100;
            monster.maxHp = 100;
            monster.mp = 20;
            monster.maxMp = 50;
            gameObject2.AddComponent<MonsterAI>();
            gameObject2.AddComponent<OnClickBehaviour>();
            Weapon weapon = gameObject2.AddComponent<Weapon>();
            weapon.weaponId = "weapon002";

            // 生成一只最基本的Monster，不设置属性
            GameObject gameObject3 = LoadModel("Prefabs/Monster", "monster_1003");
            Monster monster3 = gameObject3.AddComponent<Monster>();

            // 生成一只宠物
            GameObject gameObjectPet = LoadModel("Prefabs/Pet", "pet_1001");
            Pet pet = gameObjectPet.AddComponent<Pet>();
            pet.followTransform = monster3.gameObject.transform;
            gameObjectPet.AddComponent<PetAI>();
            gameObjectPet.AddComponent<OnClickBehaviour>();
            gameObjectPet.AddComponent<Bag>();

        }

        private GameObject LoadModel(string prefabName, string id)
        {
            GameObject gameObject = (GameObject)Object.Instantiate(Resources.Load(prefabName));
            gameObject.name = id;
            return gameObject;

        }
    }


}