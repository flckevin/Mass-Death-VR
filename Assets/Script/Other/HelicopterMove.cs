using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class HelicopterMove : MonoBehaviour
{
    public Transform[] pos; // destinations
    public float speed; //speed
    public string callType; // call types extract or start missions
    public GameObject playerUltilities;
    public GameObject lHand;
    public GameObject Rhand;
    public Transform heliInt;
    public GameObject indicator;
    public BNG.ScreenFader screenFader;
    // Start is called before the first frame update
    void Start()
    {
        callType = "Intro";
        playerUltilities.SetActive(false);
        lHand.SetActive(false);
        Rhand.SetActive(false);
        
        Move(pos[0],pos[1],pos[2],90,() =>
        {
            //unparent player from helicopter
            GameManagerClass.instanceT.playerRoot.transform.parent = null;
            //set player posiition to be at start posiion
            GameManagerClass.instanceT.playerBehaviour_G.transform.position = GameManagerClass.instanceT.playerStartPos.position;
            //enable player rigibody
            //the reason to disable was player going coconut while riding helicopter
            GameManagerClass.instanceT.playerRigi.isKinematic = true;
            //enable player gravity
            //yes event player gravity for some reason
            GameManagerClass.instanceT.playerRigi.useGravity = true;
            //enable player controller
            //why the hell even player controller but yes
            GameManagerClass.instanceT.playerController.enabled = true;
            StartCoroutine(Intro());},0.6f);
    }

    IEnumerator Intro()
    {
        
        
        //activate player's utilities
        playerUltilities.SetActive(true);
        //enable player hands
        lHand.SetActive(true);
        Rhand.SetActive(true);
        //enable mission indicator
        indicator.SetActive(true);
        yield return new WaitForSeconds(1f);
        Move(pos[2],pos[1],pos[0],0,()=>{this.gameObject.SetActive(false);});
        callType = "Home";
        LeanTween.rotate(this.gameObject,new Vector3(0,-90,0),speed);
        yield return new WaitForSeconds(1.5f);
        //polay audio clip of player onstart wave
        AudioManager.instanceT.PlayOneShot(AudioManager.instanceT.commonClip[2].clip,1);
        
       
    }



    public void Move(Transform _start,Transform _mid, Transform _end,float _startRotationY = 0,Action _action = null,float _extraTime = 0.5f)
    {
        StartCoroutine(MoveExecute(_start,_mid,_end, _startRotationY = 0,_action,_extraTime));

    }

    IEnumerator MoveExecute(Transform _start,Transform _mid, Transform _end,float _startRotationY = 0, Action _action = null,float _extraTime = 0)
    {
        
        //transform heli back to start
        this.transform.position = _start.localPosition;
        

        //move to mid
        LeanTween.move(this.gameObject,_mid.localPosition,speed);
        
        //wait to reach to goal
        yield return new WaitForSeconds(speed+_extraTime);

        if (callType == "Intro")
        {
            StartCoroutine(LerpColor(1, true, speed - 0.5f));

        }
        
        //move to end
        LeanTween.move(this.gameObject,_end.localPosition,speed);

        //wait to finish
        yield return new WaitForSeconds(speed+_extraTime);
        if (callType == "Intro")
        {
            StartCoroutine(LerpColor(0,false,0));

        }
        if (_action != null)
        {
            //call extra function
            _action();
        }
        
    }

    IEnumerator LerpColor(float _to , bool fadeIn, float delay) 
    {

        yield return new WaitForSeconds(delay);
        screenFader.FadeColor = new Color(screenFader.FadeColor.r,
                                                  screenFader.FadeColor.g,
                                                   screenFader.FadeColor.b,
                                                   _to);
        

        switch (fadeIn) 
        {
            case true:
                screenFader.DoFadeIn();
                break;

            case false:
                screenFader.DoFadeOut();
                break;
            
        }
    }


    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            if(callType == "Extract")
            {
                LoadScene.Load(LoadScene.Scene.PlayerHub);
            }
        }
    }

    
    
   
}
