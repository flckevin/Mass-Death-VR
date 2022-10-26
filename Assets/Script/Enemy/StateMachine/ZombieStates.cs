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
                //if speed of nav agent been changed
                if (commonZombie._navAgent.speed != commonZombie.defaultZombieSpeed)
                {
                    //set speed back to default
                    commonZombie._navAgent.speed = commonZombie.defaultZombieSpeed;
                }
                //chase player
                commonZombie._navAgent.SetDestination(GameManagerClass.instanceT.player_G.transform.position);
                //play run animation
                commonZombie._meshAnimsBase.Play("Z_Run_InPlace");
            }
            //if player does exist and player still alive and zombie near the player and zombie still alive
            else if (GameManagerClass.instanceT.player_G != null && GameManagerClass.instanceT.playerIsDead_B == false && commonZombie._navAgent.remainingDistance == 1 && commonZombie.zombieHealth > 1)
            {
                //play attack animation
                commonZombie._meshAnimsBase.Play("Z_Attack");
                commonZombie._navAgent.speed = 0;
                //hurt player
            }
            else //player is dead or there is no player
            {
                //if zombie still alive
                if (commonZombie.zombieHealth > 1)
                {
                    //play idle animation
                    commonZombie._meshAnimsBase.Play("Z_Idle");
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
