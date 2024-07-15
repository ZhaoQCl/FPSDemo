using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���˶�����������Ҫ���ŵĶ���Ƭ������
/// <summary>
public class MyEnemyAnimation : MonoBehaviour
{
    /// <summary>
    /// �ܲ���������
    /// </summary>
    public string runAnimation;
    /// <summary>
    /// ������������
    /// </summary>
    public string attackAnimation;
    /// <summary>
    /// ���ö�������
    /// </summary>
    public string idleAnimation;
    /// <summary>
    /// ������������
    /// </summary>
    public string deathAnimation;

    /// <summary>
    /// ��Ϊ��
    /// </summary>
    public MyAnimationAction action;
    private void Awake()
    {
        action = new MyAnimationAction(this.GetComponentInChildren<Animation>());
    }
}

