using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Compoenent类提供了查找(在当前物体、后代、先辈)组件的功能
/// <summary>
public class ComponentDeomo : MonoBehaviour
{
    private void OnGUI()
    {
        if (GUILayout.Button("transform"))
        {
            this.transform.position = new Vector3(0, 0, 10);
        }
        if (GUILayout.Button("GetComponent"))
        {
            this.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        if (GUILayout.Button("GetComponents"))
        {
            //获取所有组件
            var allComponent = this.GetComponents<Component>();
            foreach (var item in allComponent)
            {
                print(item.GetType());
            }
        }
        if (GUILayout.Button("GetComponentsInChildren"))
        {
            //获取后代物体的指定类型组件（从自身开始）
            var allComponent = this.GetComponentsInChildren<MeshRenderer>();
            foreach (var item in allComponent)
            {
                print(item.name);
                if (item.name.Equals("Cube (2)"))
                    item.material.color = Color.red;
            }
        }
        if (GUILayout.Button("GetComponentsInParent"))
        {
            //获取先辈物体的指定类型组件（从自身开始）
            var allComponent = this.GetComponentsInParent<MeshRenderer>();
            foreach (var item in allComponent)
            {
                print(item.name);
                if (item.name.Equals("Cube (2)"))
                    item.material.color = Color.red;
            }
        }
    }
}

