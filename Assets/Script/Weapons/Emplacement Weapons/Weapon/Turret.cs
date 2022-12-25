using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class Turret : EmplacementWeaponBehaviourBaseWithGas
{
    [Header("Turret Info")]
    public Transform barrel;//declare transform for gun barrel positon
    public float fireRate;
    private float _nextFire = 0f;

    public int damageAmount;//declare int for damage amount

   
    public override void WeaponBehaviour()
    {
        //checking whether ray cast hit anything
        if (Physics.Raycast(barrel.position, barrel.forward, out RaycastHit ray, Mathf.Infinity) && Time.time > _nextFire)
        {
            Debug.Log(ray.transform.gameObject.name);
            _nextFire = Time.time + fireRate;
            //checking tag whether is a damage able object
            if (ray.transform.CompareTag("Zombie"))
            {
                //damage to the enemy
                ray.transform.GetComponent<IDamageable>().Damage(damageAmount, ray, false);
            }
        }
        base.WeaponBehaviour();
    }

    public override void OnBeforeDisableWeapon()
    {
        //disable weapon behaviour
        this.enabled = false;
        base.OnBeforeDisableWeapon();
    }

    public override void UpgradeEW()
    {
        base.UpgradeEW();
    }

}
