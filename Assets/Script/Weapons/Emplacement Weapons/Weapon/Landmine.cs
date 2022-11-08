using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class Landmine : MonoBehaviour
{
    private bool _activated;//declare bool to check whether land mine been enabled

    private void OnCollisionEnter(Collision obj) 
    {
        if(_activated == false) return;

        if(obj.gameObject.CompareTag("Damageable"))
        {
            Collider[] damageableCollide = Physics.OverlapSphere(this.transform.position,4f);
            for(int i =0;i< damageableCollide.Length;i++)
            {
                damageableCollide[i].GetComponent<IDamageable>().Damage(99999,true);
            }
        }
        else if(obj.gameObject.CompareTag("PlayerHand") || obj.gameObject.CompareTag("Player"))
        {
            //explode
        }
    }

    public void OnActivation()
    {
        //activate landmine explostion
        _activated = true;
    }
}
