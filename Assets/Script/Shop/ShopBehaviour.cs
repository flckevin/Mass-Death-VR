using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/***************************************
 * Authour: HAN 18080038
 * Object hold: shop
 * Content: shop behaviour
 **************************************/
public class ShopBehaviour : MonoBehaviour
{
    [Header("SHOP INFO")]
    public PageContentHolder[] shopSections;//array of shop sections
    private int _currentShopSectionPage;//current shop section page
    
    public GameObject[] shopPages;//array of shop pages
    [SerializeField]private int _currentShopPage;//shop current page

    public Transform posToSpawnObject;//position to spawn objects
    [Space(10)]

    [Header("SHOP COMPONENTS")]
    public GameObject shopCurtain;//shop curtain
    //public Transform lean_CurtainPos;//shop curtain leantweenPos

    public Transform lean_ItemSectionDisplayPos;//postion to lean 
    public Transform lean_ItemSectionHidePos;//position to lean
    [Space(10)]
    
    [Header("SHOP COMPONENTS_SHOP UI")]
    public Text nameText;//name of item
    public Text priceText;//text to display price
    public Text moneyDisplayText;//text to display current money
    public Text description;//text to display description

    [HideInInspector]public bool machineStarted;
    [HideInInspector]public GameObject ObjToSpawn;//object ot spawn
    [HideInInspector] public int price;//price of item

    private bool _isChanging = false; // preventing multiple time of pressing a button


    private void Start()
    {
        //assign shop page and section
        _currentShopSectionPage = 0;
        _currentShopPage = 0;
        //activate shop first section
        shopSections[_currentShopSectionPage].gameObject.SetActive(true);
        //activate shop first page
        shopPages = shopSections[_currentShopPage].pages;    
    }

    //function to change shop pages
    private void OnPageChange(int value = 0)
    {
        //store old page and new page values
        int _oldPage = _currentShopPage;
        int _newPage = _currentShopPage + value;

        //checking whether new page exceed length of array or is -1, if it is then stop execute 
        if(_newPage >= shopPages.Length || _newPage < 0) return;

        //declare local gameobject to store old and new shop pages
        GameObject _oldPageG = shopPages[_oldPage];
        GameObject _newpageG = shopPages[_newPage];

        //set is changing to true to prevent multiple time of pressing button
        _isChanging = true;

        //use leantween to move curtain up to close
        //ShopDisplay(false,1);

        //checking of old page does exist
        if(_oldPage == -1 || _oldPage > shopPages.Length)
        {   //if it does not
            //set old page to null since the player
            //could be first time opening vending machine
            _oldPageG = null;
        }

        //start executing shop display
        StartCoroutine(ShopDisplayExecute(1,_oldPageG,_newpageG));
        //store current page
        _currentShopPage = _newPage;
        
    }


    //function to change shop sections
    private void OnSectionChange(int value = 0)
    {
        //declare int to store section values
        int _oldSection = _currentShopSectionPage;
        int _newSection = _currentShopSectionPage + value;

        //if shop section does exist
        if(_newSection >= shopSections.Length || _newSection < 0) return;
        //set is changing to true to prevent multiple time of pressing button
        _isChanging = true;

        //deactivate current shop page
        StartCoroutine(ShopDisplayExecute(1,shopPages[_currentShopPage]));
        

        #region setting up new section and shop page

        //storing new page from new shop section
        shopPages = shopSections[_newSection].pages;

        //set current shop page back to 0
        _currentShopPage = 0;
        
        //activate new shop section
        shopSections[_newSection].gameObject.SetActive(true);
        
        //activate first shop page
        OnPageChange(0);
        #endregion

        //store new section value
        _currentShopSectionPage = _newSection;

    }

    public void ChangePage(int value)
    {
        //if vending machine have not started or the machine is changing page or section then stop execute
        if(machineStarted == false || _isChanging == true) return;
        //change page
        OnPageChange(value);
    }

    public void ChangeSection(int value)
    {
        //set is changing to true to prevent multiple time of pressing button
        //if vending machine have not started or the machine is changing page or section then stop execute
        if(machineStarted == false || _isChanging == true) return;
        //change section
        OnSectionChange(value);
    }

    //function to display shop
    IEnumerator ShopDisplayExecute(float _speed = 1,GameObject _oldDisplay = null,GameObject _newDisplay = null)
    {
        //if old display does exist
        if(_oldDisplay != null)
        {
            //move old display back to hide position
            LeanTween.move(_oldDisplay,lean_ItemSectionHidePos,_speed);
            //wait for few sec
            yield return new WaitForSeconds(_speed + 0.2f);
            //deactivate old display
            _oldDisplay.SetActive(false);
        }

        //close curtain
        LeanTween.moveLocal(shopCurtain,new Vector3(shopCurtain.transform.localPosition.x,-0.2f,shopCurtain.transform.localPosition.z),_speed);
        
        //wait for few sec
        yield return new WaitForSeconds(_speed + 0.2f);
       
       //if new display does exist
        if(_newDisplay != null)
        {
            //activate new display
            _newDisplay.SetActive(true);
            //move new display to display position
            LeanTween.move(_newDisplay,lean_ItemSectionDisplayPos,_speed);
            //wait for few sec
            yield return new WaitForSeconds(_speed);
            //open curtain
            LeanTween.moveLocal(shopCurtain,new Vector3(shopCurtain.transform.localPosition.x,-1.2f,shopCurtain.transform.localPosition.z),_speed);
            //wait for few sec
            yield return new WaitForSeconds(_speed + 0.2f);
            //set is changing back to false
            _isChanging = false;
        }
        
    }


    //function to buy
    public void OnBuy()
    {
        //if machine have not started
        if(machineStarted == false) return;
        
        //if there aren't anything in shop section
        if(ObjToSpawn == null || GameManagerClass.instanceT.playerCreditCard_Class.moneyAmount < price) return;
        //spawning object
        Instantiate(ObjToSpawn,posToSpawnObject.position,Quaternion.identity);
        //decrease amount of money
        GameManagerClass.instanceT.playerCreditCard_Class.moneyAmount -= price;
        //display text
        moneyDisplayText.text = GameManagerClass.instanceT.playerCreditCard_Class.moneyAmount.ToString();
    }

    public void OnExit()
    {
        //display text
        moneyDisplayText.text = "BALANCE: 0";
    }

    public void OnCardInsert()
    {
        //start machine
        machineStarted = true;
        //display amount of money
        moneyDisplayText.text = "BALANCE: " + GameManagerClass.instanceT.playerCreditCard_Class.moneyAmount.ToString();
        //display first page of shop
        _currentShopPage = 0;
        //execute
        OnPageChange(0);
        
    }
}
