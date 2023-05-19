using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieStates;
/***************************************
 * Authour: HAN 18080038
 * Object hold: Runner
 * Content: Runner behaviour
 **************************************/
public class RunnerBehaviour : EnemyBase
{
   Attack c_Attack = new Attack(); //create new attack state

    public override void VirtualAwake()
    {


        
    }

    /*
    private void Update()
    {
        //calculate distance between player and zombie
        //float _distance = Vector3.Distance(this.gameObject.transform.position,GameManagerClass.instanceT.player_G.transform.position);
        
        //if there is target
        if(targetChanger.ItargetDamageAble != null)
        {
            
            if(_State.ToString() == _currentState) return;
            
            //change to attack state
            _currentState = "Common_Attack";

            //if nav aganet have not stop
            if(navAgent.velocity!=Vector3.zero)
            {
                //set velocity of nav agent to be 0 to stop it
                navAgent.velocity = Vector3.zero;
                //stop nav agent
                navAgent.Stop();
            }

            //store state
            _State = c_Attack;
            
        }
        else // if there is no target
        {
            
            if(_State.ToString() == _currentState) return;
            
            //change to chase state
            _currentState = "Common_Chase";

            //store state
            _State = c_Chase;
        
        }
    
        //run the current state
        _State.DoState(this);
       
    }
    */

    public void Chase(Vector3 _target)
    {
        Chase c_Chase = new Chase(_target,this,zombieStats.zombieSpeed); //create new chase state
        //if(_State.ToString() == _currentState && _target == null) return;

        navAgent.Resume();

        //change to chase state
       // _currentState = "Common_Chase";

        //look at target
        this.gameObject.transform.LookAt(_target);

        //store state
        _State = c_Chase;

        //play run animation
        meshAnims.Play("Zombie_Run");

        //run the current state
        _State.DoState(this);
    }

    public void Attack(IDamageable _damageable)
    {
       
        //change to attack state
       // _currentState = "Common_Attack";

        //if nav aganet have not stop
        if(navAgent.velocity!=Vector3.zero)
        {
            //set velocity of nav agent to be 0 to stop it
            navAgent.velocity = Vector3.zero;
            //stop nav agent
            navAgent.Stop();
        }
        
        //play attack animation
        meshAnims.Play("Zombie_Attack");

        //if target does not exist then stop
        if(_damageable == null) return;

        //giving attack target
        c_Attack.damageAbleTarget = _damageable;

        //store state
        _State = c_Attack;

        //run the current state
        _State.DoState(this);
    }

    public override void OnRevive()
    {
        //get target changer
        TargetChanger_Base targetChanger = this.gameObject.transform.GetChild(0).GetComponent<TargetChanger_Base>();
        //set main target
        targetChanger.mainTarget = GameManagerClass.instanceT.playerBehaviour_G.transform.position;
        //start chasing target
        targetChanger.StartCoroutine(targetChanger.ChasePlayer());
        base.OnRevive();
    }

}
