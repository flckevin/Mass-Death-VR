using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: every non fuel emplacement weapons
 * Content: non fuel emplacement weapons base
 **************************************/
public class NonFuelEmplacementWeaponsBase : MonoBehaviour,IUpgradeGun
{
    // Start is called before the first frame update
   [SerializeField] protected bool _ableToUse;//declare bool to check wheter be able to use
    protected bool _used;//declare bool to check whether player have used item
    protected int _newWeaponID = 0;
    protected float _upgraded;
    protected int _NewWeaponID
    {
        get{return _newWeaponID;}
        set{ if(_newWeaponID >= newWeapon.Length -1){_newWeaponID = newWeapon.Length;} }
    }

    [Header("EW GENERAL INFO")]
    public NonFuelEwStats ewStats;

    [Header("EW UPGRADE INFO")]
    
    public GameObject[] newWeapon;
    

    public virtual void Start() 
    {
        //start machine behaviour
        StartCoroutine(MachineHandler());
    }

    public virtual void OnInitiate(bool _activation)
    {

    }

    public virtual void OnActivation(bool _activation) 
    { 
    
    }

    private void Upgrade()
    {
        //increase upgrade percentage
        _upgraded++;
        //displaying upgrade progress on upgrade gun screen
        GameManagerClass.instanceT.upgradeGun.progressSlider.value = (Mathf.Round(_upgraded)/ewStats.upgradeCost);
        //if upgrade value reach enough
        if(_upgraded >= ewStats.upgradeCost)
        {
            //call upgrade function
            OnUpgrade();   
        }
    }

    public virtual void OnUpgrade()
    {
        //set upgrade percentage back to 0
        _upgraded = 0;
        //deactivate old weapon
        newWeapon[_NewWeaponID].SetActive(false);
        _NewWeaponID++;
        //activate new weapons
        newWeapon[_NewWeaponID].SetActive(true);
        
        
        
    }

    IEnumerator MachineHandler()
    {

        while(true)
        {
            //initiate
            OnInitiate(true);
            yield return new WaitForSeconds(ewStats.initiationLength + 0.3f);
            //activate
            OnActivation(true);
            
            //deactivate
            yield return new WaitForSeconds(ewStats.activationLength);
            OnActivation(false);
            OnInitiate(false);

            //delay
            yield return new WaitForSeconds(ewStats.delay);
        }
        
        
        
    }

    public void OnFixOnUpgrade()
    {
        Upgrade();
    }
}
