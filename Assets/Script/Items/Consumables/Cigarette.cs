using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class Cigarette : MonoBehaviour
{
    public float healthToIncrease; // amount of health to increase
    public float delay; // amount to delay between
    public float amountOfCig; // amount of cigarette left
    private bool _onMouth; // check whether is only player mouth
    private Rigidbody _cigRigi; // rigi of cig
    private Coroutine smokeCou;// smoke couroutine
    // Start is called before the first frame update
    void Start()
    {
        //storing rigibody
        _cigRigi = this.gameObject.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        //set to be on mouth
        _onMouth = true;
        //check if there any cig left
        CigChecker();
    }

    private void OnTriggerExit(Collider other) 
    {
        //set on mouth to false since it is not on there anymore
        _onMouth = false;
    }

    public void OnActivation(bool _enable)
    {
        //if it not on mouth then stop execute
        if(_onMouth == false) return;
        //set cigeret kinimatic to prevent from falling
        _cigRigi.isKinematic = _enable;
        //if smoke coroutine does exist then stop it
        if(smokeCou != null){StopCoroutine(smokeCou);}
        //if player trying to deactivate smoke then stop
        if(_enable == false) return;
        //else then start smoking
        smokeCou = StartCoroutine(Smoking());
    }

    //smoking behaviour
    IEnumerator Smoking()
    {
        //while is on mouth
        while(_onMouth == true)
        {
            //increase player health
            GameManagerClass.instanceT.playerBehaviour_G.health += healthToIncrease;
            //delay
            yield return new WaitForSeconds(delay);
            //decrease amount of cig left
            amountOfCig--;
            //check amounth of cig left
            CigChecker();

        }
    }


    private void CigChecker()
    {
        //if amount of cig reach to 0
        if(amountOfCig <= 0)
        {
            //destroy object
            Destroy(this.gameObject);
        }
    }
}
