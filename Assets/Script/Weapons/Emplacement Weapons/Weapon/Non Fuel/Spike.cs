using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: spike
 * Content: spike behaviour
 **************************************/
public class Spike : NonFuelEmplacementWeaponsBase
{
    public GameObject spike;

    

    public override void OnInitiate(bool _activation)
    {
        if(_activation == true)
        {
            LeanTween.moveLocalY(spike,-0.35f,ewStats.initiationLength);
            
        }
        else
        {
            LeanTween.moveLocalY(spike,-5,ewStats.initiationLength);
        }   
        base.OnInitiate(_activation);
    }

    public override void OnUpgrade()
    {
        spike = newWeapon[_NewWeaponID];
        base.OnUpgrade();
    }
    

    
}
