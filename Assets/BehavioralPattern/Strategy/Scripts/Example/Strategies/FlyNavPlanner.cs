/*** 
 * @Author: NickPansh
 * @Date: 2023-02-16 12:59:03
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-16 13:17:24
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\Strategy\Scripts\Example\Strategies\FlyNavPlanner.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.Strategy
{
    public class FlyNavPlanner : AbstractNavPlanner
    {
        public override Vector3[] GetNavPath(Vector3 startPos, Vector3 endPos)
        {
            return new Vector3[] { startPos, startPos + endPos / 2 + Vector3.up * 5, endPos };
        }
    }
}
