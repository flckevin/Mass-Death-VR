using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: Runner
 * Content: Runner behaviour
 **************************************/
public class RunnerBehaviour : EnemyBase
{
    private float _next_Fire;

    // Update is called once per frame
    void Update()
    {
        //calculate distance between itself and target
        float dis = Vector3.Distance(transform.position,GameManagerClass.instanceT.player_G.transform.position);
        //if distance remain = 0
        if(dis <= 1)
        {
            //chaking rate of fire
            if(Time.time > _next_Fire)
            {
                _next_Fire = Time.time + 1;
                //attack player
                GameManagerClass.instanceT.player_G.OnDamage(zombieStats.zombieDamageAmount);
            }
        }
        else // not reach to target
        {
            //chase player
            navAgent.SetDestination(GameManagerClass.instanceT.player_G.transform.position);
            //play run animation
            meshAnims.Play("Z_Run_InPlace");
        }
    }
}
