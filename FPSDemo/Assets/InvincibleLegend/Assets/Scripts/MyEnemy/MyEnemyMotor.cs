using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������ṩ�ƶ�����ת��Ѱ·
/// <summary>
public class MyEnemyMotor : MonoBehaviour
{
    public MyWayLine wayLine;
    public float moveSpeed = 5;
    /// <summary>
    /// ��ǰ�ƶ�
    /// </summary>
    public void MovementForward()
    {
        this.transform.Translate(0, 0, moveSpeed*Time.deltaTime);
    }


    public float rotationSpeed = 10;
    /// <summary>
    /// ת��targetPoint
    /// </summary>
    /// <param name="targetPoint"></param>
    public void LookRotation(Vector3 targetPoint)
    {
        this.transform.LookAt(targetPoint);
        //ͷ�������������壬������б
        //��ת�ٶȹ���

        //1��
        //targetPos.y = this.transform.position.y;

        //2��
        Quaternion dir =
            Quaternion.Lerp
            (
                this.transform.rotation,
                Quaternion.LookRotation(targetPoint - this.transform.position),
                rotationSpeed * Time.deltaTime
            );
        Vector3 euler = dir.eulerAngles;
        //������y����ת
        this.transform.eulerAngles = new Vector3(0, euler.y, 0);
    }

    private int currentIndex;

    /// <summary>
    /// Ѱ·����·��(Vector3[])ǰ��
    /// </summary>
    /// <returns></returns>
    public bool Pathfinding()
    {
        //false;�����յ㣬����Ѱ·
        if (wayLine==null||currentIndex >= wayLine.WayPoints.Length)
            return false;
        //����Ŀ���
        LookRotation(wayLine.WayPoints[currentIndex]);
        //��ǰ�ƶ�
        MovementForward();
        //�������Ŀ���(��ǰλ����Ŀ�����Vector3.Distance())
        //����Ŀ���(����һ��·���ƶ�)
        if (Vector3.Distance(this.transform.position, wayLine.WayPoints[currentIndex]) < 0.1)
            currentIndex++;
        //��Ҫ����Ѱ·
        return true;
    }
}

