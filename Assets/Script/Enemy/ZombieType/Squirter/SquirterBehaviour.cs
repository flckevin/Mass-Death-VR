using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: Squirter
 * Content: Squirter behaviour
 **************************************/
public class SquirterBehaviour : EnemyBase
{
    [Header("SQUIRTER INFO")]
    private Transform _target; //target to go to
    private bool _explode; //identify whether been exploded
    public ParticleSystem explosionParticle;//particle for explosion
    // Start is called before the first frame update
    void Start()
    {
        //loop every objective
        for(int i = 0; i< GameManagerClass.instanceT.objective.Length;i++)
        {
            //if there is object has tag objective
            if(GameManagerClass.instanceT.objective[i].tag == "Objective")
            {
                //set target to be objective
                _target = GameManagerClass.instanceT.objective[i].transform;
                //stop looping
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //go to target
        navAgent.SetDestination(_target.position);
    }

    private void OnTriggerEnter(Collider other) 
    {
        //if object has tag player
        if(other.CompareTag("Player"))
        {
            //if it not exploded
            if(_explode == false)
            {
                //change target to player
                _target = GameManagerClass.instanceT.player_G.transform;
                //set not explode to true to explode
                _explode = true;
            }
            else
            {
                //create a new sphere collider
                Collider[] objectInExplosionRadius = Physics.OverlapSphere(this.transform.position,4);
                //check every object in sphere
                for(int i = 0;i<objectInExplosionRadius.Length;i++)
                {
                    //deal damage to it
                    objectInExplosionRadius[i].GetComponent<IDamageable>().Damage(zombieStats.zombieDamageAmount);
                }
            }
        }
    }
}
