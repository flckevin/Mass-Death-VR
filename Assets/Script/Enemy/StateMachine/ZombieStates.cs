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
        public void DoState(EnemyBase zombie)
        {
            
            //chase player
            zombie.navAgent.SetDestination(target.position);
            
        }
        
    }

    public class Attack : IZombieStateBase
    {
        public IDamageable damageAbleTarget;//target to damage

        public void DoState(EnemyBase zombie)
        {
            //giving damage
           damageAbleTarget.Damage(zombie.zombieStats.zombieDamageAmount,false);
        }
    }

    public class Idle : IZombieStateBase
    {
        public void DoState(EnemyBase zombie)
        {
            //play run animation
            zombie.meshAnims.Play("Z_Idle");
        }
    }

    #endregion

}
