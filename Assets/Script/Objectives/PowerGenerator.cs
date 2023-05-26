using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreEvent;
using UnityEngine.UI;
/***************************************
 * Authour: HAN 18080038
 * Object hold: Power generator
 * Content: Power generator behaviour
 **************************************/
public class PowerGenerator : MonoBehaviour,IDamageable,IUpgradeGun
{
    // Start is called before the first frame update
    public float health; //declare float for
    public float timeToDecreased;//float for time to decrease
    public ParticleSystem smoke; // particle for feed back
    public Text healthText; // text to display
    public Extractor extractor;//extractor to decrease time
    

    private float _defaultHealth;//float to store default health
    private BoxCollider _boxCol;//declare boxCol to enable and disable
    private int _amountOfTimeAbleToRestore = 3; //amount of time able to restore 


    void Start()
    {
        //if extractor have not been assigned
        if(extractor == null)
        {
            for(int i =0;i<GameManagerClass.instanceT.objective.Length;i++)
            {
                if(GameManagerClass.instanceT.objective[i].name == "Extractor")
                {
                    extractor = GameManagerClass.instanceT.objective[i].GetComponent<Extractor>();
                    break;
                }
            }

            
            if(extractor == null)
            {
                 //find object with tag Objective
                GameObject[] extractObj = GameObject.FindGameObjectsWithTag("Objective");  
                //loop all object in array
                for(int i  = 0; i < extractObj.Length ; i++)
                {
                    //if there is a object has name Extractor
                    if(extractObj[i].name == "Extractor")
                    {
                        //get extractor component
                        extractor = extractObj[i].GetComponent<Extractor>();
                        break;
                    }
                }
            }
           
        }
        //storing boxcollider into this class
        _boxCol = this.gameObject.GetComponent<BoxCollider>();
        //update amount of generator
        GameManagerClass.instanceT.generatorLeft++;
        //display generator left
        GameManagerClass.instanceT.generatorLeft_UI.text = "generator left" + GameManagerClass.instanceT.generatorLeft.ToString();
        //set default health
        _defaultHealth = health;
    }

    
    private void OnCollisionEnter(Collision other) 
    {
        //Debug.Log(other.gameObject.tag);
        if(other.gameObject.CompareTag("tool") && health < _defaultHealth)
        {
            //call fix function
            OnFixGen();
        }
        
    }

    //damage function
    void OnDamage(float amount)
    {
        //decrease health using given amount
        health -= amount;
        healthText.text = Mathf.Round(health) + "%";
        //if health smaller or less than 0
        if(health <= 0)
        {
            //increase time to extract
            extractor.timeToExtract -= timeToDecreased;
            //change tag of object to identify object is broken
            this.gameObject.tag = "BrokenObjective";
            
            //since the zombie using trigger, by enabling and disabling
            //the trigger of target system from zombie will be able
            //to detect the current stage of the power generator whether is broken
            //and once the tag been change to broken objective and re enable the collider
            //the zombie will detect the current stage of the power generator and change it target
            _boxCol.enabled = false;
            _boxCol.enabled = true;
            //play smoke particle
            if(smoke != null)
            {
                smoke.Play();
            }
            
            //update amount of generator
            GameManagerClass.instanceT.generatorLeft -= 1;
            //display generator left
            GameManagerClass.instanceT.generatorLeft_UI.text = "generator left" + GameManagerClass.instanceT.generatorLeft.ToString();
            /*
            //call function to change target
            for(int i =0; i<targetChanger.Count ; i++)
            {
                if(targetChanger[i]!=null)
                {
                    targetChanger[i].SetTarget();
                    targetChanger.Remove(targetChanger[i]);
                }
            }
            */
            _amountOfTimeAbleToRestore--;
        }
    }

    //function on fix
    public void OnFixGen()
    {
        if(_amountOfTimeAbleToRestore <= 0) return;
        //increase health
        health += 2*Time.deltaTime;
        healthText.text = health + "%";
        //if health is larger or equak to default health
        if(health >= _defaultHealth)
        {
            //set health to be default health
            health = _defaultHealth;
            //decrease time to extract
            extractor.timeToExtract += timeToDecreased;
            
        }
        //player restoring generator
        else if(health > 0)
        {
            //stop playing smoke
            if(smoke != null)
            {
                smoke.Stop();
            }
            //change tag to objective to identify object is not broken
            this.gameObject.tag = "Objective";
        }
    }

    //damage function - interface
    public void Damage(float amount = 0, bool instantDeactivate = false)
    {
        //call damage function
        OnDamage(amount);
    }

    public void OnFixOnUpgrade()
    {
        OnFixGen();
    }
}
