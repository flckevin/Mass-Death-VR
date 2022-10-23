using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class EmplacementWeaponPlatformBase : MonoBehaviour
{
    protected bool grounded;//declare bool to check whether platform is grounded
    public GameObject Weapon;//declare gameobject to activate emplacement weapons
    public GameObject weaponCanvas;//declare gameobject to disable weapon canvas
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

    /// <summary>
    /// emplacement weapon activation
    /// </summary>
    public virtual void EmplacementWepaonActivation()
    {
       
    }
}
