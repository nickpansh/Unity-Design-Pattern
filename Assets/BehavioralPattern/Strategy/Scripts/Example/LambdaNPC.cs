using System;
using UnityEngine;
namespace WenQu.Strategy
{
    public class LambdaNPC
    {
        private Func<Vector3, Vector3> _sampleStrategy;
        public void SetSampleStrategy(Func<Vector3, Vector3> sampleStrategy)
        {
            this._sampleStrategy = sampleStrategy;
        }

        public Vector3 SamplePos(Vector3 pos)
        {
            return this._sampleStrategy(pos);
        }

    }
}