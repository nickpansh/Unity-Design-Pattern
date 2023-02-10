using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.DecoratorPattern.Example
{
    public class Block : BlockDecorator
    {
        public void PrintMe()
        {
            Debug.Log($"Block|go的名字是{this.gameObject.name}");
        }

    }
}