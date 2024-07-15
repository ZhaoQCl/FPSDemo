using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������Ϊ�࣬�ṩ�йض�������Ϊ
/// <summary>
public class MyAnimationAction
{
    private Animation anim;
    /// <summary>
    /// ����������Ϊ��
    /// </summary>
    /// <param name="anim">�����ڵ���ģ���ϵĶ����������</param>
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

