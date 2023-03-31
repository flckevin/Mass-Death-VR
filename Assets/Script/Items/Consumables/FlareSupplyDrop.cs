using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: falre
 * Content: falre behaviour
 **************************************/
public class FlareSupplyDrop : ConsumableItem
{
    public GameObject cap;//declare gameobject to store cap of the flare
    public GameObject supply;//decalre gameobject to spawn supply drop
    public ParticleSystem flareParticle;//declare particle system to play flare particle
    // Start is called before the first frame update

    private void Start()
    {
        //set able to use to false
        //_ableToUse = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //checking whether the flare able to use and have not been dropped on the ground
        if(_ableToUse == true) 
        { 
            if(supply == null){Destroy(this.gameObject);return;}
            //spawn supply drop
            Instantiate(supply,new Vector3(this.transform.position.x,20,this.transform.position.z),Quaternion.identity);
            //set dropped to true
            _ableToUse = false;
            //startcouroutine for flare deactivateion
            StartCoroutine(Deactivate());
        }
    }

    /// <summary>
    /// fucntion to turn on lights
    /// </summary>
    public void TurnOnLight()
    {
        //if cap does exist
        if (cap != null)
        {
            //deactivate cap
            cap.SetActive(false);
            //play flare particle
        }
        //set able to use to true to prevent second time of supply drop
        _ableToUse = true;
        //activate particle
        flareParticle.gameObject.SetActive(true);
        //play particle system
        flareParticle.Play();
    }

    /// <summary>
    /// function to deactivate flares
    /// </summary>
    /// <returns></returns>
    IEnumerator Deactivate() 
    {
        //wait for 1 sec
        yield return new WaitForSeconds(5f);
        //deactivate flare
        this.gameObject.SetActive(false);

    }

    /// <summary>
    /// function to reset everything (inherited)
    /// </summary>
    public override void OnSetDefaultItem()
    {
        //set able to use to false
        _ableToUse = false;
    }
}
