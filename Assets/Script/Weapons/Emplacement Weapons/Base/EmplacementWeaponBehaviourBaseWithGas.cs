using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/***************************************
 * Authour: HAN 18080038
 * Object hold: every emplacement weapon in game
 * Content:root of every emplacement weapons
 **************************************/
public class EmplacementWeaponBehaviourBaseWithGas : MonoBehaviour,IHammerAble
{
    [Header("General emplacement weapon info")]

    public EWStats emplacementStats;//declare scriptable object to store weapon stats
    public Slider fuelSlier;//declare slider for fuel slider
    public GameObject fuelCap;
    public BoxCollider pipeCol;
    public int amountUpgraded;
    private int currentStage;
    public GameObject[] weaponStages;
    public EmplacementWeaponFuel ewFuel;

    // Start is called before the first frame update
    public virtual void Start(){}

    private void OnEnable() 
    {
        //update new gas value
       ewFuel.UpdateGasOnTime();
    }

    // Update is called once per frame
    void Update()
    {
        //if fuel is larger than 0
        if(ewFuel.fuelLeftEW >= 0) 
        {
            //continue on weapon behaviour
            WeaponBehaviour();
            SliderValueChange();
        }
        else //fuel reach to 0
        {
            //turn off weapon
            EmplacementWeaponPowerSwitch weaponSwitch = new EmplacementWeaponPowerSwitch();
            weaponSwitch.SwitchFunc(this);
        }
           
    }

    public virtual void UpgradeEW()
    {
        //if stage reach to limit
        if(amountUpgraded == weaponStages.Length) return; 
        //increase stage of upgrade
        amountUpgraded++;
        //if stage reach to required amount
        if(amountUpgraded == emplacementStats.amountToUpgrade)
        {
            //increase current stage
            currentStage ++;
            //deactivate last stage
            weaponStages[currentStage-1].SetActive(false);
            //activate next stage
            weaponStages[currentStage].SetActive(true);
            //set stage back to default
            amountUpgraded = 0;
            
        }
        
            
    }

    public virtual void WeaponBehaviour(){ ewFuel.fuelLeftEW -= emplacementStats.fuelToDecrease *Time.deltaTime; }

    public virtual void OnBeforeDisableWeapon(){}
    public virtual void OnEnableWeapon(){}

    //function to update slider value for gas
    public void SliderValueChange() 
    {
        //updating slider value
        fuelSlier.value = ewFuel.fuelLeftEW / 100;
        
    }

    public void OnUpgrade()
    {
        UpgradeEW();
       
    }

    public void OnFix()
    {
        throw new System.NotImplementedException();
    }
}
