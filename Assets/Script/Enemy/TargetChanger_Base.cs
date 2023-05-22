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
    public int fireRate;
    private float _nextFireRate;
    public Vector3 mainTarget;//transform store main target


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
        if(other.CompareTag("Player") || other.CompareTag("Objective") || other.CompareTag("Damageable"))
        {
           
            //set new target to damage
            ItargetDamageAble = other.GetComponent<IDamageable>();
            OnAttack(ItargetDamageAble);
            OnAttack(other.transform);
        }
        else if(other.CompareTag("CheckPoint"))
        {
            //resume from here 16 MAY 01:51
            if(other.transform.position != mainTarget) return;
            CheckpointBehaviour _newPos = other.GetComponent<CheckpointBehaviour>();
            Vector3 _nextPos = _newPos.objective.GetPos();
            SetTarget(_nextPos);
            
        }
        else if(other.CompareTag("BrokenObjective"))
        {
            //set target to damage to be empty
            ItargetDamageAble = null;
            MoveToMainTarget();
        }
        else if(other.CompareTag("BrokenDamageable"))
        {
            //change target
            SetTarget(mainTarget);
            //set target to damage to be empty
            ItargetDamageAble = null;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        //if it enter to tag player or objective
        if(other.CompareTag("Player") || other.CompareTag("Objective") || other.CompareTag("Damageable"))
        {
            if(ItargetDamageAble != null)
            {
                if(Time.time > _nextFireRate)
                {
                    _nextFireRate = Time.time + fireRate;
                    OnAttack(ItargetDamageAble);
                }
                
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        //Debug.Log(other.name + "" + other.gameObject.tag);  
        Debug.Log(other.gameObject.tag);
        if(other.CompareTag("Player"))
        {
            
            //change target
            SetTarget(mainTarget);
            //set target to damage to be empty
            ItargetDamageAble = null;
        }
        else if(other.CompareTag("BrokenObjective"))
        {
            //set target to damage to be empty
            ItargetDamageAble = null;
            MoveToMainTarget();
        }
    }

    //function to set target
    public void SetTarget(Vector3 _target)
    {
        
        //change main target to new target
        Vector3 correctPos = new Vector3(_target.x,this.transform.position.y,_target.z);
        //execute common zombie chase behaviour
        OnChase(correctPos);
        
    }

    private void MoveToMainTarget()
    {
        Transform target = null;
        /*
        GameManagerClass _GM = GameManagerClass.instanceT;
        //next target to store new target
        Vector3 _nextTarget = Vector3.zero;
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
        
        int _objectiveID = _GM.ObjectiveID;
        int _aiPosID =  _GM.objective[_objectiveID].AIPosID;

        Vector3 targetPos = _GM.objective[_objectiveID].AIPos[_aiPosID];

        _GM.objective[_objectiveID].AIPosID++;
        _GM.ObjectiveID++;
        Debug.Log(_GM.ObjectiveID);
        //set target to be objective
        _nextTarget = new Vector3(targetPos.x,targetPos.y,targetPos.z);

        //target still empty
        if(_nextTarget == null)
        {
            //set target to be player
            _nextTarget = _GM.playerBehaviour_G.transform.position;
        }

        SetTarget(_nextTarget);
        */
        for(int i =0;i<GameManagerClass.instanceT.objective.Length - 1;i++)
        {
            if(GameManagerClass.instanceT.objective[i].gameObject.tag != "BrokenObjective")
            {
                target = GameManagerClass.instanceT.objective[i].transform;
                
                Vector3 _pos = target.GetComponent<AIPosGeneration>().GetPos();
                mainTarget = _pos;
                SetTarget(_pos);
                break;
            }
        }

        if(target == null)
        {
            target = GameManagerClass.instanceT.playerBehaviour_G.transform;
            mainTarget = target.position;
            StartCoroutine(ChasePlayer());
            //enable player chasing script
        }
    }

    public void MoveToCheckpoint()
    {
        Vector3 targetPos = GameManagerClass.instanceT.checkPoints[GameManagerClass.instanceT.CheckPointsID].position;
        GameManagerClass.instanceT.CheckPointsID++;
        mainTarget = targetPos;
        SetTarget(targetPos);
    }

    public IEnumerator ChasePlayer()
    {
        while(GameManagerClass.instanceT.playerBehaviour_G.health > 0)
        {
            SetTarget(mainTarget);
            yield return null;
        }
    }

    public virtual void OnAttack(IDamageable targetIdmg = null){}
    public virtual void OnAttack(Transform targetTrans = null){}
    public virtual void OnChase(Vector3 target){}
}
