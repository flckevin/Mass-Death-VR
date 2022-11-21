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
    public GameObject[] gunMagsAmmoBoxStorage;//declare gun mag for gun ammo box storage and calling for spaw
    public int gunMagAmmoBoxStorageID;//declare gun mag for gun ammo box storage ID for correct mag to spawn
    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.tag != "Gun")
        {
            this.gameObject.tag = "Gun";
        }
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
            //if raycast hit object has tag that be able to damage
            if(rayHit.transform.gameObject.tag == "Zombie" || rayHit.transform.gameObject.tag == "Damageable") 
            {
                //get component of damage able interface
                IDamageable damageAble = rayHit.transform.GetComponent<IDamageable>();
                //call damageable function
                damageAble.Damage(damageDealt, rayHit,false);
            }
            
        }
    }
}
