using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreEvent;

/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class Subcriber_TEST : MonoBehaviour
{
    private void Start() 
    {
       EventDispatch.instanceT.Addevent(CoreEvent.EventsType.Test, function => TestFunc());
    }

    void TestFunc()
    {
        Debug.Log("HEllO");
    }
}
