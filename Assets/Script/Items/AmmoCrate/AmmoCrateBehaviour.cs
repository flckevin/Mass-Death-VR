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
        //checking which hand contain gun
        Grabber _handGrab = GameManagerClass.instanceT.rightGrab ?? GameManagerClass.instanceT.leftGrab;
        //declearing gun root to store gun from the hand that holding the gun
        GunRoot _gunMag = null;

        //if hand that grabbing ammo case is right arm
        if(_handGrab == GameManagerClass.instanceT.rightGrab)
        {
            //set gun root to be gun at left hand
            _gunMag = GameManagerClass.instanceT.leftGrab.HeldGrabbable.GetComponent<GunRoot>();
        }
        else //if hand that grabbing ammo case is left arm
        {
            //set gun root to be gun at right hand
            _gunMag = GameManagerClass.instanceT.rightGrab.HeldGrabbable.GetComponent<GunRoot>();
        }

        //if player not holding any gun
        if(_gunMag == null) return;
        //spawn mag at given position
        _gunMag.gunMagsAmmoBoxStorage[_gunMag.gunMagAmmoBoxStorageID].transform.position = _spawnPos.position;
        
        
    }
}
