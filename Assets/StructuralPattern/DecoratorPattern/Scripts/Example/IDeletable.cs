using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.DecoratorPattern.Example
{
    public interface IDeletable
    {
        public void Lock();
        public void Unlock();
        public void Delete();
    }
}

