using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
/***************************************
 * Authour: HAN 18080038
 * Object hold: every gas emplacement weapons
 * Content: emplacement weapon platform behaviour
 **************************************/
public class EmplacementWeaponPlatformBase : MonoBehaviour
{
    // Start is called before the first frame update
    protected bool grounded;//declare bool to check whether platform is grounded
    public string tagToPlace;
    public GameObject WeaponToActivate;//declare gameobject to activate emplacement weapons
    public GameObject EWComponents;//declare emplacement components to destroy
    
    private void OnCollisionEnter(Collision collision)
    {
        //if object has floor tag
        if (collision.gameObject.CompareTag(tagToPlace))
        {
            //set grounded to true
            grounded = true;
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        //if object has floor tag
        if (collision.gameObject.CompareTag(tagToPlace))
        {
            //set grounded to false 
            grounded = false;
        }
    }

    /// <summary>
    /// emplacement weapon activation
    /// </summary>
    public virtual void EmplacementWepaonActivation(bool hasGas)
    {
        //cehcking whether emplacement weapon is grounded and be able to place down
        if (grounded == true)
        {
            //activate emplacement wepaon
            WeaponToActivate.SetActive(true);
            //play fall from sky animation
            if(hasGas == true)
            {
                WeaponToActivate.transform.localPosition = new Vector3(WeaponToActivate.transform.localPosition.x
                                                                        ,50,
                                                                        WeaponToActivate.transform.localPosition.z);
                //get emplacement weapon behaviour
                EmplacementWeaponBehaviourBaseWithGas EW = WeaponToActivate.GetComponent<EmplacementWeaponBehaviourBaseWithGas>();
                //call couroutine to activate weapon behaviour
                StartCoroutine(EWGasActivation(EW,3));
                
            }

            //lean to gun position
            LeanTween.moveLocal(WeaponToActivate,new Vector3(WeaponToActivate.transform.localPosition.x,0,WeaponToActivate.transform.localPosition.z),3);
            //destroy emplacement components
            Destroy(EWComponents);

            
            //disable grabble component
            this.gameObject.GetComponent<Grabbable>().enabled = false;
            //disable rigibody
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //disable emplacement platform behaviour class
            this.enabled = false;
        }
        else
        {
            //play a feedback sound as player not be able to place the weapon
        }
    }

    IEnumerator EWGasActivation(EmplacementWeaponBehaviourBaseWithGas EW, float duration)
    {
        yield return new WaitForSeconds(duration);
        EW.enabled = true;
    }
    

    //======================================== FOR TABLET ===============================================
    //function to switch weapon on and off
    public void SwitchFunc(EmplacementWeaponBehaviourBaseWithGas weapon) 
    { 
        //if power switcher is being turn off
        if(weapon.enabled == false) 
        {

            //turn on weapon
            weapon.enabled = true;

        }
        else //power switcher is already on 
        {

            //turn off weapon
            weapon.enabled = false;

        }
    }

    public void DestroyFunc()
    {
        //destroy this gameobject
        Destroy(this.gameObject);
    }

    public void ActivateConfirmScreen(GameObject confirmScreen)
    {
        switch(confirmScreen.activeInHierarchy)
        {
            case true:
            //deactivate confirmation screen
            confirmScreen.SetActive(false);
            break;
            case false:
            //activate confirmation screen
            confirmScreen.SetActive(true);
            break;
        }
        
    }

    //==========================================================================================================


}
