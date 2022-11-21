using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/***************************************
 * Authour: HAN 18080038
 * Object hold: Blade
 * Content: blade spinning behaviour
 **************************************/
public class Blade : MonoBehaviour
{
    public float damageAmount;
    // Start is called before the first frame update
    void Start()
    {
        //function to random of spinning direction
        Func<Vector3> tempFunc = () =>{ Vector3 c; 
                                        int rand = UnityEngine.Random.Range(0,5);
                                        if(rand <= 5){c = Vector3.down;} else{c = -Vector3.down;}
                                        return c;};

        //rotate balde
        LeanTween.rotateAround(gameObject, tempFunc(), 360, 2.5f).setLoopClamp();
    }


    private void OnTriggerEnter(Collider obj) 
    {
        //if object enter trigger has tag damageable
        if(obj.gameObject.tag == "Damageable")
        {
            //deal damage to the object
            obj.GetComponent<IDamageable>().Damage(damageAmount,false);
        }        
    }

    private void OnTriggerExit(Collider obj) 
    {
        //if object enter trigger has tag damageable
        if(obj.gameObject.tag == "Zombie" || obj.gameObject.tag == "Damageable")
        {
            //deal damage to the object
            obj.GetComponent<IDamageable>().Damage(damageAmount + 2,false);
        }  
    }

   
}
