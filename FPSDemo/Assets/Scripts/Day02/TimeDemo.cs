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
        //游戏开始的时间
        //t = Time.time;
        //每帧消耗的时间
        //t = Time.deltaTime;
        
        //在Update函数里是每帧渲染 执行1次 旋转1°
        //1秒旋转 ？°
        //帧多  1秒旋转速度快，希望1帧旋转量小
        //  少            慢             大
        this.transform.Rotate(0, speed*Time.deltaTime, 0);
        //旋转速度*每帧消耗时间，可以保证移动/旋转速度不受机器性能和渲染影响

        //游戏暂停，某些物体需要不受影响
        //首先要在Update里进行操作
        //不用deltaTime，用unscaledDeltaTime;
        this.transform.Rotate(0, speed * Time.unscaledDeltaTime, 0);  
    }
    public void FixedUpdate()
    {
        //this.transform.Rotate(0, speed, 0);
    }

    public void OnGUI()
    {
        if (GUILayout.Button("暂停游戏"))
        {
            Time.timeScale = 0;
        }
        if (GUILayout.Button("继续游戏"))
        {
            Time.timeScale = 1;
        }
    }
}

