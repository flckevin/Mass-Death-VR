using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: Landmine
 * Content: Landmine behaviour
 **************************************/
 [RequireComponent(typeof(Rigidbody))]
public class Landmine : ConsumableItemNEW_NoGasBase
{
    private bool _grounded; // declare bool to check whether the landmine is grounded
    private void OnCollisionEnter(Collision obj) 
    {
        //checking whether landmine touched on the floor
        if(obj.gameObject.CompareTag("PlaceableFloor"))
        {
            //set grounded to true
            _grounded = true;
        }

        //if object has tag damageable
        if(obj.gameObject.CompareTag("Zombie") && _ableToUse == true)
        {
            //create a new overlap collider
            Collider[] damageableCollide = Physics.OverlapSphere(this.transform.position,4f);
            //loop every object in the array of collider
            for(int i =0;i< damageableCollide.Length;i++)
            {
                //if the gameobject has tag damageable
                if(damageableCollide[i].gameObject.tag == "Zombie" || damageableCollide[i].gameObject.tag == "Damageable")
                {
                    //call damage function
                    damageableCollide[i].GetComponent<IDamageable>().Damage(99999,true);
                }
            }
            //play explode function
            Explode();
        }
        //if player touched it and landmine already activated
        else if(obj.gameObject.CompareTag("PlayerHand") || obj.gameObject.CompareTag("Player"))
        {
            //if the mine already activated
            if(_ableToUse == true)
            {
                //explode
                Explode();
            }
        }
        //function for explosion effect
        void Explode() => this.gameObject.SetActive(false);
    }

    private void OnCollisionExit(Collision obj) 
    {
        //checking whether it was a floor
        if(obj.gameObject.CompareTag("PlaceableFloor"))
        {
            //set grounded back to false
            _grounded = false;
        }
    }

    //activate function
    public override void OnsueEWnItem()
    {
        //activate landmine explostion
        _ableToUse = true;
        base.OnsueEWnItem();
    }

    public override void OnSetDefaultEWnItem()
    {
        //deactivate land mine
        _ableToUse = false;
        base.OnSetDefaultEWnItem();
    }
}
