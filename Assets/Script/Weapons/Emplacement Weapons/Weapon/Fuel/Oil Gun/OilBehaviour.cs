using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/***************************************
 * Authour: HAN18080038
 * Object hold: Oil 
 * Content: Oil behaviour
 **************************************/
public class OilBehaviour : MonoBehaviour
{
    
    [Range(0,1.5f)]public float slowdownValue;
    public float timeExits; //declare float for time of existance

    
     private void OnEnable() 
     {
          //scale down current object
          LeanTween.scale(this.gameObject,new Vector3(0,0,0),timeExits);
          //start couroutine of dissapearance
          StartCoroutine(Disappear());
     }

   private void OnTriggerEnter(Collider _obj) 
   {
        
        //check whether object has tag zombie
        if(_obj.gameObject.tag == "Zombie")
        {
            //Debug.Log("Zombie");
            //decrease nav mesh agent
            _obj.GetComponent<NavMeshAgent>().speed -= slowdownValue;
            
        }
   }

   private void OnTriggerExit(Collider _obj) 
   {
        //check whether object has tag zombie
        if(_obj.CompareTag("Zombie"))
        {
           _obj.GetComponent<NavMeshAgent>().speed += slowdownValue;
        }
   }

   IEnumerator Disappear()
   {
        //wait until time of existance reach to 0 
        yield return new WaitForSeconds(timeExits);
        //deactivate object
        this.gameObject.SetActive(false);
   }
}
