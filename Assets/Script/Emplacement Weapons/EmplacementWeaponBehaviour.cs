using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class EmplacementWeaponBehaviour : MonoBehaviour
{
    public float fuelLeft = 100;//declare float for fuel left
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WeaponBehaviour();    
    }

    /// <summary>
    /// 
    /// </summary>
    public virtual void WeaponBehaviour() 
    { 
        
    }

    

}
