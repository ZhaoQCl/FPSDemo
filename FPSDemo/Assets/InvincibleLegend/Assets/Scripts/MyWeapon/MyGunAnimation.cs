using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// <summary>
public class MyGunAnimation : MonoBehaviour
{
    /// <summary>
    /// ��ǹ����
    /// </summary>
    public string fireAnimation = "PlayerGun01_Fire";
    /// <summary>
    /// ���ӵ�����
    /// </summary>
    public string updateAnimation = "PlayerGun01_UpdateAmmo";
    /// <summary>
    /// ����ȱ���ӵ�����
    /// </summary>
    public string lackAnimation = "PlayerGun01_LackBullet";
    public MyAnimationAction action;
    private void Awake()
    {
        action = new MyAnimationAction(this.GetComponentInChildren<Animation>());
    }
}

