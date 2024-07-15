using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 路线类
/// <summary>
public class MyWayLine
{
    /// <summary>
    /// 路点集合
    /// </summary>
    public Vector3[] WayPoints {  get; set; }

    /// <summary>
    /// 是否可用
    /// </summary>
    public bool IsUsable { get; set; }

    public MyWayLine(int pointNumber) 
    { 
        WayPoints = new Vector3[pointNumber];
        IsUsable = true;
    }
}

