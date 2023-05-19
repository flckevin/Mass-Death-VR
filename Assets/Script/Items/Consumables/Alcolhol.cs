using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************
 * Authour: HAN 18080038
 * Object hold: consumable items drinks
 * Content: alcolhol behaviour
 **************************************/
public class Alcolhol : ConsumableItem
{
    [Range(0,50)]public float amountInDrinkLeft; // amount of drinks left
    public GameObject cap; // acohol cap
    private bool drunkCouActivated; // identify whether coroutine activated
    [Range(0,2)]public float healthRegenerate; // health that able to regenerate
    protected override void Start()
    {
        
        base.Start();
    }
    public override void OnEnable()
    {
        // if there still drink left
        if(amountInDrinkLeft > 0)
        {
            //able to drink
            _ableToUse = true;
            //deactivate cap as opened
            if(cap == null)return;
            cap.SetActive(false);
        }

        base.OnEnable();
    }

    public override void OnDisableItem()
    {
        //not able to drink
        _ableToUse = false;
        //deactivate cap
        if(cap == null)return;
        cap.SetActive(true);
        base.OnDisableItem();
    }

    

    private void OnTriggerEnter(Collider other) 
    {
    
        Debug.Log("NAME: " + other.gameObject.name +" TAG: " + other.gameObject.tag);
        //if it touch player mouth
        if(other.gameObject.tag == "MainCamera" && _ableToUse == true)
        {
            //drink
            OnUseItem();
            //start drunk behaviour
            if(drunkCouActivated == true) return;
            StartCoroutine(SideEffect());
        }
        //if there is not drink left
        if(amountInDrinkLeft <= 0)
        {
            //destroy object on next touch
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        //if it touch player mouth
        if(other.gameObject.tag == "MainCamera" && _ableToUse == true)
        {
            //drink
            OnUseItem();
            Debug.Log(amountInDrinkLeft);
        }
    }

    //drink behaviour
    public override void OnUseItem()
    {
        //increase player posioness
        GameManagerClass.instanceT.playerBehaviour_G.poison++;
        //decrease amount of liquid in acolhol
        amountInDrinkLeft-=1;
        //regenerate player's health
        GameManagerClass.instanceT.playerBehaviour_G.health += healthRegenerate*Time.deltaTime;
        //start drunk behaviour
        if(drunkCouActivated == true) return;
        //increase health
        StartCoroutine(SideEffect());
        base.OnUseItem();
    }

    

    IEnumerator SideEffect()
    {
        //set drunk activated to true to prevent second time of calling
        drunkCouActivated = true;
        //while player still have position
        while(GameManagerClass.instanceT.playerBehaviour_G.poison > 0)
        {
            //random vomit next delay
            float rand = UnityEngine.Random.Range(10,15);
            //wait with given delay
            yield return new WaitForSeconds(rand);
            //disable player controller
            GameManagerClass.instanceT.playerController.enabled = false;
            //set vomit position
            PoolManager.instanceT.vomit[PoolManager.instanceT.VomitID].transform.position = GameManagerClass.instanceT.playerCam.transform.position;
            //activate vomit
            PoolManager.instanceT.vomit[PoolManager.instanceT.VomitID].gameObject.SetActive(true);
            //play vomit
            PoolManager.instanceT.vomit[PoolManager.instanceT.VomitID].Play();
            //wait until vomit effect finished
            yield return new WaitForSeconds(PoolManager.instanceT.vomit[PoolManager.instanceT.VomitID].main.duration + 0.5f);
            //increase vomit ID
            PoolManager.instanceT.VomitID++;
            //enable player controller again
            GameManagerClass.instanceT.playerController.enabled = true;
            //decrease player poision
            GameManagerClass.instanceT.playerBehaviour_G.poison -= 1;
            yield return null;

        }
        //deactivate so it can call it again
        drunkCouActivated = false;
       //set cam back to default
    }

}
