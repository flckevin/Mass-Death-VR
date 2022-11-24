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
        public Transform target;
        public void DoState(EnemyBehaviour commonZombie)
        {
            //chase player
            commonZombie.navAgent.SetDestination(target.position);
            //play run animation
            commonZombie.meshAnimsBase.Play("Z_Run_InPlace");
        }
    }

    public class Common_Attack : IZombieStateBase
    {
        public void DoState(EnemyBehaviour commonZombie)
        {
           Debug.Log("Attacking");
        }
    }

    public class Common_Idle : IZombieStateBase
    {
        public void DoState(EnemyBehaviour commonZombie)
        {
            throw new System.NotImplementedException();
        }
    }
    #endregion


}
