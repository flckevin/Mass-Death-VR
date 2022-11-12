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
    //function when player grab
    public void OnSpawn(Transform _spawnPos)
    {
        //declaring new gun root varible to store gun ammo
        GunRoot gun = null;
        
        //looping every grab in array
        for(int i = 0;i<GameManagerClass.instanceT.grab.Length; i++)
        {
            //if grabber holding something and that object has tag gun
            if(GameManagerClass.instanceT.grab[i].HeldGrabbable != null && GameManagerClass.instanceT.grab[i].HeldGrabbable.gameObject.tag == "Gun")
            {
                //get gun component from the grabber
                gun = GameManagerClass.instanceT.grab[i].HeldGrabbable.GetComponent<GunRoot>();
            }
            
            //if gun does exist, stop the loop
            if(gun!=null) break;
            
        }
        
        //if gun does not exist then stop logic
        if(gun == null) return;
        //checking whether gun ID has exceed length of gun storage array
        if(gun.gunMagAmmoBoxStorageID + 1 < gun.gunMagsAmmoBoxStorage.Length)
        {
            //if it does
            //set gun back to beginning
            gun.gunMagAmmoBoxStorageID = 0;
        }

        //spawn gun mag at correct posiiton
        gun.gunMagsAmmoBoxStorage[gun.gunMagAmmoBoxStorageID].transform.position = _spawnPos.position;
        //increase ammmo box storage id
        gun.gunMagAmmoBoxStorageID++;
        
    }
}
