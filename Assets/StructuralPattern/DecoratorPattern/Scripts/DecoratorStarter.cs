using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WenQu;
using BadCode = WenQu.DecoratorPattern.BadCode;
using GoodCode = WenQu.DecoratorPattern.Example;
public class DecoratorStarter : MonoBehaviour
{
    private ArrayList blocks;
    /// <summary>
    /// 使用Good Code启动还是使用Bad Code启动
    /// </summary>
    public CodeExample codeSample = CodeExample.Good;

    private void Awake()
    {
        blocks = new ArrayList();
    }
    private void GenerateOneBlock()
    {
        // 创造部分代码是一样的
        if (codeSample == CodeExample.Bad)
        {
            BadCode.BlockBuilder blockBuilder = new BadCode.BlockBuilder();
            BadCode.Block block = blockBuilder.Construct("Prefabs/Block", true);
            block.gameObject.transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
            blocks.Add(block);
        }
        else
        {
            GoodCode.BlockBuilder blockBuilder = new GoodCode.BlockBuilder();
            GoodCode.Block block = blockBuilder.Construct("Prefabs/Block", true);
            block.gameObject.transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
            blocks.Add(block);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateOneBlock(); 
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            int center = Mathf.CeilToInt(blocks.Count / 2);
            for (int i = 0; i < center; i++)
            {
                if (codeSample == CodeExample.Bad)
                {
                    BadCode.Block block = blocks[i] as BadCode.Block;
                    //调用层级过深！
                    block.gameObject.GetComponent<BadCode.ConductDelete>().Lock();
                }
                else
                {
                    GoodCode.IDeletable block = blocks[i] as GoodCode.IDeletable;
                    //装饰者模式实现了最小知道原则
                    block.Lock();
                }
            }
            for (int i = center; i <= blocks.Count - 1; i++)
            {
                if (codeSample == CodeExample.Bad)
                {
                    BadCode.Block block = blocks[i] as BadCode.Block;
                    //调用层级过深！
                    block.gameObject.GetComponent<BadCode.ConductDelete>().Unlock();
                }
                else
                {
                    GoodCode.IDeletable block = blocks[i] as GoodCode.IDeletable;
                    //装饰者模式实现了最小知道原则
                    block.Unlock();
                }
            }
        }
    }
}
