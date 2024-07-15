using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Animation����
/// <summary>
public class Door : MonoBehaviour
{
    /// <summary>
    /// �ŵ�״̬
    /// </summary>
    private bool doorState = false;
    private Animation animation;
    private string animationName = "Door";
    private void Start()
    {
        animation = GetComponent<Animation>();
    }
    private void OnMouseDown()
    {
        //bool isPlay = animation.isPalying;
        //bool isPlay = animation.isPalying("������");
        //animation.Play("������");
        //animation.PlayQueued("������");
        //animation.CrossFade("������");
        //animation["������"].speed = -1;
        //animation["������"].wrapMode = WrapMode.PingPong;
        //animation["������"].length;
        //animation["������"].time;
        if (!doorState)
        {
            //���Ų���
            //������CrossFade
            //PlayQueued���Ŷ���
            animation[animationName].speed = 1;
        }
        else
        {
            //���Ų���
            if(animation.isPlaying == false)
                //�����ʼ
                animation[animationName].time = animation[animationName].length;
            
            //���𲥷�
            animation[animationName].speed = -1;
            
        }
        animation.Play(animationName);
        doorState = !doorState;
    }
}

