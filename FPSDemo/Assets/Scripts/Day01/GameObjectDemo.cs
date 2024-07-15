using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 不直接创建组件，可以用GameObject的AddComponent方法添加
/// 游戏物体激活、启用、根据标签查找
/// <summary>
public class GameObjectDemo : MonoBehaviour
{
    private void OnGUI()
    {
        //在场景中物体激活状态（物体实际激活状态）
        //this.gameObject.activeInHierarchy
        //物体自身激活状态（物体在Inspector面板中的状态）
        //this.gameObject.activeSelf
        //设置物体启用/禁用
        //this.gameObject.SetActive(true/false);  
        if (GUILayout.Button("添加光源"))
        {
            Light light = this.gameObject.AddComponent<Light>();
            light.color = Color.red;
            light.type = LightType.Point;
        }

        //在场景中根据名称查找物体（不建议使用）
        //GameObject.Find("游戏对象名称");

        //获取所有使用该标签的物体
        GameObject[] allEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        //根据标签获取物体（单个）
        GameObject playerGO = GameObject.FindGameObjectWithTag("Enemy");

        //根据类型查找对象
        //找第一个MeshRenderer组件
        //Object.FindObjectOfType<MeshRenderer>();
        //找全部MeshRenderer组件
        //FindObjectsOfType<MeshRenderer>();
        //5s后销毁对象
        //Object.Destroy(playerGO,5);
        //克隆物体
        //Object.Instantiate(物体，位置，角度);
    }
}

