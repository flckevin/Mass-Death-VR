using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN18080038
 * Object hold: Every common zombie in game
 * Content: common zombie behaviour
 **************************************/
public class CommonZombie : EnemyBehaviour
{
    public override void Behaviour()
    {
        //if player does exist and player still alive and zombie still alive
        if (GameManagerClass.gameManaInstance.player_G != null && GameManagerClass.gameManaInstance.playerIsDead == false && zombieHealth > 1)
        {
            //if speed of nav agent been changed
            if (navAgent.speed != defaultZombieSpeed)
            {
                //set speed back to default
                navAgent.speed = defaultZombieSpeed;
            }
            //chase player
            navAgent.SetDestination(GameManagerClass.gameManaInstance.player_G.transform.position);
            //play run animation
            meshAnimsBase.Play("Z_Run_InPlace");
        }
        //if player does exist and player still alive and zombie near the player and zombie still alive
        else if (GameManagerClass.gameManaInstance.player_G != null && GameManagerClass.gameManaInstance.playerIsDead == false && navAgent.remainingDistance == 1 && zombieHealth > 1)
        {
            //play attack animation
            meshAnimsBase.Play("Z_Attack");
            navAgent.speed = 0;
            //hurt player
        }
        else //player is dead or there is no player
        {
            //if zombie still alive
            if (zombieHealth > 1)
            {
                //play idle animation
                meshAnimsBase.Play("Z_Idle");
            }

        }
    }
}
