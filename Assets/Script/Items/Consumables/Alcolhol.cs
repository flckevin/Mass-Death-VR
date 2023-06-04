using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************
 * Authour: HAN 18080038
 * Object hold: consumable items drinks
 * Content: alcolhol behaviour
 **************************************/
 [RequireComponent(typeof(AudioSource))]
public class Alcolhol : ConsumableItem
{
    [Range(0,50)]public float amountInDrinkLeft; // amount of drinks left
    public GameObject cap; // acohol cap
    public MeshRenderer drinkMesh; // mesh of drink
    public BoxCollider drinkCol; // collider of drink
    public AudioClip drinkClip;
    public AudioClip vommitClip;
    public AudioClip openingSound;
    private bool drunkCouActivated; // identify whether coroutine activated
    private AudioSource _audioSrc; // audio source to play drinking and vomit
    [Range(0,2)]public float healthRegenerate; // health that able to regenerate
    protected override void Start()
    {
        _audioSrc = this.gameObject.GetComponent<AudioSource>();
        base.Start();

    }
    public override void OnEnable()
    {
        _audioSrc.PlayOneShot(openingSound,1);
        //able to drink
        _ableToUse = true;
        //deactivate cap as opened
        if(cap == null)return;
        cap.SetActive(false);
        base.OnEnable();
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
        CheckLiquid();
    }

    private void OnTriggerStay(Collider other) 
    {
        //if it touch player mouth
        if(other.gameObject.tag == "MainCamera" && _ableToUse == true)
        {
            //drink
            OnUseItem();
            //play drinking audio
            if(_audioSrc != null && !_audioSrc.isPlaying){_audioSrc.PlayOneShot(drinkClip,1);}
            Debug.Log(amountInDrinkLeft);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        CheckLiquid();
    }

    void CheckLiquid()
    {
        //if there is still drink left then stop execute down here
        if(amountInDrinkLeft > 0) return;
        //if there aren't any drinks left
        if(drunkCouActivated == false)
        {
            Destroy(this.gameObject);
        }
        //if there arent' any drink left but the couroutine still being active (side effect)
        else if(drunkCouActivated == true)
        {
            //deactivate collision
            drinkCol.enabled = false;
            //deactivate mesh
            drinkMesh.enabled = false;
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
        float healthReceived = healthRegenerate*Time.deltaTime;
        GameManagerClass.instanceT.playerBehaviour_G.OnReciveHealth(healthReceived);
        //start drunk behaviour
        if(drunkCouActivated == true) return;
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
            //play vommit audio
            if(_audioSrc != null){_audioSrc.PlayOneShot(vommitClip,1);}
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
        CheckLiquid();
       //set cam back to default
    }

}
