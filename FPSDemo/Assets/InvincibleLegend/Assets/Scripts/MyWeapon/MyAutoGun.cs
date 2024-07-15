using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Á¬·¢Ç¹
/// <summary>
[RequireComponent(typeof(MyGun))]
public class MyAutoGun : MonoBehaviour
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
            gun.Firing(gun.transform.forward);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            gun.UpdateAmmo();
        }
    }
}

