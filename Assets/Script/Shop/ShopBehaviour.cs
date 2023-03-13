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
    public Image img;//image of the item
    public Text priceText;//text to display price
    public Text moneyDisplayText;//text to display current money

    [HideInInspector]public bool machineStarted;
    [HideInInspector]public GameObject ObjToSpawn;//object ot spawn
    [HideInInspector] public int price;//price of item

    public bool _isChanging = false;


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
        int oldPage = _currentShopPage;
        int newPage = _currentShopPage + value;

        Debug.Log(newPage + " || " + shopPages.Length);
        //if next shop page does not exist , then return
        //if(_currentShopPage + value > shopPages.Length && _currentShopPage + value == -1)

        if(newPage >= shopPages.Length || newPage <= 0) return;
        //set is changing to true to prevent multiple time of pressing button
        _isChanging = true;

        //use leantween to move curtain up to close
        MoveCurtain(false,1);
        //move shop page back to start position
        LeanTween.move(shopPages[oldPage],lean_ItemSectionHidePos,2);
        //deactivate old shop page
        shopPages[oldPage].SetActive(false);
        //activate new shop page
        shopPages[newPage].SetActive(true);
        //move new shop page to new
        LeanTween.move(shopPages[newPage],lean_ItemSectionDisplayPos,2);
        //use leantween to move curtain down to open
        MoveCurtain(true,1);
        
        //store current page
        _currentShopPage = newPage;
        Debug.Log("CHANGE TO PAGE: " + _currentShopPage);
    }


    //function to change shop sections
    private void OnSectionChange(int value = 0)
    {

        //if shop section does exist
        if(shopSections[_currentShopSectionPage + value] == null) return;


        #region Deactivate current shop page and shop section
        //lean shop page back to start
        LeanTween.move(shopPages[_currentShopPage],lean_ItemSectionHidePos,1);
        //curtain close up to close
        MoveCurtain(false,1);
        //deactivate current shop page
        shopPages[_currentShopPage].SetActive(false);
        //deactivate current shop section
        shopSections[_currentShopSectionPage].gameObject.SetActive(false);

        #endregion

        #region setting up new section and shop page

        //storing new page from new shop section
        shopPages = shopSections[_currentShopSectionPage + value].pages;
        //set current shop page back to 0
        _currentShopPage = 0;

        //activate new shop section
        shopSections[_currentShopSectionPage + value].gameObject.SetActive(true);
        
        //activate new shop page
        shopPages[_currentShopPage].SetActive(true);

        //curtain down to open
        MoveCurtain(true,1);

        //move shop page to vending machine position
        LeanTween.move(shopPages[_currentShopPage],lean_ItemSectionDisplayPos,1);
        
        #endregion


    }

    public void ChangePage(int value)
    {
        //if the machine is changing page or section then stop execute
        if(_isChanging == true) return;
        
        //if vending machine have not started
        if(machineStarted == false) return;
        //change page
        OnPageChange(value);
    }

    public void ChangeSection(int value)
    {
        //if the machine is changing page or section then stop execute
        if(_isChanging == true) return;
        //set is changing to true to prevent multiple time of pressing button
        //if vending machine have not started
        if(machineStarted == false) return;
        //change section
        OnSectionChange(value);
    }

    //fcuntion to move curtain
    private void MoveCurtain(bool open,int speed)
    {
        //if machine have not started
        if(machineStarted == false) return;
        //declare local y varible for curtain
        float value_y = 0;
        switch(open)
        {
            //if case is true
            case true:
            //open curtain
            value_y = -1.2f;
            StartCoroutine(WaitForCurtain(value_y));
            break;
            //case is false
            case false:
            //close curtain
            value_y = -0.2f;
            //move curtain to desired position
            LeanTween.moveLocal(shopCurtain,new Vector3(shopCurtain.transform.localPosition.x,value_y,shopCurtain.transform.localPosition.z),speed);
            break;
        }
        
        Debug.Log("MOVE CURTAIN");
    }

    //function to wait for curtain
    IEnumerator WaitForCurtain(float value_y, float speed = 1)
    {
        
        yield return new WaitForSeconds(2);
        //move curtain to desired position
        LeanTween.moveLocal(shopCurtain,new Vector3(shopCurtain.transform.localPosition.x,value_y,shopCurtain.transform.localPosition.z),speed);
        yield return new WaitForSeconds(1.5f);
        _isChanging = false;
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
        moneyDisplayText.text = "0";
    }

    public void OnCardInsert()
    {
        machineStarted = true;
        moneyDisplayText.text = GameManagerClass.instanceT.playerCreditCard_Class.moneyAmount.ToString();
        //activate new shop page
        shopPages[_currentShopPage].SetActive(true);
        //move new shop page to new
        LeanTween.move(shopPages[_currentShopPage],lean_ItemSectionDisplayPos,1);
        //use leantween to move curtain down to open
        MoveCurtain(true,1);
        
    }
}
