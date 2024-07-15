using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerStatusInfo : MonoBehaviour
{
    //ֻ����һ�������кܶ������Ҫ�Ҹö��󣬿���ֱ���ṩ�������ɸ���ֱ�ӵ���
    public static MyPlayerStatusInfo Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public float HP = 1000;
    public float maxHP = 1000;

    /// <summary>
    /// ���ͷ��λ�ñ任
    /// </summary>
    public Transform headTf;

    public void Damage(float amount)
    {
        HP -= amount;
        Debug.Log("���ˣ�" + HP);

        if (HP <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        Debug.Log("��Ϸ����");
    }
}
