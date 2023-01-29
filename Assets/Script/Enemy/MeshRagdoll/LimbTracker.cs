using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: Every zombie's ragdoll limbs
 * Content: track whether zombie limb is stopped moving or touch the ground to convert ragdoll to mesh
 **************************************/
public class LimbTracker : MonoBehaviour
{

    private Rigidbody _limbRig; //to check speed of movement
    private MeshRagdollConvert _meshRagConverter;//convert ragdoll 
    public Transform targetRotation;//storing target to rotate

    // Start is called before the first frame update
    void Start()
    {
        //============ STORING =============

        //rigibody
        _limbRig = this.gameObject.GetComponent<Rigidbody>();

        //meshragdollconvert class
        _meshRagConverter = this.gameObject.GetComponentInParent<MeshRagdollConvert>();

        //============== SETTING ============


    }

    /*
    private void Update() 
    {
        if(_limbRig.velocity.magnitude <= 0 && _meshRagConverter.amountOfLimb != 0)
        {
            _meshRagConverter.amountOfLimb -= 1;
            _meshRagConverter.Convert();

        }
    }
    */

    private void OnCollisionEnter(Collision other) 
    {
        //decrease amount of limb moving
        _meshRagConverter.amountOfLimb -= 1;
        //calling function to convert
        _meshRagConverter.Convert();
    }

    private void OnEnable() 
    {
        //if target rotation does exist
        if(targetRotation != null)
        {
            //rotate to target
            this.transform.localRotation = targetRotation.localRotation;
        }
    }

    /*
    private void OnCollisionExit(Collision other) {
        //if it touches floot
        if(other.gameObject.tag == "Floor" || other.gameObject.tag == "PlaceableFloor" || other.gameObject.tag == "Object")
        {
            //decrease amount of limb moving
            _meshRagConverter.amountOfLimb += 1;
        }
    }
    */

}
