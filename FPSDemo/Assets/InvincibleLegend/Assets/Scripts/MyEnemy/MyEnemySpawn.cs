using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人生成器
/// <summary>
public class MyEnemySpawn : MonoBehaviour
{
    /// <summary>
    /// 需要创建的敌人预制件数组
    /// </summary>
    public GameObject[] enemyType;

    /// <summary>
    /// 最大敌人数
    /// </summary>
    public int maxCount = 5;

    /// <summary>
    /// 初始创建敌人数
    /// </summary>
    public int startCount = 2;

    /// <summary>
    /// 创建的敌人数
    /// </summary>
    private int spwanedCount;

    private void Start()
    {
        CalculateWayLines();
        for(int i = 0; i<startCount; i++)
            GenerateEnemy();
    }

    /// <summary>
    /// 当前路径总数
    /// </summary>
    private MyWayLine[] lines;
    /// <summary>
    /// 计算路径节点
    /// </summary>
    public void CalculateWayLines()
    {
        //初始化路线
        lines = new MyWayLine[this.transform.childCount];
        //循环查询孩子(路线)
        for(int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
        {
            //初始化lines里的MyWayLine对象
            Transform wayLineTf = this.transform.GetChild(lineIndex);
            lines[lineIndex] = new MyWayLine(wayLineTf.childCount);
            //查询路线里的路点并添加
            for(int pointIndex = 0; pointIndex < wayLineTf.childCount; pointIndex++)
            {
                lines[lineIndex].WayPoints[pointIndex] =
                    wayLineTf.GetChild(pointIndex).position;
            }
        }
    }

    /// <summary>
    /// 计算可用路径
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
    /// 生成最大延迟
    /// </summary>
    private int maxDelay = 10;
    /// <summary>
    /// 生成敌人
    /// </summary>
    public void CreateEnemy()
    {
        //计算可用路径
        MyWayLine[] usablePath = GetUsablePath();
        int v = Random.Range(0, usablePath.Length);
        print("xuanze" + v);
        //随机选一条路
        MyWayLine myWayLine = usablePath[v];
        //随机敌人类型并生成
        int randomIndex = Random.Range(0, enemyType.Length);
        GameObject enemyGO = Instantiate(enemyType[randomIndex], myWayLine.WayPoints[0], Quaternion.identity) as GameObject;

        enemyGO.GetComponent<MyEnemyMotor>().wayLine = myWayLine;
        myWayLine.IsUsable = false;

        enemyGO.GetComponent<MyEnemyStatusInfo>().spawn = this;
    }
    public void GenerateEnemy()
    {
        //选择一条可用路线
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

