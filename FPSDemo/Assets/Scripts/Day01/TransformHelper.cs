using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 变换组件助手类
/// <summary>
public class TransformHelper
{
    public static Transform GetChild(Transform parentTf, string childName)
    {
        //在子物体中查找
        Transform childTf = parentTf.Find(childName);
        if (childTf != null) return childTf;
        int count = parentTf.childCount;
        for (int i = 0; i < count; i++)
        {
            childTf = GetChild(parentTf.GetChild(i), childName);
            if (childTf != null) return childTf;
        }
        return null;
    }
}

