using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// <summary>
public class TimeDemo : MonoBehaviour
{
    public float speed = 100;
    public void Update()
    {
        //��Ϸ��ʼ��ʱ��
        //t = Time.time;
        //ÿ֡���ĵ�ʱ��
        //t = Time.deltaTime;
        
        //��Update��������ÿ֡��Ⱦ ִ��1�� ��ת1��
        //1����ת ����
        //֡��  1����ת�ٶȿ죬ϣ��1֡��ת��С
        //  ��            ��             ��
        this.transform.Rotate(0, speed*Time.deltaTime, 0);
        //��ת�ٶ�*ÿ֡����ʱ�䣬���Ա�֤�ƶ�/��ת�ٶȲ��ܻ������ܺ���ȾӰ��

        //��Ϸ��ͣ��ĳЩ������Ҫ����Ӱ��
        //����Ҫ��Update����в���
        //����deltaTime����unscaledDeltaTime;
        this.transform.Rotate(0, speed * Time.unscaledDeltaTime, 0);  
    }
    public void FixedUpdate()
    {
        //this.transform.Rotate(0, speed, 0);
    }

    public void OnGUI()
    {
        if (GUILayout.Button("��ͣ��Ϸ"))
        {
            Time.timeScale = 0;
        }
        if (GUILayout.Button("������Ϸ"))
        {
            Time.timeScale = 1;
        }
    }
}

