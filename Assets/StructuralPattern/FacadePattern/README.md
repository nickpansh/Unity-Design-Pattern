
## 概要

> 外观模式：为子系统中的一组接口提供一个统一的入口。
>
> 外观模式定义了一个高层接口，这个接口使得这一子系统更加容易使用。

<!-- more -->

![](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/02/10/structure.png)

## 需求&差代码

你在开发模拟人生游戏。

![](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/02/10/image001_S.jpg)

策划提出一个需求，当玩家走到房间触发器的时候要：

- WeatherManager.Instance.GetTempeture()

  获得当前的温度

- MusicManager.Instance.PlayMusic(tempeture)

  根据温度不同，音乐系统播放不同的音乐

- LightSystem.ModifyColor(tempeture)

  根据温度不同，灯光调节颜色

- Env.LowComputeCost()

  场景进入低运算模式

- Application.targetFrameRate= 60

  小屋里希望按60帧的设计运行

- hero.Happy()

  主角进入开心模式

当玩家离开房间触发器的时候也调用相对应的方法

看起来都是很合理的需求，就是功能很分散……要同时和一堆框架类交互。

房间触发器是你的同事开发的，其他系统都是你开发的，于是你甩给他这样一段代码

```c#
// 在触发器Enter的时候调用一下我这一段逻辑啊
private void OnTriggerEnter(){
    float tempeture = WeatherManager.Instance.GetTempeture();
    MusicManager.Instance.PlayMusic(tempeture);
    LightSystem.ModifyColor(tempeture);
    Env.LowComputeCost();
    Application.targetFrameRate = 60;
    hero.Happy()
}

// 在触发器离开的时候调用一下我这一段逻辑啊
private void OnTriggerExit(){
    MusicManager.Instance.StopMusic();
    LightSystem.Close(room);
    Env.HighComputeCost();
    Application.targetFrameRate = 30;
    hero.Unhappy()
}
```

你的同事看了看你，面露难色，说了一句：大哥，你不觉得你这一段代码太复杂了吗，我看也看不懂啊……



![](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/02/10/201782513515278029.jpg))



沉默了片刻，你觉得他说的有道理。

不能因为想下班就这么敷衍交差啊……

于是你想到了用外观模式包装一下……

不到2分钟，你把代码写出来了。

然后给同事重新留言：

```c#
RoomControlFacade facade = new RoomControlFacade();
// 在触发器Enter的时候调用一下我这一段逻辑啊
private void OnTriggerEnter(){
    facade:EnterRoom()
}

// 在触发器离开的时候调用一下我这一段逻辑啊
private void OnTriggerExit(){
   	facade:ExitRoom()
}
```





![](https://wenqu-1315878694.cos.ap-shanghai.myqcloud.com/www/uploads/2023/02/10/91b8bdcf59.gif)



同事感慨：大神就是大神，2分钟就改好了，于是看commit log开始学起你的代码。

并在笔记本里记录下了这句话：**如果你的程序需要与包含几十种功能的复杂库整合， 但只需使用其中非常少的功能， 那么使用外观模式会非常方便。**

## 好代码（用外观模式实现需求）

```c#
//为了将框架的复杂性隐藏在一个简单接口背后，我们创建了一个外观类。它是在
//功能性和简洁性之间做出的权衡。
public class RoomControlFacade
{
    public void EnterRoom(Collider collider)
    {
        float tempeture = WeatherManager.Instance.GetTempeture();
        MusicManager.Instance.PlayMusic(tempeture);
        Application.targetFrameRate = 60;
        // LightSystem.ModifyColor(tempeture);
        // Env.LowComputeCost();
        // hero.Happy()
        // 等等一系列方法
    }

    public void ExitRoom(Collider collider)
    {
        MusicManager.Instance.StopMusic();
        Application.targetFrameRate = 30;
        // Env.HighComputeCost();
        // Application.targetFrameRate = 30;
        // hero.Unhappy()
        // 等等一系列方法
    }
}

```




### 其他设计模式

[专题 | Unity3D中的设计模式 | 问渠 (wenqu.site)](https://wenqu.site/Unity-Design-Pattern.html)