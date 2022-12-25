using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieStates;
using UnityEngine.AI;
/***************************************
 * Authour: HAN18080038
 * Object hold: Every common zombie in game
 * Content: common zombie behaviour
 **************************************/
public class CommonZombie : EnemyBehaviour
{

    Common_Chase c_Chase = new Common_Chase(); //create new chase state
    Common_Attack c_Attack = new Common_Attack(); //create new attack state
    private Transform _target;

    public override void VirtualStart()
    {
        //call set target function
        this.gameObject.transform.GetChild(0).GetComponent<CommonZombieTargetChanger>().SetTarget();
        base.VirtualStart();
        
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

    public void Chase(Transform _target)
    {
        //if(_State.ToString() == _currentState && _target == null) return;
      
        navAgent.Resume();

        //change to chase state
        _currentState = "Common_Chase";

        //look at target
        this.gameObject.transform.LookAt(_target);

        //set target
        c_Chase.target = _target;
        
        //store state
        _State = c_Chase;

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
        
        c_Attack.damageAbleTarget = _damageable;

        //store state
        _State = c_Attack;

        //run the current state
        _State.DoState(this);
    }

}
