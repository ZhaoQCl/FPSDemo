using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// <summary>
public class TimeGoOut : MonoBehaviour
{
    public int second = 120;
    private TextMeshProUGUI txtTimer;
    public void Start()
    {
        txtTimer = this.GetComponent<TextMeshProUGUI>();
        //Timer();

        //3、重复调用(执行方法名称，第一次执行时机，每次间隔)
        //适合简单的，每隔固定时间，重复执行
        InvokeRepeating("Timer", 1, 1);
    }

    public void Update()
    {
        //Timer();
    }
    private void Timer()
    {
        if (second > 0)
        {
            second--;
            txtTimer.text = string.Format("{0:d2}:{1:d2}", second / 60, second % 60);
            if (second < 10 && txtTimer.GetComponent<TextMeshProUGUI>().color != Color.red)
                txtTimer.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else
        {
            //取消执行某种方法
            CancelInvoke("Timer");
        }
    }

    //1、利用Time.time记录当前时间，并确定好下次修改的时间
    //需要改变时间间隔时使用 1、2
    //如果执行时间，先执行，再等待
    private float nextTime = 1;
    private void Timer1()
    {
        if (Time.time >= nextTime)
        {
            if (second > 0)
            {
                second--;
                txtTimer.text = string.Format("{0:d2}:{1:d2}", second / 60, second % 60);
                if (second < 10 && txtTimer.GetComponent<TextMeshProUGUI>().color != Color.red)
                    txtTimer.GetComponent<TextMeshProUGUI>().color = Color.red;
            }
            else
            {
                Time.timeScale = 0;
            }
            nextTime = Time.time + 1;
        }
    }


    //2、计算总时间，当deltaTime的累计达到目标时间后进行操作，然后归零
    //先等才能在做
    private float totalTime;
    private void Timer2()
    {
        totalTime += Time.deltaTime;
        if (totalTime >= 1)
        {
            if (second > 0)
            {
                second--;
                txtTimer.text = string.Format("{0:d2},{1:d2}", second / 60, second % 60);
                if (second < 10 && txtTimer.GetComponent<TextMeshProUGUI>().color != Color.red)
                    txtTimer.GetComponent<TextMeshProUGUI>().color = Color.red;
            }
            else
            {
                Time.timeScale = 0;
            }
        }
        totalTime = 0;

    }

}

