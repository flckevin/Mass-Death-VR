using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreEvent;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class PowerGenerator : MonoBehaviour,IDamageable
{
    // Start is called before the first frame update
    public float health; //declare float for
    public float timeToDecreased;//float for time to decrease
    private float _defaultHealth;//float to store default health
    public Extractor extractor;//extractor to decrease time
    void Start()
    {
        //set default health
        _defaultHealth = health;

        //if extractor have not been assigned
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

    private void OnCollisionEnter(Collision other) 
    {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.CompareTag("tool"))
        {
            OnFixGen();
        }
        else if(other.gameObject.CompareTag("Zombie"))
        {
            OnDamage(1);
        }
    }

    private void OnCollisionStay(Collision other) 
    {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.CompareTag("Zombie"))
        {
            OnDamage(1);
        }
    }

    void OnDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            extractor.timeToExtract -= timeToDecreased;
            this.gameObject.tag = "BrokenObjective";
            EventDispatch.instanceT.CallFunction(EventsType.CommonOnChangeTarget);
        }
    }

    public void OnFixGen()
    {
        health += 2;
        if(health >= _defaultHealth)
        {
            health = _defaultHealth;
            extractor.timeToExtract += timeToDecreased;
            this.gameObject.tag = "Objective";
        }
    }

    public void Damage(float amount, RaycastHit effect, bool deactivateObjectInstant)
    {
        throw new System.NotImplementedException();
    }

    public void Damage(float amount = 0, bool instantDeactivate = false)
    {
        OnDamage(amount);
    }
}
