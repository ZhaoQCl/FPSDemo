using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemySystem : MonoBehaviour
{
    private GameObject[] spawnList;
    private void Start()
    {
        spawnList = new GameObject[transform.childCount];
        for (int i = 0; i < spawnList.Length; i++)
        {
            spawnList[i] = transform.GetChild(i).gameObject;
        }
        ActivateNextSpawn();
    }

    public int currentIndex = 1;
    public void ActivateNextSpawn()
    {
        if (currentIndex != -1)
            spawnList[currentIndex].SetActive(false);

        if (currentIndex < spawnList.Length - 1)
        {
            spawnList[++currentIndex].SetActive(true);
        }
        else
        {
            //游戏结束
            Debug.Log("游戏结束喽");
        }
    }
}
