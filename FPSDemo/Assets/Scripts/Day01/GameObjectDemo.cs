using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ֱ�Ӵ��������������GameObject��AddComponent�������
/// ��Ϸ���弤����á����ݱ�ǩ����
/// <summary>
public class GameObjectDemo : MonoBehaviour
{
    private void OnGUI()
    {
        //�ڳ��������弤��״̬������ʵ�ʼ���״̬��
        //this.gameObject.activeInHierarchy
        //����������״̬��������Inspector����е�״̬��
        //this.gameObject.activeSelf
        //������������/����
        //this.gameObject.SetActive(true/false);  
        if (GUILayout.Button("��ӹ�Դ"))
        {
            Light light = this.gameObject.AddComponent<Light>();
            light.color = Color.red;
            light.type = LightType.Point;
        }

        //�ڳ����и������Ʋ������壨������ʹ�ã�
        //GameObject.Find("��Ϸ��������");

        //��ȡ����ʹ�øñ�ǩ������
        GameObject[] allEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        //���ݱ�ǩ��ȡ���壨������
        GameObject playerGO = GameObject.FindGameObjectWithTag("Enemy");

        //�������Ͳ��Ҷ���
        //�ҵ�һ��MeshRenderer���
        //Object.FindObjectOfType<MeshRenderer>();
        //��ȫ��MeshRenderer���
        //FindObjectsOfType<MeshRenderer>();
        //5s�����ٶ���
        //Object.Destroy(playerGO,5);
        //��¡����
        //Object.Instantiate(���壬λ�ã��Ƕ�);
    }
}

