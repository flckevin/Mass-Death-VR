using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class BatteryBehaviour : MonoBehaviour
{
    public float fuelToAdd;
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("EW_gas"))
        {
            other.gameObject.GetComponent<EmplacementWeaponBehaviourBaseWithGas>().fuelLeftEW += fuelToAdd;
            this.gameObject.SetActive(false);
        }    
    }
}
