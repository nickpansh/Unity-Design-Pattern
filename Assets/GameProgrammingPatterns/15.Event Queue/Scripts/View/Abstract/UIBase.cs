/*** 
 * @Author: NickPansh
 * @Date: 2023-04-17 08:33:40
 * @LastEditors: NickPansh
 * @LastEditTime: 2023-04-19 12:25:02
 * @FilePath: \trunk\Assets\Scripts\Logic\Skeleton\View\Abstract\UIBase.cs
 * @Description: UI界面基类
 * @
 * @Copyright (c) 2023 by nickpansh@yeah.net | wenqu.site, All Rights Reserved. 
 */


using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Assertions;

public abstract class UIBase : MonoBehaviour
{



    protected CanvasGroup _canvasGroup;

    public virtual void Initialize(params object[] args)
    {
    }
    public virtual void OnEnter()
    {
    }

    public virtual void OnExit()
    {
    }

    public abstract void Pause();
    public abstract void Resume();

    public void Destroy()
    {

        Destroy(gameObject);

    }


    protected void SetCanvasGroupEnabled(bool enabled)
    {
        if (TryGetCanvasGroup(out _canvasGroup))
        {
            _canvasGroup.alpha = enabled ? 1 : 0;
            _canvasGroup.interactable = enabled;
            _canvasGroup.blocksRaycasts = enabled;
        }
    }

    private bool TryAddCanvasGroup(out CanvasGroup canvasGroup)
    {
        canvasGroup = gameObject.AddComponent<CanvasGroup>();
        return canvasGroup != null;
    }

    private bool TryGetCanvasGroup(out CanvasGroup canvasGroup)
    {
        if (_canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
            if (canvasGroup == null && !TryAddCanvasGroup(out canvasGroup))
            {
                return false;
            }
            _canvasGroup = canvasGroup;
        }
        canvasGroup = _canvasGroup;
        return true;
    }


}