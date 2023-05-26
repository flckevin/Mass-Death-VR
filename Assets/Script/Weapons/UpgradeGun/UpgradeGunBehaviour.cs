using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/***************************************
 * Authour: HAN 18080038
 * Object hold: upgrade gun
 * Content: upgrade gun behaviour
 **************************************/
public class UpgradeGunBehaviour : MonoBehaviour
{
    public BoxCollider fireCol; // fire trigger
    public ParticleSystem fireParticle_Upgrade; // fire effect
    public ParticleSystem fireParticle_Destroy; // fire effect
    public ParticleSystem sparkEffect;// spark effect
    public  Slider progressSlider;//progress slider
    public Text textMode;
    public Rigidbody rigiRoot;
    public Transform rootGun;

    private ParticleSystem _particleMain;
    private IUpgradeGun _target;//upgrade target
    private int _destroyVal;
    private int _mode = 0;
    
    private void Awake() 
    {
        _mode = 0;
        _particleMain = fireParticle_Upgrade;
    }
    
    public void OnGunTrigger()
    {
        //if fire have not enable
        if(fireCol.enabled == false)
        {
            //enable fire
            fireCol.enabled = true;
            //play fire particle
            _particleMain.Play();
        }
        else
        {
            //disable fire
            fireCol.enabled = false;
            //stop fire effect
            _particleMain.Stop();
        }

        //if particle effect is playing
        if(sparkEffect.isPlaying == true)
        {
            //stop
            sparkEffect.Stop();
        }
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        //if trigger are into these target
        if(other.gameObject.tag == "EW_gas" ||
            other.gameObject.tag == "Objective" ||
            other.gameObject.tag == "BrokenObjective"||
            other.gameObject.tag == "EW_nogas")
        {
            //get upgrade component
            _target = other.gameObject.GetComponent<IUpgradeGun>();
            //Debug.Log(other.name);
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        //fix mode
        if(_mode == 0)
        {
            //if target does not exist then stop execute
            if(_target == null) return;

            //if trigger are into these target
            if(other.gameObject.tag == "EW_gas" ||
                other.gameObject.tag == "Objective" ||
                other.gameObject.tag == "BrokenObjective" ||
                other.gameObject.tag == "EW_nogas")
            {
                //call fix function
                _target.OnFixOnUpgrade();
                //if particle effect not playing
                if(sparkEffect.isPlaying == false)
                {
                    //play
                    sparkEffect.Play();
                }
                
            }
        }
        else // destroy mode
        {
            //if target does not exist then stop execute
            if(_target == null) return;

            //if trigger are into these target
            if(other.gameObject.tag == "EW_gas" ||
                other.gameObject.tag == "EW_nogas")
            {
                //if particle effect not playing
                if(sparkEffect.isPlaying == false)
                {
                    //play
                    sparkEffect.Play();
                }
                _destroyVal ++;
                progressSlider.value = _destroyVal / 100;
                if(_destroyVal >= 100)
                {
                    Destroy(other.transform.root.gameObject);
                    _destroyVal = 0;
                }
                
                //if particle effect not playing
                if(sparkEffect.isPlaying == false)
                {
                    //play
                    sparkEffect.Play();
                }
                
            }

            

        }
        
        
    }

    private void OnTriggerExit(Collider other) 
    {
        //if trigger are into these target
        if(other.gameObject.tag == "EW_gas" ||
            other.gameObject.tag == "Objective" ||
            other.gameObject.tag == "BrokenObjective" ||
            other.gameObject.tag == "EW_nogas")
        {
            //set target to null
            _target = null;
            //if particle effect is playing
            if(sparkEffect.isPlaying == true)
            {
                //stop
                sparkEffect.Stop();
            }

            if(_mode == 0) return;
            _destroyVal = 0;
        }
    }

    public void ChangeMode()
    {
        //disable fire
        fireCol.enabled = false;
        //stop fire effect
        _particleMain.Stop();

        switch(_mode)
        {
            case 0:
            _mode = 1;
            textMode.text = "Mode: Destroy";
            _particleMain = fireParticle_Destroy;
            break;
            case 1:
            _mode = 0;
            textMode.text = "Mode: Upgrade";
            _particleMain = fireParticle_Upgrade;
            break;
        }

        //if particle effect is playing
        if(sparkEffect.isPlaying == true)
        {
            //stop
            sparkEffect.Stop();
        }
        //OnGunTrigger();
    }


    public void Onrelease()
    {
        rigiRoot.isKinematic = true;
        rigiRoot.transform.localPosition = rootGun.localPosition;
        
    }

    public void OnGrab()
    {
        rigiRoot.isKinematic = false;
    }

    
}
