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
    [Header("SupplyDrop_Infor")]
    public GameObject[] supplyDropG_Supply;
    [HideInInspector]public int supplyDropID;

    
    [Header("Zombie")]
    public EnemyBase[] zombie;


    [Header("ParticleSystem")]
    public ParticleSystem[] blood;
    [HideInInspector]public int bloodID;

    public ParticleSystem[] goreExplosion;
    [HideInInspector]public int goreExplosionID;

    public ParticleSystem[] groundSlamParticle;
    [HideInInspector]public int groundSlamParticleID;

    public GameObject oil;


    [Header("Bullet")]
    public Rigidbody[] bullets;
    private int _bulletID;
    public int BulletID
    {   get{return _bulletID;} 
        set
        {
            if(value >= bullets.Length)
            {
                _bulletID = 0;
            } 
            else
            {
                _bulletID = value;
            }
        }
    }
   
  
}
