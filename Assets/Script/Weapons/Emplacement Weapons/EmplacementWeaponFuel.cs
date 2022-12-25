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
    public EmplacementWeaponBehaviourBaseWithGas emplacementWeapon;//declare emplacement weapon behaviour to refill fuel
    private OilCanBehaviour _oil;//declare oil to store current oil
    [HideInInspector]public int timePassedMark;//declare int to mark time have passed
    public float fuelLeftEW; // declare float for fuel value storage
    //declare properties to limit value
    public float FuelLeftEW
    {
        get{return fuelLeftEW;}
        set{if(value > 100){fuelLeftEW = 100;}
            if(value <= 0){fuelLeftEW = 0;}}
    }
    // Start is called before the first frame update
    void Start()
    {
        //storing current time 
        timePassedMark = (int)Time.time;
        //if emplacement weapon does not exist
        if(emplacementWeapon == null)
        {
            //storing emplacement weapon class into this class
            emplacementWeapon = gameObject.transform.root.transform.GetChild(0).transform.GetComponent<EmplacementWeaponBehaviourBaseWithGas>();
        }
        //Debug.Log(emplacementWeapon);
        emplacementWeapon.ewFuel = this;
        fuelLeftEW = emplacementWeapon.emplacementStats.defaultFuel;
    }

    private void OnTriggerEnter(Collider fuelTank)
    {
        //if fuel can enter to fuel tank
        if (fuelTank.CompareTag("FuelTank")) 
        {
            UpdateGasOnTime();
            if(_oil == null) 
            {
                //decrease oil value from fuel can
                _oil = fuelTank.GetComponent<OilCanBehaviour>();
            }
            //increase fuel left in emplacement weapons
            fuelLeftEW++;
            //decrease oil value from oil can
            _oil.OilValue--;
            //update oil value
            emplacementWeapon.SliderValueChange();
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
            fuelLeftEW++;
            //decrease oil value from oil can
            _oil.OilValue--;
            //update oil value
            emplacementWeapon.SliderValueChange();
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

    public void UpdateGasOnTime()
    {
        //declare float to calculate time have passed
        float _currentTime = (int)Time.time - timePassedMark;
        //marking new time
        timePassedMark = (int)Time.time;
        //setting new fuel value using new time
        fuelLeftEW -= (emplacementWeapon.emplacementStats.fuelToDecrease)* timePassedMark;
    }
   

}



