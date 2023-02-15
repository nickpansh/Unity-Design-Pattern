using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.Iterator
{
    public class Starter : MonoBehaviour
    {
        IEnumerator<int> _enumerator;
        void Start()
        {
            var arrList = new ArrayList();
            arrList.Add("a");
            arrList.Add("b");
            arrList.Add("c");
            arrList.Add("d");
            arrList.Add("e");
            arrList.Add("f");
            arrList.Add("g");
            // foreach (var item in arrList)
            // {
            //     Debug.Log(item);
            // }

            // 效果等同于foreach
            IEnumerator i = (IEnumerator)arrList.GetEnumerator();
            while (i.MoveNext())
            {
                Debug.Log(i.Current);
            }
            _enumerator = SumAdd();
        }

        // 演示不依靠协程，也可以使用IEnumerator代码块创建可枚举方法
        IEnumerator<int> SumAdd()
        {
            int sum = 0;
            while (true)
            {
                yield return sum++;
            }
        }
        void Update()
        {
            if (Input.anyKeyDown)
            {

                _enumerator.MoveNext();
                Debug.Log(_enumerator.Current);
            }
        }
    }
}