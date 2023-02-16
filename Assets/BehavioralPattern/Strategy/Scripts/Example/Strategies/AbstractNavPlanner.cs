using UnityEngine;
namespace WenQu.Strategy
{
    public abstract class AbstractNavPlanner
    {
        /// <summary>
        /// 获得导航路径
        /// </summary>
        /// <returns></returns>
        public abstract Vector3[] GetNavPath(Vector3 startPos, Vector3 endPos);
    }
}