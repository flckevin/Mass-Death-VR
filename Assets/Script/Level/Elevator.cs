using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: elevator
 * Content: elevator behaviour
 **************************************/
public class Elevator : MonoBehaviour
{
    public Transform liftTo;
    private Transform target;
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
         if(other.CompareTag("Player"))
        {
            target = null;
        }
    }

    public void Lift()
    {
        if(target == null || liftTo == null) return;
        target.transform.position = liftTo.transform.position;
    }
}
