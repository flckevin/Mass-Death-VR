using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class StickyFloor : MonoBehaviour,IUpgradeGun
{
    public AudioClip floorClip;
    public int maxZombieIn; // maximum amount of zombie able to be in
    [SerializeField] private int _currentZombieIn; // current amount of zombie currently in
    private AudioSource _src;
    private float _upgraded;

    private void Awake() 
    {
        _src = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Zombie" && _currentZombieIn < maxZombieIn)
        {
            _src.PlayOneShot(floorClip,1);
            //increase amount of current zombie in
            _currentZombieIn++;
            //get ai
            NavMeshAgent _ai = other.GetComponent<NavMeshAgent>();
            //stop AI
            _ai.velocity = Vector3.zero;
            _ai.Stop();
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        //if zombie exit trigger
        if(other.gameObject.tag == "Zombie")
        {
            //decrease amount of zombie currently in
            _currentZombieIn--;
        }
    }

    void IUpgradeGun.OnFixOnUpgrade()
    {
        if(_upgraded >= 200) return;

        _upgraded++;
        if(_upgraded >= 200)
        {
            this.gameObject.transform.localScale = new Vector3(2,2,2);
        }
    }
}
