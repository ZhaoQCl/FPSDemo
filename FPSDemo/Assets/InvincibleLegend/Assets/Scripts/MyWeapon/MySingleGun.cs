using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ����ǹ
/// <summary>
[RequireComponent(typeof(MyGun))]
public class MySingleGun : MonoBehaviour
{
    private MyGun gun;
    private void Start()
    {
        gun = GetComponent<MyGun>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //��ǹ�ڷ������ӵ�
            gun.Firing(gun.firePoint.forward);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            //�����ӵ�
            gun.UpdateAmmo();
        }
    }
}

