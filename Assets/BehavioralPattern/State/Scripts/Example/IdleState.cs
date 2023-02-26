using UnityEngine;
namespace WenQu.State
{
    public class IdleState : IState<Character>
    {


        public void OnEnter(Character t)
        {
            //Do Nothing
        }

        public void OnExit(Character t)
        {
            //Do Nothing
        }

        public IState<Character> OnUpdate(Character t)
        {
            // 这里用的是实例化状态。
            // 若只控制单个角色可以用静态化状态。
            // 若很复杂，可以引入对象池
            // Here use the instantiation of the state.
            // If you only control a single character, you can use the static state.
            // If it is very complex, you can introduce the object pool

            if (Input.GetKeyDown(KeyCode.Space)) //space for jump
            {
                return new JumpState();
            }
            else if (Input.GetKey(KeyCode.LeftControl)) //left control for exude
            {
                return new EludeState();
            }
            return null;
        }
    }
}