using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ·����
/// <summary>
public class MyWayLine
{
    /// <summary>
    /// ·�㼯��
    /// </summary>
    public Vector3[] WayPoints {  get; set; }

    /// <summary>
    /// �Ƿ����
    /// </summary>
    public bool IsUsable { get; set; }

    public MyWayLine(int pointNumber) 
    { 
        WayPoints = new Vector3[pointNumber];
        IsUsable = true;
    }
}

