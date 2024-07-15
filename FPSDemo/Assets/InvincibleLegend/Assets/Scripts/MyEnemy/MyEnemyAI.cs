using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

/// <summary>
/// ����AI
/// <summary>
[RequireComponent(typeof(MyEnemyMotor))]
[RequireComponent(typeof(MyEnemyAnimation))]
[RequireComponent(typeof(MyEnemyStatusInfo))]
public class MyEnemyAI : MonoBehaviour
{
    //�������״̬��ö������
    public enum State
    {
        /// <summary>
        /// ����״̬
        /// </summary>
        Attack,
        /// <summary>
        /// Ѱ·״̬
        /// </summary>
        PathFinding,
        /// <summary>
        /// ����״̬
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
    /// ������ʱ
    /// </summary>
    private float attackTimer;
    /// <summary>
    /// �������
    /// </summary>
    public float attackInterval = 3;

    private MyGun gun;
    public float delay=0.3f;
    
    private void Shoot()
    {
        gun.Firing(MyPlayerStatusInfo.Instance.headTf.position - gun.firePoint.position);
    }

    /// <summary>
    /// ��������
    /// </summary>
    private void Attack()
    {
        motor.LookRotation(MyPlayerStatusInfo.Instance.headTf.position);

        //�����������û�в��žͲ������ö���
        if (!anim.action.IsPlaying(anim.attackAnimation))
        {
            anim.action.Play(anim.idleAnimation);
        }
        //�ﵽ����ʱ��Ž��й���
        if (attackTimer <= Time.time)
        {
            anim.action.Play(anim.attackAnimation);
            //��ǹ��λ��ָ�����ͷ��λ�÷��乥��
            Invoke("Shoot", delay);
            attackTimer = Time.time + attackInterval;
        }
    }
    /// <summary>
    /// Ѱ·����
    /// </summary>
    private void PathFinding()
    {
        //����Ѱ·����
        anim.action.Play(anim.runAnimation);
        //Ѱ·����ת��Ϊ����״̬
        if (!motor.Pathfinding())
            currentState = State.Attack;
    }
    private void Update()
    {
        //�ж�״̬
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

