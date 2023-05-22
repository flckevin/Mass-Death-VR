using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
 [RequireComponent(typeof(AudioSource))]
public class Food : ConsumableItem
{
    private AudioSource _audioSrc; // audio source
    public AudioClip eatClip; // audio clip to play
    public float amountOfHealthToAdd; // amount of health to add
    public BNG.Grabbable foodGrabbable; // grabbable script
    public MeshRenderer foodRend; // mesh render
    private void Start() 
    {
        //storing audio source into this class
        _audioSrc = this.gameObject.GetComponent<AudioSource>();    
    }

    private void OnTriggerEnter(Collider other) 
    {
        //if touch player mouth
        if(other.CompareTag("MainCamera"))
        {
            // add player health
            GameManagerClass.instanceT.playerBehaviour_G.health += amountOfHealthToAdd;
            //play audio
            _audioSrc.PlayOneShot(eatClip,1);
            //disable food render
            if(foodRend != null){foodRend.enabled = false;}
            //disable grabbable script
            if(foodGrabbable != null){foodGrabbable.enabled = false;}
            //destroy food
            Destroy(this.gameObject,eatClip.length + 0.2f);
        }    
    }


}
