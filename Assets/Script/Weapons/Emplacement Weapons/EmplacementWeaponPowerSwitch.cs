using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************
 * Authour: HAN 18080038
 * Object hold: Emplacement weapon
 * Content: behaviour for turning on and off emplacement power
 **************************************/
public class EmplacementWeaponPowerSwitch : MonoBehaviour
{
    public BoxCollider pipeCollision;//declare pipe collision to enable trigger
    public EmplacementWeaponBehaviourBaseWithGas weapon; //declare emplacement wepaon to toggle on and off'
    public GameObject fuelCap;//declare fuel cap to open them 
    private void Awake()
    {
        //checking whether weapon switcher does exist
        if(weapon.weaponSwitcher == null) 
        {
            //assign weapon switcher to weapon
            weapon.weaponSwitcher = this;
        }
        
    }

    /// <summary>
    /// function to switch power
    /// </summary>
    public void SwitchFunc() 
    { 
        //if power switcher is being turn off
        if(weapon.enabled == false) 
        {
            
            //open the cap
            LeanTween.rotateLocal(fuelCap, new Vector3(-10.302f,0,0), 1);
            //turn on weapon
            weapon.OnDisableWeapon();
            //enable pipe coliision
            pipeCollision.enabled = false;
        }
        else //power switcher is already on 
        {
            
            //open the cap
            LeanTween.rotateLocal(fuelCap, new Vector3(145,0,0), 1);
            //turn off weapon
            weapon.OnDisableWeapon();
            //enable pipe coliision
            pipeCollision.enabled = true;
        }
    }

}
