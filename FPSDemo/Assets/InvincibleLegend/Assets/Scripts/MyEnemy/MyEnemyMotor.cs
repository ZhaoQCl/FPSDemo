using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人马达：提供移动、旋转、寻路
/// <summary>
public class MyEnemyMotor : MonoBehaviour
{
    public MyWayLine wayLine;
    public float moveSpeed = 5;
    /// <summary>
    /// 向前移动
    /// </summary>
    public void MovementForward()
    {
        this.transform.Translate(0, 0, moveSpeed*Time.deltaTime);
    }


    public float rotationSpeed = 10;
    /// <summary>
    /// 转向到targetPoint
    /// </summary>
    /// <param name="targetPoint"></param>
    public void LookRotation(Vector3 targetPoint)
    {
        this.transform.LookAt(targetPoint);
        //头部高于自身物体，人物倾斜
        //旋转速度过快

        //1、
        //targetPos.y = this.transform.position.y;

        //2、
        Quaternion dir =
            Quaternion.Lerp
            (
                this.transform.rotation,
                Quaternion.LookRotation(targetPoint - this.transform.position),
                rotationSpeed * Time.deltaTime
            );
        Vector3 euler = dir.eulerAngles;
        //仅仅延y轴旋转
        this.transform.eulerAngles = new Vector3(0, euler.y, 0);
    }

    private int currentIndex;

    /// <summary>
    /// 寻路，沿路线(Vector3[])前进
    /// </summary>
    /// <returns></returns>
    public bool Pathfinding()
    {
        //false;到达终点，无需寻路
        if (wayLine==null||currentIndex >= wayLine.WayPoints.Length)
            return false;
        //朝向目标点
        LookRotation(wayLine.WayPoints[currentIndex]);
        //向前移动
        MovementForward();
        //如果到达目标点(当前位置与目标点间距Vector3.Distance())
        //更新目标点(向下一个路点移动)
        if (Vector3.Distance(this.transform.position, wayLine.WayPoints[currentIndex]) < 0.1)
            currentIndex++;
        //需要继续寻路
        return true;
    }
}

