using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerBullet : MyBullet
{
    private void Start()
    {
        if (hit.collider != null && hit.collider.tag == "Enemy")
        {
            float atk = CalculateAttackForce();
            print(atk);
            hit.collider.GetComponentInParent<MyEnemyStatusInfo>().Damage(atk);    
        }
    }

    private float CalculateAttackForce()
    {
        //建议使用配置文件替换
        switch (hit.collider.name)
        {
            case "Coll_Head":
                return atk * 2;
            case "Coll_Body":
                return atk;
            default:
                return atk * 0.5f;
        }
    }
}
