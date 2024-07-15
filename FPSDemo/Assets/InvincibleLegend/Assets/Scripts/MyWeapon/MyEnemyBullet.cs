using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyEnemyBullet : MyBullet
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MainCamera")
        {
            MyPlayerStatusInfo.Instance.Damage(atk);
            Destroy(this.gameObject);
        }
    }
}
