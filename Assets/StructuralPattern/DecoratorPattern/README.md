## 概要

> 装饰模式：动态地给一个对象增加一些额外的职责。
>
> 就拓展功能而言，装饰模式提供了一种比使用子类更加灵活的方案。

装饰模式是一种用于替代继承的计数，它通过一种无需定义子类的方式给对象动态增加职责—使用对象之间的关联关系取代类之间的继承关系。


![装饰者模式.drawio](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/02/10/%E8%A3%85%E9%A5%B0%E8%80%85%E6%A8%A1%E5%BC%8F.drawio.png)



更多细节可以查看[装饰设计（装饰者模式 / 装饰器模式） (refactoringguru.cn)](https://refactoringguru.cn/design-patterns/decorator)

## 需求&差代码

假设我们在开发一款我的世界。

我们有一个类叫做Block地块。

这时候来了个需求，是Block要求可以被破坏。

用继承来实现肯定不可取（DeletableBlock继承Block），这会导致继承的层次太深。

通常情况下我们会写一个ConductDelete组件，这个组件继承MonoBehaviour。

然后把ConductDelete组件挂载到Block对象上—很标准的组件化开发。

![image-20230210095853519](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/02/10/image-20230210095853519.png)

策划来了一个需求：要求赋予Block一个HP属性和Lock状态。

每次点击Block，只要这个Block不在Lock状态就扣血。

相对应的，如果Lock了，给它旋转一下，反之回正。

这个代码也很好写：

```c#
public class ConductDelete : MonoBehaviour
{
    public int hp = 3;
    private bool _lockStatus;
    private void Awake()
    {
        _lockStatus = false;
    }
    public void Lock()
    {
        _lockStatus = true;
        this.transform.localEulerAngles = Vector3.one * 45;
    }

    public void Unlock()
    {
        _lockStatus = false;
        this.transform.localEulerAngles = Vector3.one;
    }

    public void Delete()
    {
        // 只是用来演示
        this.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (_lockStatus)
        {
            return;
        }
        hp--;
        Debug.Log($"当前hp:{hp}");
        if (hp <= 0)
        {
            Debug.Log("被删除咯");
            Delete();
        }
    }
}
```

策划怕你太闲，又提出了新需求。

![](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/02/10/98a347d22938473491a531b3442c28e0.jpeg)

这个需求是：

1. 我要每次点击空格键生成一个block。

2. 我要每次按下Tab键，就把所有block的一半取true，一半取反。

   如现在场景有4个block，那就两个是true，两个是false

第一个需求很简单，在主控制器里处理键盘输入并生成block塞入数组就行了。

第二个需求……写起来有点难看，但也不是不行。我把代码贴出来。

![image-20230210111124190](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/02/10/image-20230210111124190.png)

这时候你的主管来了，它看了看你的代码，又看了看你。

开始痛心疾首没想到你的代码写的这么差，早知道当初就不该招你进来，巴拉巴拉巴拉。

你居然连**最少知道原则(LOD)**都不知道，居然写出这么深的调用！

![image-20230210102908592](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/02/10/image-20230210102908592.png)

于是你决定好好设计一番，让策划和程序主管都闭嘴



## 好代码（用装饰模式实现需求）

反思了下之前的代码，主要是没有遵循最少知道原则，函数的调用太深。

简单的方案就是给Block也提供一个SetStatus()方法，但是这样还不够好

——如果可破坏的不只是Block，那么应该有更优雅的实现来做这个翻转需求。



首先引入Deletable接口充当装饰者模式里的Component

让ConductDelete类（即装饰者模式里的ConcreteConponent）实现Deletable接口。

BlockDecorator类是装饰者模式里的Decorator，它负责抽象。

最后我们的Block就是装饰者模式里的ConcreteDecorator，它负责实现。

![装饰模式-demo.drawio](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/02/10/%E8%A3%85%E9%A5%B0%E6%A8%A1%E5%BC%8F-demo.drawio.png)

部分代码摘录如下：

IDeletable接口。

```c#
public interface IDeletable
    {
        public void Lock();
        public void Unlock();
        public void Delete();
    }
}
```



BlockDecorator类。

```c#
public class BlockDecorator : MonoBehaviour, IDeletable
{
    public IDeletable deleteConducter;

    public void Delete()
    {
        if (deleteConducter != null)
        {
            deleteConducter.Delete();
        }
    }

    public void Lock()
    {
        if (deleteConducter != null)
        {
            deleteConducter.Lock();
        }
    }

    public void Unlock()
    {
        if (deleteConducter != null)
        {
            deleteConducter.Unlock();
        }
    }
}
```

这个类的引入是为了分离装饰者和具体业务实现。

举个例子，游戏开发到后期，Block肯定不止一个具体装饰者（在这里是IDeletable deleteConducter）。

Block的代码也会很庞大。

如何面向拓展开放，面向修改关闭呢？

我们提取BlockDecorator类就是为了实现这个目的—当引入新的接口/具体装饰者时，我们只需要修改BlockDecorator就行了—这个类很简单，只有一系列的委托方法。

经过这么一系列操作后，装饰者模式被引入到了我们的代码中，我们的调用就非常好看了。

![image-20230210114353033](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/02/10/image-20230210114353033.png)


## 什么时候用

-  如果你希望在无需修改代码的情况下即可使用对象， 且希望在运行时为对象新增额外的行为， 可以使用装饰模式。
- 如果用继承来扩展对象行为的方案难以实现或者根本不可行， 你可以使用该模式。


## 其他设计模式

[专题 | Unity3D中的设计模式 | 问渠 (wenqu.site)](https://wenqu.site/Unity-Design-Pattern.html)