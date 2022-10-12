using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
/***************************************
 * Authour: HAN 18080038
 * Object hold: Every emplacement platform in game
 * Content: emplacement platform behaviour
 **************************************/
public class EmplacementWeaponPlatformBehavoiur : MonoBehaviour
{
    public bool grounded;//declare bool to check whether platform is grounded
    public GameObject Weapon;//declare gameobject to activate emplacement weapons
    public GameObject weaponCanvas;//declare gameobject to disable weapon canvas
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider obj)
    {
        
    }

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
    

    /// <summary>
    /// emplacement weapon activation
    /// </summary>
    public void EmplacementWepaonActivation() 
    {
        //cehcking whether emplacement weapon is grounded
        if(grounded == true) 
        {
            //activate emplacement wepaon
            Weapon.SetActive(true);
            //play fall from sky animation
            //activate all emplacement weapon behaviour
            Weapon.GetComponent<EmplacementWeaponBehaviour>().enabled = true;
            //disable grabble component
            this.gameObject.GetComponent<Grabbable>().enabled = false;
            //disable rigibody
            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            //disable weapon canvas
            weaponCanvas.SetActive(false);
            //disable emplacement platform behaviour class
            this.enabled = false;
        }
        else 
        { 
            //play a feedback sound as player not be able to place the weapon
        }
    }
}
