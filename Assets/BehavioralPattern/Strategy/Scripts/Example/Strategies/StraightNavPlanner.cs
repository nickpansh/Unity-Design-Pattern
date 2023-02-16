/*** 
 * @Author: NickPansh
 * @Date: 2023-02-16 12:59:39
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-16 13:17:09
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\Strategy\Scripts\Example\Strategies\StraightNavPlanner.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using UnityEngine;
namespace WenQu.Strategy
{
    public class StraightNavPlanner : AbstractNavPlanner
    {
        public override Vector3[] GetNavPath(Vector3 startPos, Vector3 endPos)
        {
            return new Vector3[] { startPos, new Vector3((startPos.x + endPos.x) / 2, (startPos.y + endPos.y) / 2, startPos.x) };
        }
    }
}