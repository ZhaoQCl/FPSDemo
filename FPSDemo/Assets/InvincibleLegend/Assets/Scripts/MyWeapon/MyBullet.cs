using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// <summary>
public class MyBullet : MonoBehaviour
{
    public float atk;
    public float atkDistance;
    public float atkSpeed;

    public RaycastHit hit;
    public LayerMask layer;

    public void Init(float atk,float distance)
    {
        this.atk = atk;
        this.atkDistance = distance;

        CalculateIfShoot();
    }

    public Vector3 targetV3;
    private void CalculateIfShoot()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hit, atkDistance, layer))
        {
            targetV3 = hit.point;
        }
        else
        {
            targetV3 = transform.TransformPoint(0, 0, atkDistance);
        }
    }

    private void Movement()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position,targetV3,atkSpeed*Time.deltaTime);
    }

    private void Update()
    {
        Movement();
        if ((this.transform.position - targetV3).sqrMagnitude < 0.1f)
        {
            Destroy(gameObject);

            GenerateContactEffect();
        }
    }

    private void GenerateContactEffect()
    {
        if (hit.collider == null) return;
        string prefabName = "ContactEffects/Effects" + hit.collider.tag;
        GameObject go = Resources.Load<GameObject>(prefabName);
        if (go)
        {
            Instantiate(go, targetV3 + hit.normal * 0.01f, Quaternion.LookRotation(hit.normal));
        }
    }
}

