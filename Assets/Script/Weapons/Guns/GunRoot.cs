using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN18080038
 * Object hold: Every Gun in game
 * Content: Root of every gun in game
 **************************************/
public class GunRoot : MonoBehaviour
{
    [Header ("Gun Info")]
    public Transform gunBarrel; //declare transform for positon of gun barrel
    public float damageDealt;//declare float for damage of the gun
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// root function for gun
    /// </summary>
    public virtual void GunBehaviour() 
    {
        //creating raycast hit to get information
        RaycastHit rayHit;

        //Debug.DrawRay(gunBarrel.position, gunBarrel.forward, Color.green);

        //checking whether raycast has hit something and making sure that gun barrel does exist
        if(Physics.Raycast(gunBarrel.position,gunBarrel.forward, out rayHit, Mathf.Infinity) && gunBarrel != null) 
        { 
            //if raycast hit object has enemy tag
            if(rayHit.transform.gameObject.tag == "Enemy") 
            {
                //get enemy component and call function to cause damage to enemy
                rayHit.transform.GetComponent<EnemyBehaviour>().DamageReceiver(damageDealt, rayHit);
            }
            
        }
    }
}
