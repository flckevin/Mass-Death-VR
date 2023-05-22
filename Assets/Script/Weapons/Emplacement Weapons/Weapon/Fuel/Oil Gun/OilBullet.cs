using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class OilBullet : MonoBehaviour
{
    public OilBehaviour oils; //oil
    
    private void OnCollisionEnter(Collision other) 
    {
        //if bullet touch the floor
        if(other.gameObject.tag == "Floor")
        {
            //scale oil back to default
            oils.transform.localScale = new Vector3(2,2,2);
            //set position of oil
            oils.transform.localPosition = new Vector3(this.transform.localPosition.x,0.082f,this.transform.localPosition.z);
            //activate oil
            oils.gameObject.SetActive(true);
            //deactivate bullet
            this.gameObject.SetActive(false);
        }    
    }
}
