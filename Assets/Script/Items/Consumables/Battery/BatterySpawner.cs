using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class BatterySpawner : MonoBehaviour
{
    public int amountAbleToSpawn;
    public Transform spawnPos;
    public void spawnObj()
    {
        
        if(amountAbleToSpawn > 0)
        {
            PoolManager p = PoolManager.instanceT;
            p.battery[p.BatteryID].transform.position = spawnPos.position;
            p.battery[p.BatteryID].SetActive(true);
            p.BatteryID++;
            amountAbleToSpawn--;
            Debug.Log("SPAWN");
        }
        else
        {
            this.gameObject.GetComponent<BNG.Grabbable>().enabled = false;
        }

    }

    private void OnCollisionEnter(Collision other) 
    {
        if(amountAbleToSpawn <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
