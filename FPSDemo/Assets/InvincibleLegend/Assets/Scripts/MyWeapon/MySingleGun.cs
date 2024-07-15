using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 单发枪
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
            //从枪口方向发射子弹
            gun.Firing(gun.firePoint.forward);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            //更换子弹
            gun.UpdateAmmo();
        }
    }
}

