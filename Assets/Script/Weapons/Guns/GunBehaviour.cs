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
    //public int gunMagAmmoBoxStorageID;//declare gun mag for gun ammo box storage ID for correct mag to spawn
    //public float bulletForce;

    public LayerMask rayMask;
    private BNG.RaycastWeapon rayWeapon;
    // Start is called before the first frame update
    public virtual void Start()
    {
        //if this object not tag gun yet
        if(this.gameObject.tag != "Gun")
        {
            //set tag to be gun
            this.gameObject.tag = "Gun";
        }
        rayWeapon = this.gameObject.GetComponent<BNG.RaycastWeapon>();
    }

  
    //function when gun shoot
    public void OnShoot()
    {
        
        RaycastHit rayHit;

        if(Physics.Raycast(rayWeapon.MuzzlePointTransform.position,rayWeapon.MuzzlePointTransform.forward,out rayHit,Mathf.Infinity,rayMask))
        {
            Debug.Log(rayHit.transform.name);
            if(rayHit.transform.tag == "Zombie")
            {
                rayHit.transform.GetComponent<EnemyBase>().DamageReceiver(rayWeapon.Damage,rayHit.point,false);
            }
        }
        
    }

   
}
