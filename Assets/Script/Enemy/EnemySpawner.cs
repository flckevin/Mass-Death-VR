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
    private int zombieID = 0;//zombie id
    public int delay;//delay time between to spawn zombie
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy",delay,1);
    }

    void SpawnEnemy()
    {
        //if zombie ID reach to length of array set zombie ID back to 0
        if(zombieID >= PoolManager.instanceT.zombie.Length){zombieID = 0;}
        ////random spawn position
        int rand = Random.Range(0,GameManagerClass.instanceT.spawnPos.Length);
        //set position
        PoolManager.instanceT.zombie[zombieID].transform.position = GameManagerClass.instanceT.spawnPos[rand].transform.position;
        //enable zombie behaviour script
        PoolManager.instanceT.zombie[zombieID].enabled = true;
        //enable zombie gameobject
        PoolManager.instanceT.zombie[zombieID].gameObject.SetActive(true);
        //call revive function from zombie
        PoolManager.instanceT.zombie[zombieID].OnRevive();
        //increase zombie ID
        zombieID ++;
    }
}
