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
    public GameObject[] supplyBoxContent;
    public Transform[] supplyBoxContentPos;
   
    public void Open() 
    {
        //deactivate canvas
        canvas.SetActive(false);
        //enable box collision
        cap.gameObject.GetComponent<BoxCollider>().enabled = true;
        //enable rigibody
        cap.isKinematic = false;
        //loop all supply content
        for(int i = 0; i < supplyBoxContent.Length; i++) 
        {
            //if it does exist
            if (supplyBoxContent[i] != null) 
            {
                //eanbleit
                supplyBoxContent[i].SetActive(true);
            }
        }
    }

    /// <summary>
    /// function to close 
    /// </summary>
    public void Close() 
    {
        //loop all supply content
        for (int i = 0; i < supplyBoxContent.Length; i++)
        {
            //if it does exist along with postion for it
            if(supplyBoxContent[i]!=null && supplyBoxContentPos[i] != null) 
            {
                //set back to correct transform
                supplyBoxContent[i].transform.position = supplyBoxContentPos[i].position;
                //deactivate it
                supplyBoxContent[i].gameObject.SetActive(false);
                //call function to make it back to default
            }
        }
        //disable collision
        cap.gameObject.GetComponent<BoxCollider>().enabled = false;
        //disable rigibody
        cap.isKinematic = true;
        //set cap back to correct position
        cap.transform.position = capPos.position;
        //enable canvas
        canvas.SetActive(true);
        //set cap pos back to beginning;
    }
}
