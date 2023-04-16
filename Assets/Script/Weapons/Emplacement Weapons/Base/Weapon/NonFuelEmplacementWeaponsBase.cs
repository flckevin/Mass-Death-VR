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

    [Header("EW INFO")]
    public float initiationLength;// declare float for initiation length
    public float activationLength; // activation length
    public float delay;//float for delay length
    public virtual void Start() 
    {
        //if delay not been set, set to 5
        if(delay == 0){delay = 5;}
        //start machine behaviour
        StartCoroutine(MachineHandler());
    }

    public virtual void OnInitiate(bool _activation)
    {

    }

    public virtual void OnActivation(bool _activation) 
    { 
    
    }

    IEnumerator MachineHandler()
    {

        while(true)
        {
            //initiate
            OnInitiate(true);
            yield return new WaitForSeconds(initiationLength + 0.3f);
            //activate
            OnActivation(true);
            
            //deactivate
            yield return new WaitForSeconds(activationLength);
            OnActivation(false);
            OnInitiate(false);

            //delay
            yield return new WaitForSeconds(delay);
        }
        
        
        
    }

   
}
