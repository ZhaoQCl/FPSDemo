using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Animation操作
/// <summary>
public class Door : MonoBehaviour
{
    /// <summary>
    /// 门的状态
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
        //bool isPlay = animation.isPalying("动画名");
        //animation.Play("动画名");
        //animation.PlayQueued("动画名");
        //animation.CrossFade("动画名");
        //animation["动画名"].speed = -1;
        //animation["动画名"].wrapMode = WrapMode.PingPong;
        //animation["动画名"].length;
        //animation["动画名"].time;
        if (!doorState)
        {
            //开门操作
            //人物用CrossFade
            //PlayQueued播放队列
            animation[animationName].speed = 1;
        }
        else
        {
            //关门操作
            if(animation.isPlaying == false)
                //从最后开始
                animation[animationName].time = animation[animationName].length;
            
            //倒叙播放
            animation[animationName].speed = -1;
            
        }
        animation.Play(animationName);
        doorState = !doorState;
    }
}

