using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class UpgradeHammerEW : MonoBehaviour
{
   private void OnCollisionEnter(Collision EW) 
   {
        if(EW.gameObject.tag == "EmplacementWeapon")
        {
            EW.transform.GetComponent<IEmplacementWeapons>().OnUpgrade();
        }
   }

   
}
