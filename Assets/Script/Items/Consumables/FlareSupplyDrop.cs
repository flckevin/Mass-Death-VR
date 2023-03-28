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
    private bool _dropped; //declare bool to check whether flare have been dropped on the ground
    public GameObject cap;//declare gameobject to store cap of the flare
    // Start is called before the first frame update

    private void Start()
    {
        //set able to use to false
        _ableToUse = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //checking whether the flare able to use and have not been dropped on the ground
        if(_ableToUse == true && _dropped == false) 
        { 
            //if supply drop id does exceed the length
            if(PoolManager.instanceT.supplyDropID + 1 > PoolManager.instanceT.supplyDropG_Supply.Length) 
            {
                //set supply drop back to beginning
                PoolManager.instanceT.supplyDropID = 0;
            }

            //transform the supply drop to the flare position
            PoolManager.instanceT.supplyDropG_Supply[PoolManager.instanceT.supplyDropID].transform.position = new Vector3(this.transform.position.x, 
                                                                                                                                20, this.transform.position.y);
            //activate the supply
            PoolManager.instanceT.supplyDropG_Supply[PoolManager.instanceT.supplyDropID].SetActive(true);
            //increase the supply drop ID
            PoolManager.instanceT.supplyDropID++;
            //set dropped to true
            _dropped = true;
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
    }

    /// <summary>
    /// function to deactivate flares
    /// </summary>
    /// <returns></returns>
    IEnumerator Deactivate() 
    {
        //wait for 1 sec
        yield return new WaitForSeconds(1f);
        //deactivate flare
        this.gameObject.SetActive(false);

    }

    /// <summary>
    /// function to reset everything (inherited)
    /// </summary>
    public override void OnSetDefaultItem()
    {
        //set dropped to false
        _dropped = false;
        //set able to use to false
        _ableToUse = false;
    }
}
