using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: none
 * Content: chase state for common zombie finite state machine
 **************************************/
public class ChaseState_Common : IZombieStateBase
{
    public void DoState(EnemyBehaviour commonZombie)
    {
        //if player does exist and player still alive and zombie still alive
        if (GameManagerClass.gameManaInstance.player_G != null && GameManagerClass.gameManaInstance.playerIsDead_B == false && commonZombie.zombieHealth > 1)
        {
            //if speed of nav agent been changed
            if (commonZombie._navAgent.speed != commonZombie.defaultZombieSpeed)
            {
                //set speed back to default
                commonZombie._navAgent.speed = commonZombie.defaultZombieSpeed;
            }
            //chase player
            commonZombie._navAgent.SetDestination(GameManagerClass.gameManaInstance.player_G.transform.position);
            //play run animation
            commonZombie._meshAnimsBase.Play("Z_Run_InPlace");
        }
        //if player does exist and player still alive and zombie near the player and zombie still alive
        else if (GameManagerClass.gameManaInstance.player_G != null && GameManagerClass.gameManaInstance.playerIsDead_B == false && commonZombie._navAgent.remainingDistance == 1 && commonZombie.zombieHealth > 1)
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
