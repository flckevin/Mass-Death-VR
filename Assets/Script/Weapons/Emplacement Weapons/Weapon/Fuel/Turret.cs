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
    

    [Header("Turret Info")]
    public Transform barrel;//declare transform for gun barrel positon
    public GameObject turret;

    public float fireRate; // gun fire rate
    public int damageAmount;//declare int for damage amount
    public float bulletForce; // bullet force
    public int rotateSpeed; // rotation speed
    public float maxRotate; // max axis that turret can rotate
    public LayerMask layer; // layer detection
    public override void VStart()
    {
        if(rotateSpeed <= 0){rotateSpeed = 3;}
        base.VStart();
    }

    public override void WeaponBehaviourUpdate()
    {
        //checking whether ray cast hit anything
        if (Physics.Raycast(barrel.transform.position, barrel.transform.forward, out RaycastHit ray, Mathf.Infinity))
        {
           
            Debug.Log(ray.transform.gameObject.name);
            PoolManager poolM = PoolManager.instanceT;
            //checking tag whether is a damage able object
            if (ray.transform.gameObject.tag == "Zombie")
            {
                if(Time.time > _nextFire)
                {
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
        /*
        if(target != null)
        {
            //this.transform.LookAt(target.position - turret.transform.position);
            _nextFire = Time.time + fireRate;
            LeanTween.rotateLocal(turret,(target.position - turret.transform.position),1);
            if(Time.time > _nextFire)
            {
                Debug.Log("SHOOTING: " + target.name);
            }
            Debug.Log("SHOOTING: " + target.name);


            if(turret.transform.localEulerAngles.y >= maxRotate || EuAngleNegConverter(turret.transform.localEulerAngles.y) <= - maxRotate)
            {
                LeanTween.rotateLocal(turret,new Vector3(turret.transform.rotation.x,0,turret.transform.rotation.z),rotateSpeed);
                target = null;
                StartCoroutine(Reset("Patrol"));
            }
        }
        */

        //if(target != null && ableToPatrol == true) return;

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
        
        isRotating = true;
        StartCoroutine(Reset("Rotate"));
    }

    IEnumerator Reset(string _stateToReset)
    {
        /*
        switch(_stateToReset)
        {
            case "Rotate":
            
            break;

            case "Patrol":
            yield return new WaitForSeconds(rotateSpeed + 2);
            ableToPatrol = true;
            break;
        }
        */

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
