using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class EnemySpawner : MonoBehaviour
{
    private int zombieID;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy",1,1);
    }

    void SpawnEnemy()
    {
        if(zombieID >= PoolManager.instanceT.zombie.Length){zombieID = 0;}
        int rand = Random.Range(0,GameManagerClass.instanceT.spawnPos.Length);
        PoolManager.instanceT.zombie[zombieID].transform.position = GameManagerClass.instanceT.spawnPos[rand].transform.position;
        PoolManager.instanceT.zombie[zombieID].enabled = true;
        PoolManager.instanceT.zombie[zombieID].OnRevive();
        zombieID ++;
    }
}
