using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ParticleLiquid))]
/***************************************
 * Authour: HAN 18080038
 * Object hold: fuel can
 * Content: hold amount of fuel in fuel can
 **************************************/
public class OilCanBehaviour : MonoBehaviour
{
    public float OilValue = 100;//declare float for oil left inside of the oil can
    public GameObject cap;//declare gameobject for cap of the fuel
    private ParticleLiquid _partLiq;//declare particle liquid to play particle when player pour the gas
    private void Awake()
    {
        //change tag of object holding this class
        this.gameObject.tag = "FuelTank";
    }

    /// <summary>
    /// function for grab event
    /// </summary>
    /// <param name="Grabbed"> bool param for activation </param>
    public void Switch(bool Grabbed) 
    {
        //activate/deactivate object
        cap.SetActive(Grabbed);
        //activate and deactivate particle liquid
        _partLiq.enabled = Grabbed;
        
    }

    

    
}
