# 数据局部性模式

## 摘要

> 通过合理组织数据利用CPU的缓存机制来加快内存访问速度

数据局部性模式指导我们在频繁执行的代码来提高CPU缓存的击中率。

为了做到缓存友好可能要牺牲一些之前做的抽象化。



## 我见

一个典型的例子是

```c#
private void Update(){
    for(int i=0;i<numEntities;i++){
        entities[i].comAI.Update();
    }
    for(int i=0;i<numEntities;i++){
        entities[i].render.Renderer();
    }
     for(int i=0;i<numEntities;i++){
        entities[i].fsm.Update();
    }
}
```

在for循环中我们遍历了指针，但指针又指向另外的内存，这就引发了缓存的低命中率。

上述代码不如：

```c#
private void Update(){
    for(int i=0;i<numEntities;i++){
        comAIs[i].Update();
    }
    for(int i=0;i<numEntities;i++){
        renders[i].Renderer();
    }
     for(int i=0;i<numEntities;i++){
        fsms[i].Update();
    }
}
```



