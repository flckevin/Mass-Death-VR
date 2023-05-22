using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: turret
 * Content: turret behaviour
 **************************************/
public class Turret : EmplacementWeaponBehaviourBaseWithGas
{
    private float _nextFire = 0f; // gun fire rate calculation
    private bool isRotating = false; // check whether turret is rotating
    //private bool ableToPatrol = true;
    //private Transform target;
    private AudioSource _audioSrc;

    [Header("Turret Info")]
    public Transform barrel;//declare transform for gun barrel positon
    public GameObject turret;

    public float fireRate; // gun fire rate
    public int damageAmount;//declare int for damage amount
    public float bulletForce; // bullet force
    public int rotateSpeed; // rotation speed
    public float maxRotate; // max axis that turret can rotate
    public LayerMask layer; // layer detection
    public ParticleSystem muzzleFlash;

    [Header("Turret audio info")]
    [Tooltip("0 = rotate /n 1 = shoot")]public AudioClip[] audioClip;
    public override void VStart()
    {
        if(rotateSpeed <= 0){rotateSpeed = 3;}
        _audioSrc = this.gameObject.GetComponent<AudioSource>();
        base.VStart();
    }

    public override void WeaponBehaviourUpdate()
    {
        //checking whether ray cast hit anything
        if (Physics.Raycast(barrel.transform.position, barrel.transform.forward, out RaycastHit ray, Mathf.Infinity))
        {
           
            //Debug.Log(ray.transform.gameObject.name);
            PoolManager poolM = PoolManager.instanceT;
            //checking tag whether is a damage able object
            if (ray.transform.gameObject.tag == "Zombie")
            {
                if(Time.time > _nextFire)
                {
                    //if muzzle flash does exist and not playing
                    if(muzzleFlash != null && !muzzleFlash.isPlaying)
                    {
                        //play muzzle flash
                        muzzleFlash.Play();
                    }
                    //play shoot audio
                    if(_audioSrc.isPlaying == false)
                    {
                        _audioSrc.PlayOneShot(audioClip[1],1);
                    }
                    
                    _nextFire = Time.time + fireRate;
                    //deal damage to zombie
                    ray.transform.GetComponent<EnemyBase>().DamageReceiver(damageAmount,ray.transform,false);
                }
                /*
                target = ray.transform;
                Debug.Log(target.name);
                LeanTween.cancel(turret);
                ableToPatrol = false;
                */
                
            
            }
        }
        base.WeaponBehaviourUpdate();
    }

    public override void WeaponBehaviour()
    {
 
        RotateYTo();
        
        base.WeaponBehaviour();
    }

    

    private void RotateYTo()
    {
        //if turret is rotating then do not execute rest
        if(isRotating == true) return;
        //if turret reach to goal
        if(EuAngleNegConverter(turret.transform.localEulerAngles.y) >= maxRotate)
        {
            //rotate other side
            LeanTween.rotateLocal(turret,new Vector3(turret.transform.rotation.x,-maxRotate,turret.transform.rotation.z),rotateSpeed);
        }
        else //if turret reach to goal
        {   
            //rotate other side
            LeanTween.rotateLocal(turret,new Vector3(turret.transform.rotation.x,maxRotate,turret.transform.rotation.z),rotateSpeed);
        }
        //play rotation audio
        if(_audioSrc.isPlaying == false)
        {
            _audioSrc.PlayOneShot(audioClip[0],1);
        }

        isRotating = true;
        StartCoroutine(Reset("Rotate"));
    }

    IEnumerator Reset(string _stateToReset)
    {
   
        yield return new WaitForSeconds(rotateSpeed + 1.5f);
        isRotating = false;
        //Debug.Log(EuAngleNegConverter(turret.transform.localEulerAngles.y));
        
    }

    public override void OnUpgradeEW()
    {
        barrel = weaponStages[_currentStage].transform.GetChild(0).transform;
        damageAmount += 5;
        base.OnUpgradeEW();
    }

    //function to convert eularangle to be able to have negative value
    private float EuAngleNegConverter(float _target)
    {
        float angle = _target;
        angle = (angle > 180) ? angle - 360 : angle;

        return angle;
    }

}
