using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 枪口火光显示，存在0.3的火光效果
/// <summary>
public class Attack : MonoBehaviour
{

    public GameObject flashGO;

    /// <summary>
    /// 计时器
    /// </summary>
    public float hideTimer;
    public float displayTime = 0.3f;

    public void DisplayFlash()
    {
        flashGO.SetActive(true);
        //隔一段时间禁用物体
        hideTimer = Time.time + displayTime;
    }
    private void Update()
    {
        if(flashGO.activeInHierarchy && Time.time > hideTimer)
        {
            flashGO.SetActive(false);
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    DisplayFlash();
        //}
    }
}

