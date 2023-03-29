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
        meshAnims.Play("TankWalk");
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

        #region play particle effect

        PoolManager poolM = PoolManager.instanceT;

        if(poolM.groundSlamParticle[poolM.groundSlamParticleID] == null || poolM.groundSlamParticleID >= poolM.groundSlamParticle.Length - 1)
        {
            poolM.groundSlamParticleID = 0;
        }

        poolM.groundSlamParticle[poolM.groundSlamParticleID].gameObject.transform.position = targetChanger.transform.position;
        poolM.groundSlamParticle[poolM.groundSlamParticleID].gameObject.SetActive(true);
        poolM.groundSlamParticle[poolM.groundSlamParticleID].Play();

        poolM.groundSlamParticleID++;

        #endregion
    }
}

