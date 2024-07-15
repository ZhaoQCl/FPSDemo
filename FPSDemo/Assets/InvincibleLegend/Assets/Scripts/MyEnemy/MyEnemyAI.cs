using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

/// <summary>
/// 敌人AI
/// <summary>
[RequireComponent(typeof(MyEnemyMotor))]
[RequireComponent(typeof(MyEnemyAnimation))]
[RequireComponent(typeof(MyEnemyStatusInfo))]
public class MyEnemyAI : MonoBehaviour
{
    //定义敌人状态的枚举类型
    public enum State
    {
        /// <summary>
        /// 攻击状态
        /// </summary>
        Attack,
        /// <summary>
        /// 寻路状态
        /// </summary>
        PathFinding,
        /// <summary>
        /// 死亡状态
        /// </summary>
        Death
    }
    public State currentState = State.PathFinding;
    private MyEnemyAnimation anim;
    private MyEnemyMotor motor;

    private void Start()
    {
        anim = GetComponent<MyEnemyAnimation>();
        motor = GetComponent<MyEnemyMotor>();
        gun = GetComponent<MyGun>();
    }
    /// <summary>
    /// 攻击计时
    /// </summary>
    private float attackTimer;
    /// <summary>
    /// 攻击间隔
    /// </summary>
    public float attackInterval = 3;

    private MyGun gun;
    public float delay=0.3f;
    
    private void Shoot()
    {
        gun.Firing(MyPlayerStatusInfo.Instance.headTf.position - gun.firePoint.position);
    }

    /// <summary>
    /// 攻击方法
    /// </summary>
    private void Attack()
    {
        motor.LookRotation(MyPlayerStatusInfo.Instance.headTf.position);

        //如果攻击动画没有播放就播放闲置动画
        if (!anim.action.IsPlaying(anim.attackAnimation))
        {
            anim.action.Play(anim.idleAnimation);
        }
        //达到攻击时间才进行攻击
        if (attackTimer <= Time.time)
        {
            anim.action.Play(anim.attackAnimation);
            //从枪口位置指向玩家头部位置发射攻击
            Invoke("Shoot", delay);
            attackTimer = Time.time + attackInterval;
        }
    }
    /// <summary>
    /// 寻路方法
    /// </summary>
    private void PathFinding()
    {
        //播放寻路动画
        anim.action.Play(anim.runAnimation);
        //寻路结束转换为攻击状态
        if (!motor.Pathfinding())
            currentState = State.Attack;
    }
    private void Update()
    {
        //判断状态
        switch (currentState)
        {
            case State.Attack:
                Attack();
                break;
            case State.PathFinding:
                PathFinding();
                break;
        }
    }

}

