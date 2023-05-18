using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
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

    public Transform heliInt;
    // Start is called before the first frame update
    void Start()
    {
        Move(pos[0],pos[1],pos[2],0,1,() =>
        {GameManagerClass.instanceT.playerRoot.transform.parent = null;
        GameManagerClass.instanceT.playerBehaviour_G.transform.position = GameManagerClass.instanceT.playerStartPos.position;
        GameManagerClass.instanceT.playerRigi.isKinematic = true;
        GameManagerClass.instanceT.playerRigi.useGravity = true;
        GameManagerClass.instanceT.playerController.enabled = true;
        this.gameObject.SetActive(false);},0.6f);
    }



    public void Move(Transform _start,Transform _mid, Transform _end,float _rotationY = 0,float _doorPosX = 0,Action _action = null,float _extraTime = 0.5f)
    {
        StartCoroutine(MoveExecute(_start,_mid,_end, _rotationY = 0,_doorPosX = 0,_action,_extraTime));

    }

    IEnumerator MoveExecute(Transform _start,Transform _mid, Transform _end,float _rotationY = 0,float _doorPosX = 0, Action _action = null,float _extraTime = 0)
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

        //call extra function
        _action();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            if(callType == "Extract")
            {
                Move(pos[0],pos[1],pos[2],-90,-2,() =>
                {GameManagerClass.instanceT.playerRoot.transform.parent = this.transform;
                GameManagerClass.instanceT.playerBehaviour_G.transform.position = heliInt.position;
                GameManagerClass.instanceT.playerRigi.isKinematic = false;
                GameManagerClass.instanceT.playerRigi.useGravity = false;
                GameManagerClass.instanceT.playerController.enabled = false;}, + 0.6f);
            }
        }
    }
    
   
}
