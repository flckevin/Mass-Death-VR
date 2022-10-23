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
    private EmplacementWeaponBehaviourBase _emplacementWeapon;//declare emplacement weapon behaviour to refill fuel
    private OilCanBehaviour _oil;//declare oil to store current oil
    // Start is called before the first frame update
    void Start()
    {
        //storing emplacement weapon class into this class
        _emplacementWeapon = this.gameObject.GetComponentInParent<EmplacementWeaponBehaviourBase>();
    }

    private void OnTriggerEnter(Collider fuelTank)
    {
        //if fuel can enter to fuel tank
        if (fuelTank.CompareTag("FuelTank")) 
        {
            if(_oil == null) 
            {
                //decrease oil value from fuel can
                _oil = fuelTank.GetComponent<OilCanBehaviour>();
            }
            //increase fuel left in emplacement weapons
            _emplacementWeapon.fuelLeft++;
            //decrease oil value from oil can
            _oil.OilValue--;
            //update oil value
            _emplacementWeapon.SliderValueChange();
        }
    }

    private void OnTriggerStay(Collider fuelTank)
    {
        //if fuel can enter to fuel tank
        if (fuelTank.CompareTag("FuelTank"))
        {
            if (_oil == null)
            {
                //decrease oil value from fuel can
                _oil = fuelTank.GetComponent<OilCanBehaviour>();
            }
            //increase fuel left in emplacement weapons
            _emplacementWeapon.fuelLeft++;
            //decrease oil value from oil can
            _oil.OilValue--;
            //update oil value
            _emplacementWeapon.SliderValueChange();
        }
    }

    private void OnTriggerExit(Collider fuelTank)
    {
        //if fuel can enter to fuel tank
        if (fuelTank.CompareTag("FuelTank"))
        {
            //set current oil can to be empty
            _oil = null;
        }
    }


}
