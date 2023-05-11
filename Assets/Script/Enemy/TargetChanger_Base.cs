using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreEvent;
/***************************************
 * Authour: HAN18080038
 * Object hold: targetchanger (child of zombie that able to change target)
 * Content: chaging target for enemy
 **************************************/
public class TargetChanger_Base : MonoBehaviour
{

    public IDamageable ItargetDamageAble;//Idamageable for damageable object ahead 
    //public Transform target;//transform for target to chase
   

    private Transform _mainTarget;//transform store main target


    private void Start() 
    {
        //storing change target function
        
        OnStart();
    }

    public virtual void OnStart(){}


    private void OnTriggerEnter(Collider other) 
    {
        //Debug.Log(other.name + "" + other.gameObject.tag);
        //if it enter to tag player or objective
        if(other.CompareTag("Player") || other.CompareTag("Objective"))
        {
           
            //set new target to damage
            ItargetDamageAble = other.GetComponent<IDamageable>();
            OnAttack(ItargetDamageAble);
            OnAttack(other.transform);
        }
        else if(other.CompareTag("BrokenObjective"))
        {
            //set target to damage to be empty
            ItargetDamageAble = null;
            SetTarget();
        }

    }

    private void OnTriggerStay(Collider other)
    {
        //if it enter to tag player or objective
        if(other.CompareTag("Player") || other.CompareTag("Objective"))
        {
            if(ItargetDamageAble != null)
            {
                OnAttack(ItargetDamageAble);
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        //Debug.Log(other.name + "" + other.gameObject.tag);  
        
        if(other.CompareTag("Player"))
        {
            //change target
            OnChase(_mainTarget);
            //set target to damage to be empty
            ItargetDamageAble = null;
        }
    }

    //function to set target
    public void SetTarget()
    {
        //next target to store new target
        Transform _nextTarget = null;
        /*
        //loop every objective
        for(int i = 0; i< GameManagerClass.instanceT.objective.Length;i++)
        {
            //if there is object has tag objective
            if(GameManagerClass.instanceT.objective[i].tag == "Objective")
            {
                //set target to be objective
                _nextTarget = GameManagerClass.instanceT.objective[i].transform;
                //stop looping
                break;
            }
        }
        */
        for(int i = 0; i< GameManagerClass.instanceT.objective.Length;i++)
        {
            //if there is object has tag objective
            if(GameManagerClass.instanceT.objective[i].tag == "Objective")
            {
                //set target to be objective
                _nextTarget = GameManagerClass.instanceT.objective[i].transform;
                //stop looping
                break;
            }
        }

        //target still empty
        if(_nextTarget == null)
        {
            //set target to be player
            _nextTarget = GameManagerClass.instanceT.playerBehaviour_G.transform;
        }

        
        //change main target to new target
        _mainTarget = _nextTarget;
        //execute common zombie chase behaviour
        OnChase(_mainTarget);
        
    }

    public virtual void OnAttack(IDamageable targetIdmg = null){}
    public virtual void OnAttack(Transform targetTrans = null){}
    public virtual void OnChase(Transform target){}
}
