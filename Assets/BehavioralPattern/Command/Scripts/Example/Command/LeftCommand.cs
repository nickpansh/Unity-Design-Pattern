using UnityEngine;
namespace WenQu.Command
{
    public class LeftCommand : BaseMoveCommand
    {
        public LeftCommand(Transform transform) : base(transform)
        {
        }
        /// <summary>
        /// 获取移动方向
        /// </summary>
        /// <returns></returns>
        public override Vector3 GetDirection()
        {
            return Vector3.left;
        }

    }
}