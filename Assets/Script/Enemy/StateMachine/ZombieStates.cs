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
        public void DoState(EnemyBehaviour commonZombie)
        {
            //if player does exist and player still alive and zombie still alive
            if (GameManagerClass.instanceT.player_G != null && GameManagerClass.instanceT.playerIsDead_B == false && commonZombie.zombieHealth > 1)
            {
                //chase player
                commonZombie.navAgent.SetDestination(GameManagerClass.instanceT.player_G.transform.position);
                //play run animation
                commonZombie.meshAnimsBase.Play("Z_Run_InPlace");
            }
            //if player does exist and player still alive and zombie near the player and zombie still alive
            else if (GameManagerClass.instanceT.player_G != null && GameManagerClass.instanceT.playerIsDead_B == false && commonZombie.navAgent.remainingDistance == 1 && commonZombie.zombieHealth > 1)
            {
                //play attack animation
                commonZombie.meshAnimsBase.Play("Z_Attack");
                commonZombie.navAgent.speed = 0;
                //hurt player
            }
            else //player is dead or there is no player
            {
                //if zombie still alive
                if (commonZombie.zombieHealth > 1)
                {
                    //play idle animation
                    commonZombie.meshAnimsBase.Play("Z_Idle");
                }

            }
        }
    }

    public class Common_Attack : IZombieStateBase
    {
        public void DoState(EnemyBehaviour commonZombie)
        {
            throw new System.NotImplementedException();
        }
    }
    #endregion


}
