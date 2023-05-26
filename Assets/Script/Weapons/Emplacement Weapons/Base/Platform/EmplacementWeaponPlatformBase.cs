using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
/***************************************
 * Authour: HAN 18080038
 * Object hold: every gas emplacement weapons
 * Content: emplacement weapon platform behaviour
 **************************************/
 [RequireComponent(typeof(AudioSource))]
public class EmplacementWeaponPlatformBase : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]protected bool grounded;//declare bool to check whether platform is grounded
    public string tagToPlace;
    public GameObject WeaponToActivate;//declare gameobject to activate emplacement weapons
    public GameObject EWComponents;//declare emplacement components to destroy
    public GameObject feedback;//feedback
    public AudioClip groundSlamClip;
    private AudioSource _src;

    private void Awake() 
    {
        _src = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        //if object has floor tag
        if (tagToPlace != string.Empty && other.CompareTag(tagToPlace))
        {
            //set grounded to true
            grounded = true;
        }
       
    }

    private void OnTriggerExit(Collider other) 
    {
        //if object has floor tag
        if (tagToPlace != string.Empty && other.CompareTag(tagToPlace))
        {
            //set grounded to false 
            grounded = false;
        }
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(tagToPlace == string.Empty)
        {
            //set grounded to true 
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision other) 
    {
         if(tagToPlace == string.Empty)
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
            WeaponToActivate.transform.localPosition = new Vector3(WeaponToActivate.transform.localPosition.x
                                                                        ,50,
                                                                        WeaponToActivate.transform.localPosition.z);
            
            //if emplacement weapon is gas type
            if(hasGas == true)
            {
                
                //get emplacement weapon behaviour
                EmplacementWeaponBehaviourBaseWithGas EW = WeaponToActivate.GetComponent<EmplacementWeaponBehaviourBaseWithGas>();
                //call couroutine to activate weapon behaviour
                StartCoroutine(EWGasActivation(EW,3));
                
            }

            //lean to gun position
            LeanTween.moveLocal(WeaponToActivate,new Vector3(WeaponToActivate.transform.localPosition.x,0,WeaponToActivate.transform.localPosition.z),3);
            
            StartCoroutine(EWBaseDeactivation());
        }
        else
        {
            //play a feedback sound as player not be able to place the weapon
        }
    }

    IEnumerator EWBaseDeactivation()
    {
        //destroy emplacement components
        Destroy(EWComponents);
        Destroy(this.gameObject.GetComponent<Rigidbody>());
        Destroy(this.gameObject.GetComponent<BoxCollider>());
        //disable grabble component
        this.gameObject.GetComponent<Grabbable>().enabled = false;

        yield return new WaitForSeconds(3f);
        ParticleSystemPlayer.instanceT.PlayeParticleFromPool(PoolManager.instanceT.groundSlamParticle,PoolManager.instanceT.GroundSlamParticleID,this.transform);
        _src.PlayOneShot(groundSlamClip,1);
        yield return new WaitForSeconds(groundSlamClip.length + 0.3f);
        Destroy(_src);
        //disable emplacement platform behaviour class
        this.enabled = false;
    }

    IEnumerator EWGasActivation(EmplacementWeaponBehaviourBaseWithGas EW = null, float duration = 0)
    {
        yield return new WaitForSeconds(duration);
        if(EW != null)
        {
            EW.enabled = true;
        }
        
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

    //====================================== UNITY EVENT ==================================================
    public void OnFeedback(bool turnOnFeedback)
    {
        feedback.SetActive(turnOnFeedback);
    }
}
