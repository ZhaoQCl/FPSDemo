using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Transform���ṩ�˲���(����������(����������))�任������ܣ��ı�λ�á��Ƕȡ���С����
/// <summary>
public class TransformDemo : MonoBehaviour
{

    public Transform tf;
    //*********************���ұ任���***********************
    private void OnGUI()
    {
        if(GUILayout.Button("forech -- transform"))
        {
            foreach (Transform child in this.transform)
            {
                print(child.name);
            }
        }


        if (GUILayout.Button("findChild"))
        {
            //��ȡ������,ֱ��������
            Transform childTf = this.transform.Find("����������(����)/����������(����)");
        }
        if (GUILayout.Button("Find"))
        {
            //����������ȡ������
            int count = this.transform.childCount;
            for (int i = 0; i < count; i++)
            {
                Transform childTf = this.transform.GetChild(i);
            }
        }
        if (GUILayout.Button("parent"))
        {
            //��ȡ������
            Transform parentTf = this.transform.parent;
        }
        if (GUILayout.Button("setparent"))
        {
            //���ø�����
            //true����ǰ�����λ����Ϊposition
            //this.transform.SetParent(tf);
            //false����ǰ�����λ����ΪlocalPosition
            this.transform.SetParent(tf,false);
        }
        if (GUILayout.Button("root"))
        {
            //��ȡ������
            Transform rootTf = this.transform.root;
        }
        //*********************�ı�λ�á��Ƕȡ���С***********************
        if (GUILayout.Button("position -- scale"))
        {
            //�����൱����������ϵ������
            //this.transform.position
            //�����൱�ڸ��������ĵ������
            //this.transform.localPosition

            //�����൱�ڸ���������ű���
            //this.transform.localScale
            //������ģ�����ű������������ű���*�������ű�����
            //this.transform.lossyScale
        }
        if (GUILayout.Button("Translate"))
        {
            //����������ϵz���ƶ�һ��
            this.transform.Translate(0, 0, 1);

            //����������ϵz���ƶ�һ��
            this.transform.Translate(0, 0, 1, Space.World);
        }
        if (GUILayout.Button("Rotate"))
        {
            //����������ϵy����ת10��
            this.transform.Rotate(0, 10, 0, Space.World);
        }
        if (GUILayout.RepeatButton("Rotate"))
        {
            //����������ϵy����ת10��
            this.transform.RotateAround(Vector3.zero, Vector3.up, 1);
        }

        
        //��ϰ���ڲ㼶δ֪����²���������
        if (GUILayout.Button("test"))
        {
            Transform childTf = CheckChild(this.transform, "Cube (4)");
            if (childTf != null) 
                print(childTf.name);
            else 
                print(null);
        }
    }
    private Transform CheckChild(Transform transform, string childName)
    {
        Transform childTf = transform.Find(childName);
        if (childTf != null)
        {
            return childTf;
        }
        int count = transform.childCount;
        print(count);
        for (int i = 0; i < count; i++)
        {
            Transform childCountTf = transform.GetChild(i);
            print(childCountTf.name);
            childTf = CheckChild(childCountTf, childName);
            if(childTf != null)
            {
                return childTf;
            }
        }
        return null;
    }
}

