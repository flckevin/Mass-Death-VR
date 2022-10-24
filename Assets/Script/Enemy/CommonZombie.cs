using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN18080038
 * Object hold: Every common zombie in game
 * Content: common zombie behaviour
 **************************************/
public class CommonZombie : EnemyBehaviour
{
    //====================== ZOMBIE STATES ========================
    public ChaseState_Common chaseState = new ChaseState_Common();
    public AttackState_Common attackState = new AttackState_Common();

    /// <summary>
    /// zombie behaviour funcions
    /// </summary>
    public override void Behaviour()
    {
      
        _currentState = chaseState;
        //run the current state
        _currentState.DoState(this);
        base.Behaviour();
    }
}
