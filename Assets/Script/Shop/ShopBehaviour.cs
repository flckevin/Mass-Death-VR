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
    private int _currentShopPage;//shop current page

    public Transform posToSpawnObject;//position to spawn objects
    [Space(10)]

    [Header("SHOP COMPONENTS")]
    public GameObject shopCurtain;//shop curtain
    public Transform lean_CurtainPos;//shop curtain leantweenPos

    public Transform lean_ShopPos;//postion to lean 
    public Transform lean_StartShopPos;//position to lean
    [Space(10)]
    
    [Header("SHOP COMPONENTS_SHOP UI")]
    public Image img;//image of the item
    public Text priceText;//text to display price

    
    [HideInInspector]public GameObject ObjToSpawn;//object ot spawn
    [HideInInspector] public int price;//price of item



    //function to change shop pages
    public void OnPageChange(int value = 1)
    {
        //if next shop page does not exist - incase exceed page amount , then return
        if(shopPages[_currentShopPage + value] == null) return;
    
        //move shop page back to start position
        LeanTween.move(shopPages[_currentShopPage],lean_StartShopPos,1);

        //use leantween to move curtain up to close
        MoveCurtain(0,1);

        //deactivate old shop page
        shopPages[_currentShopPage].SetActive(false);
        //activate new shop page
        shopPages[_currentShopPage + value].SetActive(true);
        //use leantween to move curtain down to open
        MoveCurtain(0,-1);

        //move new shop page to new
        LeanTween.move(shopPages[_currentShopPage + 1],lean_ShopPos,1);
        
        //set new shop page
        _currentShopPage += value;
    }


    //function to change shop sections
    public void OnSectionChange(int value = 1)
    {
        //if shop section does exist
        if(shopSections[_currentShopSectionPage + value] == null) return;


        #region Deactivate current shop page and shop section

        //lean shop page back to start
        LeanTween.move(shopPages[_currentShopPage],lean_StartShopPos,1);
        //curtain close up to close
        MoveCurtain(0,1);
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
        MoveCurtain(0,-1);

        //move shop page to vending machine position
        LeanTween.move(shopPages[_currentShopPage + 1],lean_ShopPos,1);

        #endregion

        //increase current shop page
        _currentShopSectionPage += value;
    }

    //fcuntion to move curtain
    private void MoveCurtain(int value_y,int speed)
    {
        //move curtain to desired position
        LeanTween.move(shopCurtain,new Vector3(lean_CurtainPos.position.x,lean_CurtainPos.position.y + value_y,lean_CurtainPos.position.z),speed);
    }


    //function to buy
    public void OnBuy()
    {
        //if there aren't anything in shop section
        if(ObjToSpawn == null || GameManagerClass.instanceT.playerCreditCard_Class.moneyAmount < price) return;
        //spawning object
        Instantiate(ObjToSpawn,posToSpawnObject.position,Quaternion.identity);
        //decrease amount of money
        GameManagerClass.instanceT.playerCreditCard_Class.moneyAmount -= price;
    }
}
