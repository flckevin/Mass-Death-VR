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
    // Start is called before the first frame update
    void Start()
    {
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
        yield return new WaitForSeconds(1f);
        Move(pos[2],pos[1],pos[0],0,()=>{this.gameObject.SetActive(false);});
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

        //move to end
        LeanTween.move(this.gameObject,_end.localPosition,speed);
        //wait to finish
        yield return new WaitForSeconds(speed+_extraTime);

        if(_action != null)
        {
            //call extra function
            _action();
        }
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            if(callType == "Extract")
            {
                SceneManager.LoadScene("PlayerHub");
            }
        }
    }
    
   
}
