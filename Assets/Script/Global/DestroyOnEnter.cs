using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
[RequireComponent(typeof(Rigidbody))]
public class DestroyOnEnter : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Destroy(this.gameObject);
        
        }
    }
}
