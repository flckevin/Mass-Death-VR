using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorePattern;
/***************************************
 * Authour: HAN18080038
 * Object hold: Game Manager
 * Content: Managing pool objects
 **************************************/
public class PoolManager : Singleton<PoolManager>
{
    [Header("Blood_Info")]
    public GameObject[] bloodG_Blood;
    public int bloodID_Blood;

    [Header("SupplyDrop_Infor")]
    public GameObject[] supplyDropG_Supply;
    public int supplyDropID_Supply;
    [Header("Weapon Effects")]
    public GameObject oil;
    [Header("Zombie")]
    public EnemyBehaviour[] zombie;
}
