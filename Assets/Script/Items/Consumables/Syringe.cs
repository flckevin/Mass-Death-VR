using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: syringe
 * Content: syringe behaviour
 **************************************/
public class Syringe : ItemBase
{
    [Header("Syringe_Info")]
    public float healthAddAmount;//declare float for amount to add to player health
    
    private void OnCollisionEnter(Collision player)
    {
        //checking whether the object collide to the player
        if(player.gameObject.CompareTag("Player"))
        {
            //set able to use to true
            _ableToUse = true;
            Debug.Log("Player");
        }
        //check whether the object collide with the floor
        else if (player.gameObject.CompareTag("Floor") || player.gameObject.CompareTag("PlaceableFloor")) 
        { 
            //if the object been used
            if(_used == true) 
            {
                //deactivate object
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionExit(Collision player)
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
    public override void Onsue()
    {
        
        //if player able to use item
        if (_ableToUse == true)
        {
            //add health to the player
            //this.gameObject.GetComponent<PlayerStats>().health += healthAddAmount;
            //set used to true
            _used = true;
            Debug.Log("Healed");
            base.Onsue();
        }
    }

   
}
