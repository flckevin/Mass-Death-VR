using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: every non fuel emplacement weapons
 * Content: non fuel emplacement weapons base
 **************************************/
public class NonFuelEmplacementWeaponsBase : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] protected bool _ableToUse;//declare bool to check wheter be able to use
    protected bool _used;//declare bool to check whether player have used item

    public virtual void OnActivation() 
    { 
    
    }

   
}
