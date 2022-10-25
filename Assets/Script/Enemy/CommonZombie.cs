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
    public Common_Chase chaseState = new Common_Chase();
    public Common_Attack attackState = new Common_Attack();

    /// <summary>
    /// zombie behaviour funcions
    /// </summary>
    private void Update()
    {
        _currentState = chaseState;
        //run the current state
        _currentState.DoState(this);
       
    }
}
