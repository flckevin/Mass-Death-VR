using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class Barewires : MonoBehaviour
{
    public float slowDownValue; //slow down value
    public float damage; // damage value

    private void OnTriggerEnter(Collider other) 
    {
        //if tag is zombie
        if(other.CompareTag("Zombie"))
        {
            //deal daamge to zombie
            other.GetComponent<EnemyBase>().DamageReceiver(damage,other.transform,false);
            //decrease zombie speed
            other.GetComponent<NavMeshAgent>().speed -= slowDownValue;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        //if target is zombie
        if(other.CompareTag("Zombie"))
        {
            //deal daamge to zombie
            other.GetComponent<EnemyBase>().DamageReceiver(damage,other.transform,false);
            //set speed to default
            other.GetComponent<NavMeshAgent>().speed += slowDownValue;
        }
    }
}
