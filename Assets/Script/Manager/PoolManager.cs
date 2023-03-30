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
    [Header("SUPPLYDROP")]
    public GameObject[] supplyDropG_Supply;
    [HideInInspector]public int supplyDropID;

    
    [Space(10)]
    [Header("ZOMBIE")]
    public EnemyBase[] zombie;


    [Space(10)]
    [Header("PARTICLESYSTEM")]
    public ParticleSystem[] blood;
    [HideInInspector]public int bloodID;

    public ParticleSystem[] goreExplosion;
    [HideInInspector]public int goreExplosionID;

    public ParticleSystem[] groundSlamParticle;
    [HideInInspector]public int groundSlamParticleID;

    public GameObject oil;


    [Space(10)]
    [Header("BULLET")]
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
