using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class LaserGun : EmplacementWeaponBehaviourBaseWithGas
{
    public GameObject laser;
    public override void WeaponBehaviour()
    {
        laser.SetActive(true);
        base.WeaponBehaviour();
    }

    public override void OnDisableWeapon()
    {
        laser.SetActive(false);
        base.OnDisableWeapon();
    }

    IEnumerator AudioCou()
    {
        while(laser.activeSelf == true)
        {
            if(!_src.isPlaying)
            {
                _src.PlayOneShot(weaponSound,1);
            }
            yield return null;
        }

        _src.Stop();
    }

    public override void OnUpgradeEW()
    {
        base.OnUpgradeEW();
        laser = weaponStages[_currentStage].transform.GetChild(0).gameObject;
    }

}
