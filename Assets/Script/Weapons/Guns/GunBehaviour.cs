using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN18080038
 * Object hold: Every Gun in game
 * Content: Root of every gun in game
 **************************************/
public class GunBehaviour : MonoBehaviour
{
    [Header ("General Gun Info")]
    //public Transform gunBarrel; //declare transform for positon of gun barrel
    //public float damageDealt;//declare float for damage of the gun
    public GameObject gunMagsAmmoBoxStorage;//declare gun mag for gun ammo box storage and calling for spaw
    //public int gunMagAmmoBoxStorageID;//declare gun mag for gun ammo box storage ID for correct mag to spawn
    //public float bulletForce;

    // Start is called before the first frame update
    public virtual void Start()
    {
        //if this object not tag gun yet
        if(this.gameObject.tag != "Gun")
        {
            //set tag to be gun
            this.gameObject.tag = "Gun";
        }
    }

    /*
    //function when gun shoot
    public void OnShoot()
    {
        //checking if bullet id exceed amount of array
        if(PoolManager.instanceT.BulletID >= PoolManager.instanceT.bullets.Length - 1)
        {
            //if it is
            //set bullet id back to begining
            PoolManager.instanceT.BulletID = 0;
        }

        //storing bullet going to shoot
        Rigidbody bullet = PoolManager.instanceT.bullets[PoolManager.instanceT.BulletID];
        //set bullet name to be damage going to be dealing
        bullet.name = damageDealt.ToString();
        //set bullet position to be at barrel position
        bullet.transform.position = gunBarrel.position;
        //activate bullet
        bullet.gameObject.SetActive(true);
        //add force to bullet
        bullet.AddRelativeForce(this.transform.forward*bulletForce);
        //increase bullet id
        PoolManager.instanceT.BulletID++;
        
    }
    */
   
}
