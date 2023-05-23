using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/***************************************
 * Authour: HAN 18080038
 * Object hold: every emplacement weapon in game
 * Content:root of every emplacement weapons
 **************************************/
public class EmplacementWeaponBehaviourBaseWithGas : MonoBehaviour,IUpgradeGun
{
    [Header("General emplacement weapon info")]

    public EWStats emplacementStats;//declare scriptable object to store weapon stats
    public Slider fuelSlier;//declare slider for fuel slider
    public float amountUpgraded;//amount need to reach before upgrade to next level
    public GameObject[] weaponStages;// all level stages
    public bool machineTurnedOff; //identify state of machine
    public float activationLength; //delay value
    public float deactivationLength; //delay value
    [HideInInspector]public float fuelLeftEW;//store fuel left

    private IEnumerator _cou;//store current couroutine
    private float timePassedMark;//store root time
    protected int _currentStage;//curent stage emplacement weapon at
    

    // Start is called before the first frame update
   
    private void Start()
    {

        VStart();
        //checking whether delay been set
        //if not set to 1 as default
        if(activationLength == 0){activationLength = 1f;}
        //set fuel
        fuelLeftEW = emplacementStats.defaultFuel;
        //set emplacement weapon to be ew with gas
        this.gameObject.tag = "EW_gas";
        //fire machine
        _cou = StartEW();
        //fire machine back up
        StartCoroutine(_cou);
        
    }

    public virtual void VStart(){}

    public void OnEnableSwitch() 
    {
        //if machine been turned off
        if(machineTurnedOff == true)
        {
            //set bool to identify machine state
            machineTurnedOff = false;
            //fire machine back up
            StartCoroutine(_cou);
        }
        else
        {
            //set bool to identify machine state
            machineTurnedOff = true;
            //update new gas value
            StopCoroutine(_cou);
        }
        
    }

    IEnumerator StartEW()
    {
        while (fuelLeftEW > 0)
        {
            //continue on weapon behaviour
            WeaponBehaviour();
            //decrease fuel
            fuelLeftEW -= emplacementStats.fuelToDecrease;
            //updating slider value
            fuelSlier.value = fuelLeftEW / 100;
            yield return new WaitForSeconds(activationLength);
            OnDisableWeapon();
            yield return new WaitForSeconds(deactivationLength);
        }
        //identify state of machine
        machineTurnedOff = true;
        //turn off weapon
        StopCoroutine(_cou);
    }

    public virtual void WeaponBehaviour()
    {
        //decrease gas
        fuelLeftEW -= emplacementStats.fuelToDecrease *Time.deltaTime; 
        
    }

    public virtual void OnDisableWeapon(){}

    private void UpdateGas()
    {
         //declare float to calculate time have passed
        float _currentTime = (int)Time.time - timePassedMark;
        //marking new time
        timePassedMark = (int)Time.time;
        //setting new fuel value using new time
        fuelLeftEW -= (emplacementStats.fuelToDecrease)* timePassedMark;
    }

    public virtual void OnUpgradeEW()
    {
        //if stage reach to limit
        if(_currentStage >= weaponStages.Length - 1) return; 
        //increase stage of upgrade
        amountUpgraded+=0.2f;
        //update amount upgraded on screen
        GameManagerClass.instanceT.upgradeGun.progressSlider.value = (Mathf.Round(amountUpgraded)/emplacementStats.amountToUpgrade);

        //if stage reach to required amount
        if(amountUpgraded >= emplacementStats.amountToUpgrade)
        {
            //increase current stage
            _currentStage ++;
            //deactivate last stage
            weaponStages[_currentStage-1].SetActive(false);
            //activate next stage
            weaponStages[_currentStage].SetActive(true);
            //set stage back to default
            amountUpgraded = 0;
            
        }
        
       
            
    }

    public void OnFixOnUpgrade()
    {
        OnUpgradeEW();
    }

    //ontrigger enter if it hammer (max health upgrade, low health fix)
}
