using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// <summary>
public class MyGunAnimation : MonoBehaviour
{
    /// <summary>
    /// 开枪动画
    /// </summary>
    public string fireAnimation = "PlayerGun01_Fire";
    /// <summary>
    /// 换子弹动画
    /// </summary>
    public string updateAnimation = "PlayerGun01_UpdateAmmo";
    /// <summary>
    /// 攻击缺少子弹动画
    /// </summary>
    public string lackAnimation = "PlayerGun01_LackBullet";
    public MyAnimationAction action;
    private void Awake()
    {
        action = new MyAnimationAction(this.GetComponentInChildren<Animation>());
    }
}

