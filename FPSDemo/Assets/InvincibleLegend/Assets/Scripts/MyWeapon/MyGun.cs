using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����ǹ�Ĺ��з���
/// <summary>
[RequireComponent(typeof(AudioSource))]

public class MyGun : MonoBehaviour
{
    public float atk;
    public float atkDistance = 200;

    public GameObject bulletPrefab;

    private AudioSource audioSource;
    /// <summary>
    /// �����ӵ�����ƵƬ��
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
    /// ����
    /// </summary>
    /// <param name="dir"></param>
    public void Firing(Vector3 dir)
    {
        
        //�Ƿ���Է����ӵ�
        if(anim != null && !Ready()) return;
        //�����ӵ�����
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(dir)) as GameObject;
        //��ʼ���ӵ�����
        bulletGO.GetComponent<MyBullet>().Init(atk, atkDistance);
        //��������
        audioSource.Play();
        //�����������
        if(anim)anim.action.PlayQueued(anim.fireAnimation);
        //��ʾ���
        flash.DisplayFlash();

    }
    /// <summary>
    /// ׼���ӵ�
    /// </summary>
    /// <returns></returns>
    private bool Ready()
    {
        //�жϵ������Ƿ�����ӵ������Ƿ񲥷Ż�������
        if (currentAmmoBullets <= 0 || anim.action.IsPlaying(anim.updateAnimation)) return false;
        currentAmmoBullets--;
        if (currentAmmoBullets == 0)
            anim.action.PlayQueued(anim.lackAnimation);
        return true;
    }
    //��������
    public int ammoCapacity=30;
    //��ǰ�������ӵ���
    public int currentAmmoBullets=30;
    //ʣ���ӵ���
    public int remainAmmoBullets=270;

    /// <summary>
    /// ��������
    /// </summary>
    public void UpdateAmmo()
    {
        if(currentAmmoBullets == ammoCapacity||remainAmmoBullets<=0) return;
        anim.action.PlayQueued(anim.updateAnimation);
        currentAmmoBullets = remainAmmoBullets < ammoCapacity ? remainAmmoBullets : ammoCapacity;
        remainAmmoBullets -= currentAmmoBullets;
    }
}

