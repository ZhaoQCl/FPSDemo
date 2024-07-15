using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Compoenent���ṩ�˲���(�ڵ�ǰ���塢������ȱ�)����Ĺ���
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
            //��ȡ�������
            var allComponent = this.GetComponents<Component>();
            foreach (var item in allComponent)
            {
                print(item.GetType());
            }
        }
        if (GUILayout.Button("GetComponentsInChildren"))
        {
            //��ȡ��������ָ�����������������ʼ��
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
            //��ȡ�ȱ������ָ�����������������ʼ��
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

