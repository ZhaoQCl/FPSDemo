using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerStatusInfo : MonoBehaviour
{
    //只存在一个，且有很多对象需要找该对象，可以直接提供出来，由各类直接调用
    public static MyPlayerStatusInfo Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public float HP = 1000;
    public float maxHP = 1000;

    /// <summary>
    /// 玩家头部位置变换
    /// </summary>
    public Transform headTf;

    public void Damage(float amount)
    {
        HP -= amount;
        Debug.Log("受伤：" + HP);

        if (HP <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        Debug.Log("游戏结束");
    }
}
