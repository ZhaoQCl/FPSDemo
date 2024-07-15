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

        //3���ظ�����(ִ�з������ƣ���һ��ִ��ʱ����ÿ�μ��)
        //�ʺϼ򵥵ģ�ÿ���̶�ʱ�䣬�ظ�ִ��
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
            //ȡ��ִ��ĳ�ַ���
            CancelInvoke("Timer");
        }
    }

    //1������Time.time��¼��ǰʱ�䣬��ȷ�����´��޸ĵ�ʱ��
    //��Ҫ�ı�ʱ����ʱʹ�� 1��2
    //���ִ��ʱ�䣬��ִ�У��ٵȴ�
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


    //2��������ʱ�䣬��deltaTime���ۼƴﵽĿ��ʱ�����в�����Ȼ�����
    //�ȵȲ�������
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

