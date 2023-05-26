using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
[RequireComponent(typeof(AudioSource))]
public class BatteryBehaviour : MonoBehaviour
{
    public float fuelToAdd;
    public AudioClip batteryClip;
    private AudioSource _src;

    private void Awake() 
    {
        _src = this.gameObject.GetComponent<AudioSource>();
    }
    
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("EW_gas"))
        {
            _src.PlayOneShot(batteryClip,1);
            other.gameObject.GetComponent<EmplacementWeaponBehaviourBaseWithGas>().fuelLeftEW += fuelToAdd;
            this.gameObject.SetActive(false);
        }    
    }
}
