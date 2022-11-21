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
    private void Awake()
    {
        //change tag of object holding this class
        this.gameObject.tag = "FuelTank";
    }

    public void OntriggerEvent()
    {
        particle.Play();

        cap.SetActive(false);
    }

    public void OntriggerUp()
    {
        particle.Stop();

        cap.SetActive(true);
    }


}
