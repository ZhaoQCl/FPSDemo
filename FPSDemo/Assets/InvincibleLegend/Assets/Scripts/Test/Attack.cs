using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ǹ�ڻ����ʾ������0.3�Ļ��Ч��
/// <summary>
public class Attack : MonoBehaviour
{

    public GameObject flashGO;

    /// <summary>
    /// ��ʱ��
    /// </summary>
    public float hideTimer;
    public float displayTime = 0.3f;

    public void DisplayFlash()
    {
        flashGO.SetActive(true);
        //��һ��ʱ���������
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

