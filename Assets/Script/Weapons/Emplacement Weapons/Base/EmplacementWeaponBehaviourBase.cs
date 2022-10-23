using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/***************************************
 * Authour: HAN 18080038
 * Object hold: every emplacement weapon in game
 * Content:root of every emplacement weapons
 **************************************/
public class EmplacementWeaponBehaviourBase : MonoBehaviour
{
    [Header("General emplacement weapon info")]
    public float fuelLeft = 100;//declare float for fuel left
    public int damageAmount;//declare int for damage amount
    public Slider fuelSlier;//declare slider for fuel slider
    public EmplacementWeaponPowerSwitch weponSwitcher;//declare emplacement weapon switch to switch power on and off
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if fuel is larger than 0
        if(fuelLeft >= 0) 
        {
            //continue on weapon behaviour
            WeaponBehaviour();
            SliderValueChange();
        }
        else //fuel reach to 0
        {
            //turn off weapon
            weponSwitcher.SwitchFunc();
        }
           
    }

    /// <summary>
    /// 
    /// </summary>
    public virtual void WeaponBehaviour(){ fuelLeft-=10*Time.deltaTime; }

    public virtual void OnShutDown(){ }

    public virtual void OnRestart(){ }

    private void OnUpgrade(int stage) 
    { 
    
    }

    //function to update slider value for gas
    public void SliderValueChange() 
    {
        //updating slider value
        fuelSlier.value = fuelLeft / 100;
        
    }

}
