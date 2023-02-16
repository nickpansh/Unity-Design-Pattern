/*** 
 * @Author: NickPansh
 * @Date: 2023-02-16 12:58:25
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-16 13:17:01
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\Strategy\Scripts\Example\Strategies\SwimNavPlanner.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.Strategy
{
    public class SwimNavPlanner : AbstractNavPlanner
    {
        public override Vector3[] GetNavPath(Vector3 startPos, Vector3 endPos)
        {
            return new Vector3[] { startPos, startPos + endPos / 2 + Vector3.up * -5, endPos };
        }
    }
}