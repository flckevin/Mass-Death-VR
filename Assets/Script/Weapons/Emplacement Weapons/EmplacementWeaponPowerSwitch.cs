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
    /// <summary>
    /// function to switch power
    /// </summary>
    public void SwitchFunc(EmplacementWeaponBehaviourBaseWithGas weapon) 
    { 
        //if power switcher is being turn off
        if(weapon.enabled == false) 
        {
            
            //open the cap
            LeanTween.rotateLocal(weapon.fuelCap, new Vector3(-10.302f,0,0), 1);
            //turn on weapon
            weapon.enabled = true;
            weapon.OnEnableWeapon();
            //enable pipe coliision
            weapon.pipeCol.enabled = false;
        }
        else //power switcher is already on 
        {
            
            //close the cap
            LeanTween.rotateLocal(weapon.fuelCap, new Vector3(145,0,0), 1);
            weapon.OnBeforeDisableWeapon();
            //turn off weapon
            weapon.enabled = false;
            //enable pipe coliision
            weapon.pipeCol.enabled = true;
        }
    }

}
