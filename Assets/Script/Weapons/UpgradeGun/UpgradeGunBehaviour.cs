using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: upgrade gun
 * Content: upgrade gun behaviour
 **************************************/
public class UpgradeGunBehaviour : MonoBehaviour
{
    public BoxCollider fire; // fire trigger
    public ParticleSystem fireParticle; // fire effect
    private IUpgradeGun target;//upgrade target

    
    public void OnGunTrigger()
    {
        //if fire have not enable
        if(fire.enabled == false)
        {
            //enable fire
            fire.enabled = true;
            //play fire particle
            fireParticle.Play();
        }
        else
        {
            //disable fire
            fire.enabled = false;
            //stop fire effect
            fireParticle.Stop();
        }
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        //if trigger are into these target
        if(other.gameObject.tag == "EmplacementWeapon" ||
            other.gameObject.tag == "Objective" ||
            other.gameObject.tag == "BrokenObjective")
        {
            //get upgrade component
            target = other.gameObject.GetComponent<IUpgradeGun>();
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        //if target does not exist then stop execute
        if(target == null) return;
        //else
        //call fix function
        target.OnFixOnUpgrade();
    }

    private void OnTriggerExit(Collider other) 
    {
        //if trigger are into these target
        if(other.gameObject.tag == "EmplacementWeapon" ||
            other.gameObject.tag == "Objective" ||
            other.gameObject.tag == "BrokenObjective")
        {
            //set target to null
            target = null;
        }
    }
}
