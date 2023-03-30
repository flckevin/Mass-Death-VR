using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/***************************************
 * Authour: HAN 18080038
 * Object hold: upgrade gun
 * Content: upgrade gun behaviour
 **************************************/
public class UpgradeGunBehaviour : MonoBehaviour
{
    public BoxCollider fireCol; // fire trigger
    public ParticleSystem fireParticle; // fire effect
    public ParticleSystem sparkEffect;// spark effect
    public  Slider progressSlider;//progress slider
    private IUpgradeGun _target;//upgrade target

    
    public void OnGunTrigger()
    {
        //if fire have not enable
        if(fireCol.enabled == false)
        {
            //enable fire
            fireCol.enabled = true;
            //play fire particle
            fireParticle.Play();
        }
        else
        {
            //disable fire
            fireCol.enabled = false;
            //stop fire effect
            fireParticle.Stop();
        }
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        //if trigger are into these target
        if(other.gameObject.tag == "EW_gas" ||
            other.gameObject.tag == "Objective" ||
            other.gameObject.tag == "BrokenObjective")
        {
            //get upgrade component
            _target = other.gameObject.GetComponent<IUpgradeGun>();
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        //if target does not exist then stop execute
        if(_target == null) return;

        //if trigger are into these target
        if(other.gameObject.tag == "EW_gas" ||
            other.gameObject.tag == "Objective" ||
            other.gameObject.tag == "BrokenObjective")
        {
            //call fix function
            _target.OnFixOnUpgrade();

            //if particle effect not playing
            if(sparkEffect.isPlaying == false)
            {
                //play
                sparkEffect.Play();
            }
        }
        
    }

    private void OnTriggerExit(Collider other) 
    {
        //if trigger are into these target
        if(other.gameObject.tag == "EW_gas" ||
            other.gameObject.tag == "Objective" ||
            other.gameObject.tag == "BrokenObjective")
        {
            //set target to null
            _target = null;
            //if particle effect is playing
            if(sparkEffect.isPlaying == true)
            {
                //stop
                sparkEffect.Stop();
            }
        }
    }
}
