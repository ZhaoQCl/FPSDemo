using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Transform类提供了查找(父、根、子(索引，名称))变换组件功能，改变位置、角度、大小功能
/// <summary>
public class TransformDemo : MonoBehaviour
{

    public Transform tf;
    //*********************查找变换组件***********************
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
            //获取子物体,直接子物体
            Transform childTf = this.transform.Find("子物体名称(儿子)/子物体名称(孙子)");
        }
        if (GUILayout.Button("Find"))
        {
            //根据索引获取子物体
            int count = this.transform.childCount;
            for (int i = 0; i < count; i++)
            {
                Transform childTf = this.transform.GetChild(i);
            }
        }
        if (GUILayout.Button("parent"))
        {
            //获取父物体
            Transform parentTf = this.transform.parent;
        }
        if (GUILayout.Button("setparent"))
        {
            //设置父物体
            //true：当前物体的位置视为position
            //this.transform.SetParent(tf);
            //false：当前物体的位置视为localPosition
            this.transform.SetParent(tf,false);
        }
        if (GUILayout.Button("root"))
        {
            //获取根物体
            Transform rootTf = this.transform.root;
        }
        //*********************改变位置、角度、大小***********************
        if (GUILayout.Button("position -- scale"))
        {
            //物体相当于世界坐标系的坐标
            //this.transform.position
            //物体相当于父物体轴心点的坐标
            //this.transform.localPosition

            //物体相当于父物体的缩放比例
            //this.transform.localScale
            //物体与模型缩放比例（自身缩放比例*父亲缩放比例）
            //this.transform.lossyScale
        }
        if (GUILayout.Button("Translate"))
        {
            //向自身坐标系z轴移动一米
            this.transform.Translate(0, 0, 1);

            //向世界坐标系z轴移动一米
            this.transform.Translate(0, 0, 1, Space.World);
        }
        if (GUILayout.Button("Rotate"))
        {
            //沿世界坐标系y轴旋转10°
            this.transform.Rotate(0, 10, 0, Space.World);
        }
        if (GUILayout.RepeatButton("Rotate"))
        {
            //沿世界坐标系y轴旋转10°
            this.transform.RotateAround(Vector3.zero, Vector3.up, 1);
        }

        
        //练习：在层级未知情况下查找子物体
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

