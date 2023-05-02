using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieStates;
/***************************************
 * Authour: HAN 18080038
 * Object hold: squirter
 * Content: squirter behaviour
 **************************************/
public class SquirterBehaviour : EnemyBase
{
    private TargetChanger_Base _targetChanger; //change target
    public override void VirtualAwake()
    {
        //call set target function
        _targetChanger = this.gameObject.transform.GetChild(0).GetComponent<TargetChanger_Base>();
        //set target
        _targetChanger.SetTarget();
        base.VirtualAwake();
    }

    //on chase event
     public void Chase(Transform _target)
    {
        Chase c_Chase = new Chase(); //create new chase state
        //if(_State.ToString() == _currentState && _target == null) return;
      
        navAgent.Resume();

        //change to chase state
        _currentState = "Common_Chase";

        //look at target
        this.gameObject.transform.LookAt(_target);

        //set target
        c_Chase.target = _target;
        
        //store state
        _State = c_Chase;

        //play run animation
        meshAnims.Play("Zombie_Run");

        //run the current state
        _State.DoState(this);
    }

    //on attack event
    public void OnAttack(Transform _target)
    {
        //disable target changer
        _targetChanger.enabled = false;
        //chase latest target
        Chase(_target);
        //start explosion countdown
        StartCoroutine(Explode(2));

    }

    //on die event
    public override void OnDie()
    {
        base.OnDie();
        StartCoroutine(Explode(2f));
    }

    //on explode event
    IEnumerator Explode(float delay)
    {
        //waif for few sec
        yield return new WaitForSeconds(delay);

        //if nav aganet have not stop
        if(navAgent.velocity!=Vector3.zero)
        {
            //set velocity of nav agent to be 0 to stop it
            navAgent.velocity = Vector3.zero;
            //stop nav agent
            navAgent.Stop();
        }

        //if zombie have not dead yet
        if(this.gameObject.tag != "DeadEnemy")
        {
            //set tag to be dead enemy
            this.gameObject.tag = "DeadEnemy";
            //play explode animation
            meshAnims.Play("Squirter Explode");
            
        }
      
       
        //wait for few second
        yield return new WaitForSeconds(2.8f);

        #region Radius damage
       //create a new overlap collider
        Collider[] damageableCollide = Physics.OverlapSphere(this.transform.position,20f);
        //loop every object in the array of collider
        for(int i =0;i< damageableCollide.Length;i++)
        {
            //if the gameobject has tag damageable
            if(damageableCollide[i].gameObject.tag == "Zombie" || damageableCollide[i].gameObject.tag == "Damageable" || damageableCollide[i].gameObject.tag == "Objective")
            {
                //call damage function
                damageableCollide[i].GetComponent<IDamageable>().Damage(zombieStats.zombieDamageAmount,false);
            }
        }
        #endregion
        
        #region Play particle effect
        //getting pool manager
        PoolManager poolM = PoolManager.instanceT;
        
        //checking if gore explosion effect does exist
        if(poolM.goreExplosion[poolM.goreExplosionID] == null || poolM.goreExplosionID >= poolM.goreExplosion.Length - 1)
        {
            //if it not
            //take first gore explosion from pool
            poolM.goreExplosionID = 0;
        }

        //setting gore explosion effect posiion
        poolM.goreExplosion[poolM.goreExplosionID].transform.position = new Vector3(this.transform.position.x,this.transform.position.y + 0.5f,this.transform.position.z);
        //activate explosion effect
        poolM.goreExplosion[poolM.goreExplosionID].gameObject.SetActive(true);
        //play that particle effect
        poolM.goreExplosion[poolM.goreExplosionID].Play();
        //increase gore id
        poolM.goreExplosionID++;
        #endregion

        //deactivate zombie
        this.gameObject.SetActive(false);
    }
}
