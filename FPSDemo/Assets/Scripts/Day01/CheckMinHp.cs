using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// <summary>
public class CheckMinHp : MonoBehaviour
{
    private void OnGUI()
    {
        if (GUILayout.Button("查找血量最低的敌人"))
        {
            Enemy[] allEnemy = FindObjectsOfType<Enemy>();
            Enemy minHPEnemy = allEnemy[0];
            for (int i = 1; i < allEnemy.Length; i++)
            {
                if (allEnemy[i].HP < minHPEnemy.HP)
                {
                    minHPEnemy = allEnemy[i];
                }
            }
            minHPEnemy.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}

