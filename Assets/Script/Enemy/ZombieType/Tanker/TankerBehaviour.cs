using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieStates;
/***************************************
 * Authour: HAN 18080038
 * Object hold: tank
 * Content: tank behaviour
 **************************************/
public class TankerBehaviour : EnemyBase
{
    public void OnChase(Transform _target)
    {
        //create new state
        Chase _tChase = new Chase();
        //resume navmesh chasing
        navAgent.Resume();
        //set target for zombie
        _tChase.target = _target;
        //look at target
        this.gameObject.transform.LookAt(_target);
        //change state to be current state
        _State = _tChase;
        //play animation
        meshAnims.Play("Zombie_Run");
        //execute state
        _State.DoState(this);
    }

    public void OnAttackRadius()
    {
        #region Radius damage
       //create a new overlap collider
        Collider[] damageableCollide = Physics.OverlapSphere(this.transform.position,20f);
        //loop every object in the array of collider
        for(int i =0;i< damageableCollide.Length;i++)
        {
            //if the gameobject has tag damageable
            if(damageableCollide[i].gameObject.tag == "Zombie" || damageableCollide[i].gameObject.tag == "Damageable" || damageableCollide[i].gameObject.tag == "Objective")
            {
                //call damage function
                damageableCollide[i].GetComponent<IDamageable>().Damage(zombieStats.zombieDamageAmount,false);
            }
        }
        #endregion
    }
}

