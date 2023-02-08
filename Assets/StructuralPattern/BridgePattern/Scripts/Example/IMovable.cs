using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WenQu.BridgePattern
{
    public interface IMovable
    {
        public Vector3[] CalcNavPath(Vector3 pos);
    }
}