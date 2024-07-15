using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 动画行为类，提供有关动画的行为
/// <summary>
public class MyAnimationAction
{
    private Animation anim;
    /// <summary>
    /// 创建动画行为类
    /// </summary>
    /// <param name="anim">附加在敌人模型上的动画组件引用</param>
    public MyAnimationAction(Animation anim)
    {
        this.anim = anim;
    }
    public bool IsPlaying(string animName) 
    {
        return anim.IsPlaying(animName);
    }

    public void Play(string animName)
    {
        if (anim != null && !string.IsNullOrEmpty(animName))
            anim.CrossFade(animName);
    }

    public void PlayQueued(string animName)
    {
        if (anim != null && !string.IsNullOrEmpty(animName))
            anim.PlayQueued(animName);
    }
}

