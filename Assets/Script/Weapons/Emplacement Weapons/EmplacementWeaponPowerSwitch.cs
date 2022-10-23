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
    public EmplacementWeaponBehaviourBase weapon; //declare emplacement wepaon to toggle on and off'
    public GameObject fuelCap;//declare fuel cap to open them 
    private void Awake()
    {
        //checking whether weapon switcher does exist
        if(weapon.weponSwitcher == null) 
        {
            //assign weapon switcher to weapon
            weapon.weponSwitcher = this;
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
            //enable pipe coliision
            pipeCollision.enabled = true;
            //open the cap
            LeanTween.rotateX(fuelCap, -10.302f, 1);
            //turn on weapon
            weapon.enabled = true;
        }
        else //power switcher is already on 
        {
            //enable pipe coliision
            pipeCollision.enabled = false;
            //open the cap
            LeanTween.rotateX(fuelCap, 145, 1);
            //turn off weapon
            weapon.enabled = false;
        }
    }

}
