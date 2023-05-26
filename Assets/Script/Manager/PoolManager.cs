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
    [HideInInspector]private int _bloodID;
    public int BloodID
    {
        get{return _bloodID;}
        set
        {
            if(_bloodID >= blood.Length)
            {
                _bloodID = 0;
            }
            else
            {
                _bloodID = value;
            }
        }
    }
    
    public ParticleSystem[] money;
    private int _moneyID;
    public int MoneyID
    {
        get{return _moneyID;}
        set
        {
            if(_moneyID >= money.Length)
            {
                _moneyID = 0;
            }
            else
            {
                _moneyID = value;
            }
        }
    }

    public ParticleSystem[] goreExplosion;
    [HideInInspector]public int goreExplosionID;

    public ParticleSystem[] groundSlamParticle;
    private int _groundSlamParticleID;
    public int GroundSlamParticleID
    {
        get{return _groundSlamParticleID;}
        set{if(_groundSlamParticleID >= groundSlamParticle.Length - 1){_groundSlamParticleID = 0;}else{_groundSlamParticleID = value;}}
    }

    public ParticleSystem[] vomit;
    private int vomitID;
    public int VomitID
    {
        get{return vomitID;}
        set
        {
            if(vomitID >= vomit.Length - 1)
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

    public ParticleSystem[] spawnEffect;
    private int _spawnEffectID;
    public int SpawnEffectID
    {
        get{return _spawnEffectID;}
        set
        {
            if(_spawnEffectID >= spawnEffect.Length - 1)
            {
                _spawnEffectID = 0;
            }
            else
            {
                _spawnEffectID = value;
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
            if(value >= bullets.Length - 1)
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
            if(_batteryID >= battery.Length - 1)
            {
                _batteryID = 0;
            }
            else
            {
                _batteryID = value;
            }
        }
    }
  
}
