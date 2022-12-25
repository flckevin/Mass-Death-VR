using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/***************************************
 * Authour: HAN 18080038
 * Object hold: supply box
 * Content: supply box behaviour
 **************************************/
public class SupplyBoxBehaviour : MonoBehaviour
{
    public Rigidbody cap; 
    public Transform capPos;
    public GameObject canvas;
    public GameObject supplyBoxContent;
   
    public void Open() 
    {
        //deactivate canvas
        canvas.SetActive(false);
        //enable box collision
        cap.gameObject.GetComponent<BoxCollider>().enabled = true;
        //enable rigibody
        cap.isKinematic = false;
        //enable all supply box content
        supplyBoxContent.SetActive(true);
    }

}
