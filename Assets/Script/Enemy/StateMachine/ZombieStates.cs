using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: none
 * Content: hold every zombie type states
 **************************************/
namespace ZombieStates 
{
    #region Common Zombie and Runner
    public class Chase : IZombieStateBase
    {
        public Transform target; //transform for target
        //function to chase target
        public void DoState(EnemyBase commonZombie)
        {
            
            //chase player
            commonZombie.navAgent.SetDestination(target.position);
            
        }
        
    }

    public class Attack : IZombieStateBase
    {
        public IDamageable damageAbleTarget;//target to damage

        public void DoState(EnemyBase commonZombie)
        {
            //giving damage
           damageAbleTarget.Damage(commonZombie.zombieStats.zombieDamageAmount,false);
        }
    }

    public class Idle : IZombieStateBase
    {
        public void DoState(EnemyBase commonZombie)
        {
            //play run animation
            commonZombie.meshAnimsBase.Play("Z_Idle");
        }
    }

    #endregion


    #region Squirter And Tanker
    public class RadiusDamage : IZombieStateBase
    {
        public void DoState(EnemyBase zombie)
        {
            //create a new overlap collider
            Collider[] damageableCollide = Physics.OverlapSphere(zombie.transform.position,4f);
            //loop every object in the array of collider
            for(int i =0;i< damageableCollide.Length;i++)
            {
                //if the gameobject has tag damageable
                if(damageableCollide[i].gameObject.tag == "Zombie" || damageableCollide[i].gameObject.tag == "Damageable")
                {
                    //call damage function
                    damageableCollide[i].GetComponent<IDamageable>().Damage(99999,true);
                }
            }
        }
    }

    #endregion



}
