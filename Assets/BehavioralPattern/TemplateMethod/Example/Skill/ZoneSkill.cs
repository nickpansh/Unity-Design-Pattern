namespace WenQu.TemplateMethod
{
    public class ZoneSkill : Skill
    {


        public ZoneSkill(Hero hero, float mp) : base(hero, mp)
        {
        }

        /// <summary>
        /// 检查目标是否在技能范围内
        /// check if the target is in skill range
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        protected override bool isTargetInZone(Hero target)
        {
            return true;
        }

        /// <summary>
        /// 检查目标是否存活
        /// check if the target is alive
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        protected override bool IsTargetAlive(Hero target)
        {
            return true;
        }

        /// <summary>
        /// 播放技能特效
        /// play skill effect
        /// </summary>

        protected override void ShowExecuteEffect()
        {
            // 区域技能的特效播放
            // throw new System.NotImplementedException();
        }

        /// <summary>
        /// 播放技能音效
        /// play skill sound
        /// </summary>

        protected override void PlayExecuteSound()
        {
            // 区域技能的音效播放
            // throw new System.NotImplementedException();
        }
    }
}