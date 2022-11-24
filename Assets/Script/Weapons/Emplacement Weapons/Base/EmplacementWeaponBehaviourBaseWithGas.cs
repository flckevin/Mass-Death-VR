using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/***************************************
 * Authour: HAN 18080038
 * Object hold: every emplacement weapon in game
 * Content:root of every emplacement weapons
 **************************************/
public class EmplacementWeaponBehaviourBaseWithGas : MonoBehaviour,IEmplacementWeapons
{
    [Header("General emplacement weapon info")]

    public EWStats emplacementStats;//declare scriptable object to store weapon stats
    public Slider fuelSlier;//declare slider for fuel slider
    public GameObject fuelCap;
    public BoxCollider pipeCol;
    public int stage;
    public int Stage
    {
        get{return stage;}
        set{if(stage > stage + 1)stage = stages_G.Length;}
    }
    public GameObject[] stages_G;
    

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
        //increase stage of upgrade
        stage++;
        if(stage >= emplacementStats.amountToUpgrade)
        {
            //deactivate last stage
            stages_G[stage-1].SetActive(false);
            //activate next stage
            stages_G[stage].SetActive(true);
            //set stage back to default
            stage = 0;
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
        throw new System.NotImplementedException();
    }
}
