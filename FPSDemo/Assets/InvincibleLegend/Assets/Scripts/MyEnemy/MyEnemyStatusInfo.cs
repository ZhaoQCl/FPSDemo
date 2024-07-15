using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 敌人状态信息类，提供敌人信息，提供受伤，死亡功能
/// <summary>
public class MyEnemyStatusInfo : MonoBehaviour
{
    /// <summary>
    /// 当前血量
    /// </summary>
    public float HP = 200;

    /// <summary>
    /// 最大血量
    /// </summary>
    public float maxHP = 200;

    /// <summary>
    /// 受伤
    /// </summary>
    /// <param name="amount">需要扣除的HP</param>
    public void Damage(float amount)
    {
        this.HP -= amount;
        if(this.HP <= 0)
        {
            Death();
            return;
        }
        //扣血
        //血量为0，调用死亡方法
    }
    private int delayToDeath = 10;
    public MyEnemySpawn spawn;
    public void Death()
    {

        //播放死亡动画
        MyEnemyAnimation deathEnemyAnimotion = this.gameObject.GetComponent<MyEnemyAnimation>();
        deathEnemyAnimotion.action.Play(deathEnemyAnimotion.deathAnimation);
        //销毁当前物体
        Destroy(this.gameObject, delayToDeath);

        //修改物体状态
        this.gameObject.GetComponent<MyEnemyAI>().currentState = MyEnemyAI.State.Death;
        //路径改为可用
        this.gameObject.GetComponent<MyEnemyMotor>().wayLine.IsUsable = true;
        //生成新的敌人
        spawn.GenerateEnemy();

        //禁用AI
        GetComponent<MyEnemyAI>().enabled = false;
    }
}

