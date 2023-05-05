using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class ButtonRigibodyEnabler : MonoBehaviour
{
    public Rigidbody buttonJoint;

    private void Awake() 
    {
        buttonJoint.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log(other.name);
        if(other.CompareTag("PlayerHand"))
        {
            buttonJoint.isKinematic = false;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        Debug.Log(other.name);
        if(other.CompareTag("PlayerHand"))
        {
            buttonJoint.isKinematic = true;
        }
    }
}
