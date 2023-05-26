using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
[RequireComponent(typeof(AudioSource))]
public class Barewires : MonoBehaviour,IUpgradeGun
{
    public float slowDownValue; //slow down value
    public float damage; // damage value
    public GameObject stage2Upgrade;
    public AudioClip weaponSound;
    private AudioSource _src;
    private float upgraded;

    private void Awake() 
    {
        _src = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        //if tag is zombie
        if(other.CompareTag("Zombie"))
        {
            _src.PlayOneShot(weaponSound,1);
            //deal daamge to zombie
            other.GetComponent<EnemyBase>().DamageReceiver(damage,other.transform.position,false);
            //decrease zombie speed
            other.GetComponent<NavMeshAgent>().speed -= slowDownValue;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        //if target is zombie
        if(other.CompareTag("Zombie"))
        {
            _src.PlayOneShot(weaponSound,1);
            //deal daamge to zombie
            other.GetComponent<EnemyBase>().DamageReceiver(damage,other.transform.position,false);
            //set speed to default
            other.GetComponent<NavMeshAgent>().speed += slowDownValue;
        }
    }

    void IUpgradeGun.OnFixOnUpgrade()
    {
        if(upgraded > 150) return;

        upgraded++;

        if(upgraded >= 150)
        {
            damage += 10;
            if(stage2Upgrade == null) return;
            stage2Upgrade.SetActive(true);
        }
        
        
    }
}
