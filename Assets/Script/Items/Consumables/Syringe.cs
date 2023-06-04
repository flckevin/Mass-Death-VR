using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: syringe
 * Content: syringe behaviour
 **************************************/
[RequireComponent(typeof(AudioSource))]
public class Syringe : ConsumableItem
{
    [Header("Syringe_Info")]
    public float healthAddAmount;//declare float for amount to add to player health
    public AudioClip stabbed;
    public AudioClip injeceted;
    private AudioSource _src;
    
    private void Start()
    {
        _ableToUse = false;
        _src = this.gameObject.GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider player) 
    {
        //check whether the object collide with the floor
        if (player.gameObject.CompareTag("Floor") || player.gameObject.CompareTag("PlaceableFloor")) 
        { 
            //if the object been used
            if(_used == true) 
            {
                //deactivate object
                this.gameObject.SetActive(false);
            }
        }
        else if (player.gameObject.CompareTag("Player")) 
        {
            _src.PlayOneShot(stabbed,1);
            //set able to use to true
            _ableToUse = true;
        }
    }

    private void OnTriggerExit(Collider player) 
    {
        //checking whether the object exit player collision
        if (player.gameObject.CompareTag("Player"))
        {
            //set able to use to false
            _ableToUse = false;
        }
    }

    /// <summary>
    /// function for player to use item
    /// </summary>
    public override void OnUseItem()
    {
        
        //if player able to use item
        if (_ableToUse == true && _used == false)
        {
            _src.PlayOneShot(injeceted,1);
            //add health to the player
            GameManagerClass.instanceT.playerBehaviour_G.OnReciveHealth(healthAddAmount);
            //set used to true
            _used = true;
            base.OnUseItem();
        }
    }
   
}
