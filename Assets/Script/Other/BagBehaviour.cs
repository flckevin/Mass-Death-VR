using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class BagBehaviour : MonoBehaviour
{
    public Rigidbody[] items;
    public Transform spawnPos;
    public Transform bagRootPosition;
    public Vector3 rootRotation;
    private int itemID;
    private int ItemID
    {
        get{return itemID;}
        set
        {
            if(itemID > items.Length -1 )
            {
                itemID = 0;
            }
            else
            {
                itemID = value;
            }
        }
    }
    private Rigidbody _bagRigi;

    private void Start() {
        _bagRigi = this.gameObject.GetComponent<Rigidbody>();
    }

    public void Onspawn()
    {
        if(items.Length < 0) return;
        ItemID++;
        items[ItemID].transform.position = spawnPos.position;
        items[ItemID].AddRelativeForce(spawnPos.up*50);
    }

    public void OnRelease()
    {
        _bagRigi.isKinematic = true; 
        this.transform.localPosition = bagRootPosition.localPosition;
    }

    public void OnGrab()
    {
         _bagRigi.isKinematic = false; 
    }
    
}
