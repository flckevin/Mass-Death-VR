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
    #region Common Zombie
    public class Common_Chase : IZombieStateBase
    {
        public Transform target; //transform for target
        //function to chase target
        public void DoState(EnemyBehaviour commonZombie)
        {
            
            //chase player
            commonZombie.navAgent.SetDestination(target.position);
            //play run animation
            commonZombie.meshAnimsBase.Play("Zombie_Run");
            
        }
        
    }

    public class Common_Attack : IZombieStateBase
    {
        public IDamageable damageAbleTarget;//target to damage

        public void DoState(EnemyBehaviour commonZombie)
        {
            //giving damage
           damageAbleTarget.Damage(commonZombie.zombieStats.zombieDamageAmount,false);
        }
    }

    public class Common_Idle : IZombieStateBase
    {
        public void DoState(EnemyBehaviour commonZombie)
        {
            //play run animation
            commonZombie.meshAnimsBase.Play("Z_Idle");
        }
    }

    #endregion


    #region Squirter

    public class Squirter_Chase : IZombieStateBase
    {
        public Transform target;
        public void DoState(EnemyBehaviour squirter)
        {
             
            //chase player
            squirter.navAgent.SetDestination(target.position);
            //play run animation
            squirter.meshAnimsBase.Play("Z_Run_InPlace");
        }
    }

    public class Squirter_Explode : IZombieStateBase
    {
        public void DoState(EnemyBehaviour zombie)
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


    #region Tanker
    public class Tank_Chase : IZombieStateBase
    {
        public Transform target;
        public void DoState(EnemyBehaviour tankZombie)
        {
            //chase player
            tankZombie.navAgent.SetDestination(target.position);
            //play run animation
            tankZombie.meshAnimsBase.Play("Z_Run_InPlace");
        }
    }

    public class Tank_RadiusDamage : IZombieStateBase
    {
        public void DoState(EnemyBehaviour zombie)
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


    #region Runner

    public class Runner_Chase:IZombieStateBase
    {
        public void DoState(EnemyBehaviour commonZombie)
        {
            //chase player
            commonZombie.navAgent.SetDestination(GameManagerClass.instanceT.player_G.transform.position);
            //play run animation
            commonZombie.meshAnimsBase.Play("Z_Run_InPlace");
        }
    }

    public class Runner_Attack : IZombieStateBase
    {
        private float _next_Fire;
        private float _damage = 1;
        public void DoState(EnemyBehaviour zombie)
        {
            if(Time.time > _next_Fire)
            {
                _next_Fire = Time.time + 1;
                GameManagerClass.instanceT.player_G.OnDamage(_damage);
            }
        }
    }

    #endregion

}
