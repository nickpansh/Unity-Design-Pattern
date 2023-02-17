/*** 
 * @Author: NickPansh
 * @Date: 2023-02-13 19:50:31
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-02-15 19:19:36
 * @FilePath: \Unity-Design-Pattern\Assets\BehavioralPattern\ChainOfResponsibility\Scripts\Example\AbstractSkill.cs
 * @Description: 抽象技能 abstract skill
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSkill
{
    /// <summary>
    /// 下一个技能
    /// next skill
    /// </summary>
    protected AbstractSkill _nextSkill;

    /// <summary>
    /// 构造函数
    /// constructor
    /// </summary>
    /// <param name="handler"></param>
    /// <returns></returns>
    public AbstractSkill(AbstractSkill nextSkill)
    {
        this._nextSkill = nextSkill;
    }

    /// <summary>
    /// 是否能处理
    /// true or not the skill can be handled
    /// </summary>
    /// <param name="mp"></param>
    /// <returns></returns>
    public abstract bool CanHandle(float mp);

    /// <summary>
    /// 处理技能
    /// </summary>
    /// <param name="mp"></param>
    public virtual void Handle(float mp)
    {
        if (null != _nextSkill)
        {
            _nextSkill.Handle(mp);
        }
    }


}
