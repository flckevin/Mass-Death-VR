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
    #region Zombie state - except for runner
    public class Chase : IZombieStateBase
    {
        Transform target; //transform for target
        float chaseSpeed;

        public Chase (Transform _target, EnemyBase _zombie, float _speed = 0)
        {
            target = _target;
            DoState(_zombie);
            chaseSpeed = _speed;
        }
        
        //function to chase target
        public void DoState(EnemyBase zombie)
        {
            
            //chase player
            zombie.navAgent.SetDestination(target.position);
            zombie.navAgent.speed = chaseSpeed;
            
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
