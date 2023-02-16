using System;
using UnityEngine;
namespace WenQu.Strategy
{
    public class LambdaNPC
    {
        private Func<Vector3, Vector3> _sampleStrategy;

        /// <summary>
        /// 设置采样策略
        /// </summary>
        /// <param name="sampleStrategy"></param>
        public void SetSampleStrategy(Func<Vector3, Vector3> sampleStrategy)
        {
            this._sampleStrategy = sampleStrategy;
        }

        /// <summary>
        /// 采样位置
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public Vector3 SamplePos(Vector3 pos)
        {
            return this._sampleStrategy(pos);
        }

    }
}