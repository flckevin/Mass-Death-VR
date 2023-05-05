using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
/***************************************
 * Authour: HAN 18080038
 * Object hold: Ammo crate
 * Content: Ammo crate behaviour
 **************************************/
public class AmmoCrateBehaviour : MonoBehaviour
{
    public int amountOfTimeSpawn; // amount of time be able to spawn mags
    private int _defaultAmountOfTime; //store amount of time to spawn mags

    private void Start() 
    {
        _defaultAmountOfTime = amountOfTimeSpawn;
    }

    //function when player grab
    public void OnSpawn(Transform _spawnPos)
    {
        //if player run out of amount of spawning then stop
        if(amountOfTimeSpawn <= 0) return;

        #region finding which hand have gun
        //declaring new gun root varible to store gun ammo
        BNG.RaycastWeapon gun = null;
        
        //looping every grab in array
        for(int i = 0;i<GameManagerClass.instanceT.grab.Length; i++)
        {
            //if grabber holding something and that object has tag gun
            if(GameManagerClass.instanceT.grab[i].HeldGrabbable != null)
            {
                if(GameManagerClass.instanceT.grab[i].HeldGrabbable.gameObject.tag == "Gun")
                {
                    //get gun component from the grabber
                    gun = GameManagerClass.instanceT.grab[i].HeldGrabbable.GetComponent<BNG.RaycastWeapon>();
                }
                
            }
            
        }

        if(gun == null) return;
        
        Debug.Log(gun.name + " , " + gun.gunMagsAmmoBoxStorage.name);
        #endregion
        
        //if gun does not exist then stop logic
        //if(gun == null || gun.gunMagsAmmoBoxStorage) return;
        
        /*
        //checking whether gun ID has exceed length of gun storage array
        if(gun.gunMagAmmoBoxStorageID + 1 < gun.gunMagsAmmoBoxStorage.Length)
        {
            //if it does
            //set gun back to beginning
            gun.gunMagAmmoBoxStorageID = 0;
        }
        */
        //Debug.Log(gun.gunMagsAmmoBoxStorage);
        //spawn gun mag at correct posiiton
        Instantiate(gun.gunMagsAmmoBoxStorage,_spawnPos.transform.position,Quaternion.identity);
        
        amountOfTimeSpawn--;
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(amountOfTimeSpawn <= 0){Destroy(this.gameObject);}
    }

}
