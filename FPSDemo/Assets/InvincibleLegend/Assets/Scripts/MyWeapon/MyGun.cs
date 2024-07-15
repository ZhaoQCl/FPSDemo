using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 定义枪的共有方法
/// <summary>
[RequireComponent(typeof(AudioSource))]

public class MyGun : MonoBehaviour
{
    public float atk;
    public float atkDistance = 200;

    public GameObject bulletPrefab;

    private AudioSource audioSource;
    /// <summary>
    /// 发射子弹的音频片段
    /// </summary>
    public AudioClip clip;
    public MyGunAnimation anim;

    private GunFlash flash;
    public Transform firePoint;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        clip = GetComponent<AudioClip>();
        anim = GetComponent<MyGunAnimation>();
        flash = firePoint.GetComponent<GunFlash>();
    }
    /// <summary>
    /// 开火
    /// </summary>
    /// <param name="dir"></param>
    public void Firing(Vector3 dir)
    {
        
        //是否可以发射子弹
        if(anim != null && !Ready()) return;
        //创建子弹对象
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(dir)) as GameObject;
        //初始化子弹数据
        bulletGO.GetComponent<MyBullet>().Init(atk, atkDistance);
        //播放声音
        audioSource.Play();
        //播放射击动画
        if(anim)anim.action.PlayQueued(anim.fireAnimation);
        //显示火光
        flash.DisplayFlash();

    }
    /// <summary>
    /// 准备子弹
    /// </summary>
    /// <returns></returns>
    private bool Ready()
    {
        //判断弹夹内是否包含子弹或者是否播放换弹动画
        if (currentAmmoBullets <= 0 || anim.action.IsPlaying(anim.updateAnimation)) return false;
        currentAmmoBullets--;
        if (currentAmmoBullets == 0)
            anim.action.PlayQueued(anim.lackAnimation);
        return true;
    }
    //弹夹容量
    public int ammoCapacity=30;
    //当前弹夹内子弹数
    public int currentAmmoBullets=30;
    //剩余子弹数
    public int remainAmmoBullets=270;

    /// <summary>
    /// 更换弹夹
    /// </summary>
    public void UpdateAmmo()
    {
        if(currentAmmoBullets == ammoCapacity||remainAmmoBullets<=0) return;
        anim.action.PlayQueued(anim.updateAnimation);
        currentAmmoBullets = remainAmmoBullets < ammoCapacity ? remainAmmoBullets : ammoCapacity;
        remainAmmoBullets -= currentAmmoBullets;
    }
}

