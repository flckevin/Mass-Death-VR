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
    public int delay;
    public ParticleSystem oilParticle;
    public GameObject gunBarrel;
    public OilBehaviour[] oils;
    public LayerMask mask;
    
    private int _oilID;
    // Start is called before the first frame update
    public override void Start()
    {
        
        base.Start();
        //call shoot function
        InvokeRepeating("ShootOil",1,delay);
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
        if(Physics.Raycast(gunBarrel.transform.position,gunBarrel.transform.forward,out ray,Mathf.Infinity,mask))
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
}
