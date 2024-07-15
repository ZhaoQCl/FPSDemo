using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ����״̬��Ϣ�࣬�ṩ������Ϣ���ṩ���ˣ���������
/// <summary>
public class MyEnemyStatusInfo : MonoBehaviour
{
    /// <summary>
    /// ��ǰѪ��
    /// </summary>
    public float HP = 200;

    /// <summary>
    /// ���Ѫ��
    /// </summary>
    public float maxHP = 200;

    /// <summary>
    /// ����
    /// </summary>
    /// <param name="amount">��Ҫ�۳���HP</param>
    public void Damage(float amount)
    {
        this.HP -= amount;
        if(this.HP <= 0)
        {
            Death();
            return;
        }
        //��Ѫ
        //Ѫ��Ϊ0��������������
    }
    private int delayToDeath = 10;
    public MyEnemySpawn spawn;
    public void Death()
    {

        //������������
        MyEnemyAnimation deathEnemyAnimotion = this.gameObject.GetComponent<MyEnemyAnimation>();
        deathEnemyAnimotion.action.Play(deathEnemyAnimotion.deathAnimation);
        //���ٵ�ǰ����
        Destroy(this.gameObject, delayToDeath);

        //�޸�����״̬
        this.gameObject.GetComponent<MyEnemyAI>().currentState = MyEnemyAI.State.Death;
        //·����Ϊ����
        this.gameObject.GetComponent<MyEnemyMotor>().wayLine.IsUsable = true;
        //�����µĵ���
        spawn.GenerateEnemy();

        //����AI
        GetComponent<MyEnemyAI>().enabled = false;
    }
}

