using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieStates;
/***************************************
 * Authour: HAN18080038
 * Object hold: Every common zombie in game
 * Content: common zombie behaviour
 **************************************/
public class CommonZombie : EnemyBehaviour
{
    //====================== ZOMBIE STATES ========================

    
    public override void Start()
    {
        //change to chase state
        Common_Chase _chase = new Common_Chase();
        _chase.target = GameManagerClass.instanceT.player_G.transform;
        _State = _chase;
        base.Start();
        
    }

    private void Update()
    {
        //calculate distance between player and zombie
        float _distance = Vector3.Distance(this.gameObject.transform.position,GameManagerClass.instanceT.player_G.transform.position);
        //if distance less or equal to 1
        if(_distance <= 1)
        {
            //change to attack state
             _currentState = "Common_Attack";
            if(_State.ToString() == _currentState) return;
            //new instance of attack state
            Common_Attack _attack = new Common_Attack();
            //store state
            _State = _attack;
            
        }
        else // if distance is larger than 1
        {
            //change to chase state
             _currentState = "Common_Chase";
            if(_State.ToString() == _currentState) return;
            //new instance of chase state
            Common_Chase _chase = new Common_Chase();
            //set target to chase
            _chase.target = GameManagerClass.instanceT.player_G.transform;
            //store state
            _State = _chase;
        
        }
    
        //run the current state
        _State.DoState(this);
       
    }

    

    
}
