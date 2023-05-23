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
    private int _groundSlamParticleID;
    public int GroundSlamParticleID
    {
        get{return _groundSlamParticleID;}
        set{if(_groundSlamParticleID >= groundSlamParticle.Length){_groundSlamParticleID = 0;}else{_groundSlamParticleID = value;}}
    }

    public ParticleSystem[] vomit;
    private int vomitID;
    public int VomitID
    {
        get{return vomitID;}
        set
        {
            if(vomitID >= vomit.Length)
            {
                vomitID = 0;
            }
            else
            {
                vomitID = value;
            }
        }
    }
    
    public ParticleSystem[] explosion;
    private int _eplosionID;
    public int ExplosionID
    {
        get{return _eplosionID;}

        set
        {
            if(_eplosionID >= explosion.Length - 1)
            {
                _eplosionID = 0;
            }
            else
            {
                _eplosionID = value;
            }
        }
    }

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
    [Space(10)]
    [Header("BATTERY")]
    public GameObject[] battery;
    private int _batteryID;
    public int BatteryID
    {
        get{return _batteryID;}
        set
        {
            if(_batteryID >= battery.Length)
            {
                _batteryID = 0;
            }
        }
    }
  
}
