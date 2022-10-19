using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fuelLeft >= 0) 
        {
            WeaponBehaviour();
        }
        else 
        {
            this.enabled = false;
        }
           
    }

    /// <summary>
    /// 
    /// </summary>
    public virtual void WeaponBehaviour(){ fuelLeft--; }

    public virtual void OnShutDown(){ }

    public virtual void OnRestart(){ }

    private void OnUpgrade(int stage) 
    { 
    
    }

}
