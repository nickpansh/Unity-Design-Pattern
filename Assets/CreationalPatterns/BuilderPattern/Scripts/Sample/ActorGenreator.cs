using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.BuilderPattern
{
    public class ActorGenreator : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            // 生成一个Monster,没有武器
            MonsterBuilderParam buildParam1001 = new MonsterBuilderParam("monster_1001", "Prefabs/Monster", 100, 100, 0, 50);
            MonsterBuilder monsterBuilder = new MonsterBuilder(buildParam1001);
            Monster monster = (Monster)monsterBuilder.ConstructFull();

            // 生成Monster_1002,携带武器weapon002 
            var buildParam1002 = new MonsterBuilderParam("monster_1002", "Prefabs/Monster", 100, 100, 20, 50, "weapon002");
            monsterBuilder.Reset(buildParam1002);
            Monster monster2 = (Monster)monsterBuilder.ConstructFull();

            // 生成一只最基本的Monster，不设置属性
            var buildParam1003 = new MonsterBuilderParam("monster_1003", "Prefabs/Monster");
            monsterBuilder.Reset(buildParam1003);
            Monster monster3 = (Monster)monsterBuilder.ConstructMinimal();

            // 生成一只宠物,注意 这里因为用了自定义的Param，所以传的参数很精炼
            PetBuilderParam petBuilderParam = new PetBuilderParam("pet_1001", "Prefabs/Pet", monster3.gameObject.transform);
            PetBuilder petBuilder = new PetBuilder(petBuilderParam);
            Pet pet = (Pet)petBuilder.ConstructFull();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}