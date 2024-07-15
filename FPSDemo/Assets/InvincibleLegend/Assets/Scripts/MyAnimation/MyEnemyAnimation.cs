using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人动画，定义需要播放的动画片段名称
/// <summary>
public class MyEnemyAnimation : MonoBehaviour
{
    /// <summary>
    /// 跑步动画名称
    /// </summary>
    public string runAnimation;
    /// <summary>
    /// 攻击动画名称
    /// </summary>
    public string attackAnimation;
    /// <summary>
    /// 闲置动画名称
    /// </summary>
    public string idleAnimation;
    /// <summary>
    /// 死亡动画名称
    /// </summary>
    public string deathAnimation;

    /// <summary>
    /// 行为类
    /// </summary>
    public MyAnimationAction action;
    private void Awake()
    {
        action = new MyAnimationAction(this.GetComponentInChildren<Animation>());
    }
}

