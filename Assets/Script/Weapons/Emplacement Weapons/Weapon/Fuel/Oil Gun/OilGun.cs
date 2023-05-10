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
    public OilBehaviour[] oils; // oils
    public LayerMask mask;// layer
    private int _oilID; // oil ID to store
    // Start is called before the first frame update

    public override void VStart()
    {
        base.VStart();
        delay = 3;
    }

    private void ShootOil()
    {
        //if oil ID is larger than oil length
        if(_oilID >= oils.Length - 1)
        {
            //set oil id to 0
            _oilID = 0;
        }

        //declare new ray cast for info
        RaycastHit ray;

        //if raycast hit some thing get info
        if(Physics.Raycast(this.transform.localPosition,this.transform.forward,out ray,Mathf.Infinity,mask))
        {

           // Debug.DrawRay(gunBarrel.transform.position,gunBarrel.transform.forward,Color.green,1);

           //if ray cast hit something that still exist
            if(ray.transform != null)
            {
                //set location of the oil to be at location of raycast hit
                oils[_oilID].transform.localPosition = transform.InverseTransformPoint(ray.point);
            }
        }

        //activate oil
        oils[_oilID].gameObject.SetActive(true);
        //scale object back
        oils[_oilID].gameObject.transform.localScale = new Vector3(1,1,1);
         //if there's oil particle
        if(oilParticle != null)
        {
            //play oil particle
            oilParticle.Play();
        }
        //increase oil id
        _oilID++;
    }

    public override void WeaponBehaviour()
    {
        ShootOil();
        base.WeaponBehaviour();
    }
}
