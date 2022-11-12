using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
/***************************************
 * Authour: HAN 18080038
 * Object hold: Every emplacement platform in game
 * Content: emplacement platform behaviour
 **************************************/
public class TurretPlatform : EmplacementWeaponPlatformBase
{

    // Start is called before the first frame update

    public override void EmplacementWepaonActivation()
    {
        //cehcking whether emplacement weapon is grounded
        if (grounded == true)
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
        }
        else
        {
            //play a feedback sound as player not be able to place the weapon
        }
    }



}
