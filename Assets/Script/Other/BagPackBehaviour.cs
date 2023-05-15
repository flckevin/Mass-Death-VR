using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class BagPackBehaviour : MonoBehaviour
{
    private Rigidbody _bagRigi;

    public Transform bagRootPosition;

    private void Start() 
    {
        _bagRigi = this.gameObject.GetComponent<Rigidbody>();
    }
    public void OnRelease()
    {
        _bagRigi.isKinematic = true;
        this.transform.rotation = Quaternion.identity;
        this.transform.localPosition = bagRootPosition.localPosition;
    }

    public void OnGrab()
    {
        _bagRigi.isKinematic = false;
    }
}
