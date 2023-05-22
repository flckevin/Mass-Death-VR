using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: oil gun
 * Content: oil gun behaviour
 **************************************/
public class OilGun : EmplacementWeaponBehaviourBaseWithGas
{
    [Header("Oil gun info")]
    
    public ParticleSystem oilParticle; //oil particle
    public Rigidbody oilBullet; // oil gun bullet
    public Transform muzzel; // oil gun muzzel
    public float force; // oil gun force
    // Start is called before the first frame update
   
    private void ShootOil()
    {
        //if oil bullet does eixst
        if(oilBullet == null) return;
        //set oil bullet at muzzel position
        oilBullet.transform.position = muzzel.position;
        //activate oil bullet
        oilBullet.gameObject.SetActive(true);
        //add force to oil bullet
        oilBullet.velocity = muzzel.transform.forward * force;
    }

    public override void WeaponBehaviour()
    {
        ShootOil();
        base.WeaponBehaviour();
    }
}
