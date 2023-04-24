# Unity设计模式-脏标记模式

> 将工作推迟到必要时进行以避免不必要的工作



## 我见

脏标记模式也是一种优化型模式,当应用新数据的成本较高时可以考虑使用。

这个模式比较简单，一般遇到特定的使用场景时都会写。

需要特别注意的是要将改动数据的入口封装起来，来达到修改数据即修改dirtyFlag。





本例参考了[Habrador/Unity-Programming-Patterns](https://github.com/Habrador/Unity-Programming-Patterns)，对代码进行了修改，使其更符合OpenClose原则。

## 代码

```c#
 public class UnsavedChangesController : MonoBehaviour
{
    public Player player;


    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.Move(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.Move(-Vector3.forward);
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.Move(-Vector3.right);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.Move(Vector3.right);
        }
        //
        player.transform.Rotate(Vector3.up * 10 * Time.deltaTime);
    }



    private void OnGUI()
    {
        if (GUILayout.Button("Save"))
        {
            Debug.Log("Game was saved");
            player.OnSaved();

        }

        if (!player.isSaved)
        {
            GUILayout.Box("Warning you have unsaved changes");
        }
    }
}
```

```c#
namespace WenQu.DirtyFlag
{
    public class Player : MonoBehaviour
    {

        private readonly float speed = 5f;
        // This is the Dirty Flag
        // 脏标记位
        public bool isSaved { get; private set; } = true;
        public void Move(Vector3 direction)
        {
            transform.Translate(speed * Time.deltaTime * direction);
            isSaved = false;
        }

        public void OnSaved()
        {
            isSaved = true;
        }
    }
}
```

## 其他设计模式

[专题 | Unity3D游戏开发中的设计模式 | 问渠 (wenqu.site)](https://wenqu.site/Unity-Design-Pattern.html)