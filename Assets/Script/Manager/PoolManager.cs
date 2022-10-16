using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN18080038
 * Object hold: Game Manager
 * Content: Managing pool objects
 **************************************/
public class PoolManager : MonoBehaviour
{
    public static PoolManager poolInstance { get; private set; } // declare poolmanager to set for singleton
    private void Awake()
    {
        //setting singleton for pool
        poolInstance = this;
    }

    [Header("Blood_Info")]
    public GameObject[] blood_G;
    public int bloodID_Int;
   

    
}
