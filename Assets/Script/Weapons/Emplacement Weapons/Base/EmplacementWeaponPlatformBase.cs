using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class EmplacementWeaponPlatformBase : MonoBehaviour
{
      // Start is called before the first frame update
    public GameObject collisionLimit; //declare gameobject for limit area when placeable be place down
    private bool _abletoPlace = true;//decalre bool to check whether it be able to place down
    protected bool grounded;//declare bool to check whether platform is grounded
    public GameObject WeaponToActivate;//declare gameobject to activate emplacement weapons
    public GameObject weaponCanvasToDisable;//declare gameobject to disable weapon canvas
                                      // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        //if object has floor tag
        if (collision.gameObject.CompareTag("PlaceableFloor"))
        {
            //set grounded to true
            grounded = true;
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        //if object has floor tag
        if (collision.gameObject.CompareTag("PlaceableFloor"))
        {
            //set grounded to false 
            grounded = false;
        }
    }


    
    private void OnTriggerEnter(Collider obj) 
    {
        //if game object enter to placeable limit trigger
        if(obj.CompareTag("PlaceableLimit"))
        {
            //set able to place to false
            _abletoPlace = false;
        }
    }

    private void OnTriggerExit(Collider obj) 
    {
        //if game object enter to placeable limit trigger
        if(obj.CompareTag("PlaceableLimit"))
        {
            //set able to place back to true
            _abletoPlace = true;
        }
    }
    

    /// <summary>
    /// emplacement weapon activation
    /// </summary>
    public virtual void EmplacementWepaonActivation()
    {
        //cehcking whether emplacement weapon is grounded and be able to place down
        if ( _abletoPlace == true && grounded == true)
        {
            //activate emplacement wepaon
            WeaponToActivate.SetActive(true);
            //play fall from sky animation
            //activate all emplacement weapon behaviour
            WeaponToActivate.GetComponent<EmplacementWeaponBehaviourBaseWithGas>().enabled = true;
            //disable grabble component
            this.gameObject.GetComponent<Grabbable>().enabled = false;
            //disable rigibody
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //disable weapon canvas
            weaponCanvasToDisable.SetActive(false);
            //disable emplacement platform behaviour class
            this.enabled = false;
            //enable collider to prevent player having too much spaces
            collisionLimit.SetActive(true);
        }
        else
        {
            //play a feedback sound as player not be able to place the weapon
        }
    }
}
