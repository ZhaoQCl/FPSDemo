using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 寻找最近的敌人
/// <summary>
public class LookForNearstEnemy : MonoBehaviour
{
    public void OnGUI()
    {
        if (GUILayout.Button("查找最近的敌人"))
        {
            Enemy enmey = LookForEnemy();
            enmey.transform.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
    private Enemy LookForEnemy()
    {
        Enemy[] allEnemy = FindObjectsOfType<Enemy>();
        Enemy minDisEnemy = allEnemy[0];
        Vector3 currentVector3 = this.transform.position;
        float minDistance = Distance(currentVector3, allEnemy[0].transform.position);
        for (int i = 1; i < allEnemy.Length; i++)
        {
            float distance = Distance(currentVector3, allEnemy[i].transform.position);
            if(distance < minDistance)
            {
                minDisEnemy = allEnemy[i];
                minDistance = distance;
            }
        }
        return minDisEnemy;
    }
    private float Distance(Vector3 currentVector,Vector3 targetVector)
    {
        return (float)Math.Sqrt(
                Math.Pow(currentVector.x - targetVector.x, 2) +
                Math.Pow(currentVector.y - targetVector.y, 2) +
                Math.Pow(currentVector.z - targetVector.z, 2));
    }

}

