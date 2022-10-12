using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: fuel can
 * Content: fuel can behaviour
 **************************************/
public class EmplacementWeaponFuel : MonoBehaviour
{
    private EmplacementWeaponBehaviour emplacementWeapon;//declare emplacement weapon behaviour to refill fuel
    // Start is called before the first frame update
    void Start()
    {
        //storing emplacement weapon class into this class
        emplacementWeapon = this.gameObject.GetComponentInParent<EmplacementWeaponBehaviour>();
    }

    private void OnTriggerEnter(Collider fuelTank)
    {
        //if fuel can enter to fuel tank
        if (fuelTank.CompareTag("FuelTank")) 
        {
            //decrease oil value from fuel can
            fuelTank.GetComponent<Oil>().OilValue--;
            //increase fuel left in emplacement weapons
            emplacementWeapon.fuelLeft++;
        }
    }

    private void OnTriggerStay(Collider fuelTank)
    {
        //if fuel can enter to fuel tank
        if (fuelTank.CompareTag("FuelTank"))
        {
            //decrease oil value from fuel can
            fuelTank.GetComponent<Oil>().OilValue--;
            //increase fuel left in emplacement weapons
            emplacementWeapon.fuelLeft++;
        }
    }


}
