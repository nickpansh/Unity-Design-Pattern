
# Unity游戏开发设计模式—备忘录模式

### 概要

> 备忘录模式:在**不破坏封装**的前提下,捕获一个对象的内部状态,并在该对象之外保存这个状态,这样就可以在以后将对象恢复到原想保存的状态



### 需求

策划来了个需求，屏幕里有个苹果。

需求是：

策划可以随便修改它的大小，旋转，位置，按回车键保存它的信息。

可以按数字键可以实现撤销N步，回到刚才的某一步。

### 实现

在Apple.cs里添加方法Restore和CreateMemento方法

```c#
// 创建备忘录
// create memento
internal AppleMemento CreateMemento()
{
    return new AppleMemento(this);
}

// 从备忘录中恢复
// restore from memento
internal void Restore(AppleMemento memento)
{
    transform.position = memento.GetStartPos();
    transform.localScale = memento.GetScale();
    transform.rotation = memento.GetRotation();

}
```

添加AppleMemento类来实现状态存储

```c#
internal class AppleMemento
{
    private Vector3 _scale;
    private Vector3 _startPos;
    private Quaternion _rotation;

    public AppleMemento(Apple apple)
    {
        _startPos = apple.GetStartPos();
        _scale = apple.GetScale();
        _rotation = apple.GetRotation();
    }

    public Vector3 GetStartPos()
    {
        return _startPos;
    }

    public Vector3 GetScale()
    {
        return _scale;
    }

    public Quaternion GetRotation()
    {
        return _rotation;
    }
}
```

再实现管理类

```c#
 public class MementoCaretaker
{
    private ArrayList _mementoList = new ArrayList();
    internal void AddMemento(AppleMemento memento)
    {
        _mementoList.Add(memento);
    }
    internal AppleMemento GetMemento(int index)
    {
        if (index >= 0 && index < _mementoList.Count)
        {
            return _mementoList[index] as AppleMemento;
        }
        else
        {
            return null;
        }
    }
    internal int GetMementoCount()
    {
        return _mementoList.Count;
    }
}
```



继而我们实现了撤销操作

```c#
AppleMemento memento = _mc.GetMemento(idx - 1);
if (null != memento)
{
    Debug.Log($"后退{offset}步到到{idx}");
    apple.Restore(memento);
}
```





### 我见

个人理解：命令模式是方法的面向对象实现，备忘录模式是存储状态的面向对象实现

二者最大的不同在于关注点不同，备忘录模式关注状态，命令模式关注指令。



### 什么时候用

- 当你需要创建对象状态快照来**恢复其之前的状态**时， 可以使用备忘录模式。
- 当直接访问对象的成员变量、 获取器或设置器将导致封装被突破时， 可以使用该模式。

### 结构

备忘录模式的核心是引入备忘录类(Memento)以及状态的拥有者原发器(Originator)。

要防止原发器以外的其他对象访问备忘录，所以要用到内部类。



### 其他设计模式

[专题 | Unity3D游戏开发中的设计模式 | 问渠 (wenqu.site)](https://wenqu.site/Unity-Design-Pattern.html)