using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class Blocker : MonoBehaviour, IDamageable
{
    public float health; // health
    
    private void DamageReceiver(float _amount)
    {
        //decerase health
        health -= _amount;
        //if health reach to 0
        if(health <= 0)
        {
            //set objective tag
            this.gameObject.tag = "BrokenDamageable";
            //get collider
            BoxCollider col = this.gameObject.GetComponent<BoxCollider>();
            //disable collision
            col.enabled = false;
            //enable collision
            col.enabled = true;
            //destroy current gameobject
            Destroy(this.transform.root.gameObject);
        }
    }

    public void Damage(float amount = 0, bool instantDeactivate = false)
    {
       DamageReceiver(amount);
    }

}
