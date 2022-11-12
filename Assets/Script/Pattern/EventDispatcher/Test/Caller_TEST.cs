using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreEvent;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class Caller_TEST : MonoBehaviour
{
    private void Start() {
        
        //Debug.Log("Called " + this.gameObject.name);
        StartCoroutine(CallFunc());
    }

    IEnumerator CallFunc()
    {
        yield return new WaitForSeconds(2);
        EventDispatch.instanceT.CallFunction(EventsType.Test);
    }
}
