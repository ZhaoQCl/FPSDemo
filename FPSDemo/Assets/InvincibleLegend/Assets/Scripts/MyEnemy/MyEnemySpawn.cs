using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����������
/// <summary>
public class MyEnemySpawn : MonoBehaviour
{
    /// <summary>
    /// ��Ҫ�����ĵ���Ԥ�Ƽ�����
    /// </summary>
    public GameObject[] enemyType;

    /// <summary>
    /// ��������
    /// </summary>
    public int maxCount = 5;

    /// <summary>
    /// ��ʼ����������
    /// </summary>
    public int startCount = 2;

    /// <summary>
    /// �����ĵ�����
    /// </summary>
    private int spwanedCount;

    private void Start()
    {
        CalculateWayLines();
        for(int i = 0; i<startCount; i++)
            GenerateEnemy();
    }

    /// <summary>
    /// ��ǰ·������
    /// </summary>
    private MyWayLine[] lines;
    /// <summary>
    /// ����·���ڵ�
    /// </summary>
    public void CalculateWayLines()
    {
        //��ʼ��·��
        lines = new MyWayLine[this.transform.childCount];
        //ѭ����ѯ����(·��)
        for(int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
        {
            //��ʼ��lines���MyWayLine����
            Transform wayLineTf = this.transform.GetChild(lineIndex);
            lines[lineIndex] = new MyWayLine(wayLineTf.childCount);
            //��ѯ·�����·�㲢���
            for(int pointIndex = 0; pointIndex < wayLineTf.childCount; pointIndex++)
            {
                lines[lineIndex].WayPoints[pointIndex] =
                    wayLineTf.GetChild(pointIndex).position;
            }
        }
    }

    /// <summary>
    /// �������·��
    /// </summary>
    /// <returns></returns>
    public MyWayLine[] GetUsablePath()
    {
        List<MyWayLine> usablePath = new List<MyWayLine>(lines.Length);
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].IsUsable)
            {
                usablePath.Add(lines[i]);
            }
        }
        return usablePath.ToArray();
    }

    /// <summary>
    /// ��������ӳ�
    /// </summary>
    private int maxDelay = 10;
    /// <summary>
    /// ���ɵ���
    /// </summary>
    public void CreateEnemy()
    {
        //�������·��
        MyWayLine[] usablePath = GetUsablePath();
        int v = Random.Range(0, usablePath.Length);
        print("xuanze" + v);
        //���ѡһ��·
        MyWayLine myWayLine = usablePath[v];
        //����������Ͳ�����
        int randomIndex = Random.Range(0, enemyType.Length);
        GameObject enemyGO = Instantiate(enemyType[randomIndex], myWayLine.WayPoints[0], Quaternion.identity) as GameObject;

        enemyGO.GetComponent<MyEnemyMotor>().wayLine = myWayLine;
        myWayLine.IsUsable = false;

        enemyGO.GetComponent<MyEnemyStatusInfo>().spawn = this;
    }
    public void GenerateEnemy()
    {
        //ѡ��һ������·��
        if (spwanedCount < maxCount)
        {
            spwanedCount++;
            int delay = Random.Range(5, maxDelay);
            Invoke("CreateEnemy", delay);
        }
        else
        {
            print("over");
            return;
        }
    }
}

