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

    private void Awake()
    {
        //change tag of object holding this class
        this.gameObject.tag = "FuelTank";
    }

    
}
