using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemyTrigger : MonoBehaviour
{
    public GameObject targetSpawn;
    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Player")
        if (other.CompareTag("MainCamera"))
        {
            targetSpawn.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
