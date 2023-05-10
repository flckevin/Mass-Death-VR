using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************
 * Authour: HAN 18080038
 * Object hold: fuel can
 * Content: hold amount of fuel in fuel can
 **************************************/
public class OilCanBehaviour : MonoBehaviour
{
    public float OilValue = 100;//declare float for oil left inside of the oil can
    public ParticleSystem particle;//declare particle for particle to be play
    public GameObject cap;//declare gameobject for cap of the fuel
    private BoxCollider _gasCol; //gas collision box
    private EmplacementWeaponBehaviourBaseWithGas _EW_gas;//store target
    private void Awake()
    {
        //change tag of object holding this class
        this.gameObject.tag = "FuelTank";
    }
    
    private void Start() {
        //storing boxcollider into this class
        _gasCol = this.gameObject.GetComponent<BoxCollider>();
    }

    public void OntriggerEvent()
    {
        //play gas particle
        particle.Play();
        //deactivate cap as feed back for oil have been opened
        cap.SetActive(false);
    }

    public void OntriggerUp()
    {
        //stop playing particle
        particle.Stop();
        //activate cap as feed back oil been closed
        cap.SetActive(true);
        //set emplacement weapon to null
        _EW_gas = null;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("EW_gas"))
        {
            //get emplacement wepaon
            _EW_gas = other.GetComponent<EmplacementWeaponBehaviourBaseWithGas>();
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        //decrease oil value
        OilValue--;
        //if emplacement weapon does not exist then stop
        if(_EW_gas == null) return;
        //increase fuel for emplacement weapon
        _EW_gas.fuelLeftEW++;
    }


}
