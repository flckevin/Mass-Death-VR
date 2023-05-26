using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: Landmine
 * Content: Landmine behaviour
 **************************************/
 [RequireComponent(typeof(Rigidbody))]
public class Landmine : MonoBehaviour
{
    public AudioClip explosionClip;
    public MeshRenderer mesh;
    public BoxCollider boxCol;
    private bool _ableToUse;
    private bool _grounded; // declare bool to check whether the landmine is grounded
    private AudioSource _src;

    private void Awake() 
    {
        _src = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision obj) 
    {
        //checking whether landmine touched on the floor
        if(obj.gameObject.CompareTag("PlaceableFloor"))
        {
            //set grounded to true
            _grounded = true;
        }
       
        //if object has tag damageable
        if(obj.gameObject.CompareTag("Zombie") && _ableToUse == true)
        {
             //set explosion position
            PoolManager.instanceT.explosion[PoolManager.instanceT.ExplosionID].transform.position = this.transform.position;
            //activate explosion explosion
            PoolManager.instanceT.explosion[PoolManager.instanceT.ExplosionID].gameObject.SetActive(true);
            //play explosion
            PoolManager.instanceT.explosion[PoolManager.instanceT.ExplosionID].Play();
            //increase explosion ID
            PoolManager.instanceT.ExplosionID++;
            //create a new overlap collider
            Collider[] damageableCollide = Physics.OverlapSphere(this.transform.position,4f);
            //loop every object in the array of collider
            for(int i =0;i< damageableCollide.Length;i++)
            {
                //if the gameobject has tag damageable
                if(damageableCollide[i].gameObject.tag == "Zombie" || damageableCollide[i].gameObject.tag == "Damageable")
                {
                    //call damage function
                    damageableCollide[i].GetComponent<IDamageable>().Damage(99999,true);
                }
            }

            mesh.enabled = false;
            boxCol.enabled = false;
            _src.PlayOneShot(explosionClip,1);
            //explode
            Destroy(this.gameObject,explosionClip.length + 0.5f);
        }
 
    }

    private void OnCollisionExit(Collision obj) 
    {
        //checking whether it was a floor
        if(obj.gameObject.CompareTag("PlaceableFloor"))
        {
            //set grounded back to false
            _grounded = false;
        }
    }

    //activate function
    public void OnInitiate()
    {
        //if landmine lying on ground
        if(_grounded == true)
        {
            //activate landmine explostion
            _ableToUse = true;
            //set iskinimatic to true to disable rigibody
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //disable grabble script to prevent from player grabbing it
            this.gameObject.GetComponent<BNG.Grabbable>().enabled = false;
            
        }
        
    }
}
