using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BNG;
/***************************************
 * Authour: HAN 18080038
 * Object hold: vending machine (shop)
 * Content: shop behaviour
 **************************************/
public class ShopBehaviour : MonoBehaviour
{
    [Header("Vending machine info")]
    public ShopItemBehaviour[] items_Shop;//declare array of shop item for every behaviour of item in shops
    public Transform posToSpawnItem;//declare transform for postiion to spawn
    public Transform creditCardPos;//declare transform for credit card postiion
    public VRCanvas vrCanvas;//declare vr canvas to enable and disable it

    [Header("Vending machine UI Info")]
    public Text itemName_Text;//declare text to change name of item that display on vending machine
    public Image shopItemImage_UI;//declare image to change image that display on vending machine
    public GameObject shopBanner;//declare gameobject for shop banner


    private int _currentItemId = 0;//declare int to store current id
   

    // Start is called before the first frame update
    void Start()
    {
        //set item shop to be gun shop at first
        items_Shop = ShopItemManager.shopInstance.gun_Shop;
        //change default shop type to gun on start
        ChangeItemType("Guns");
        
    }


    /// <summary>
    /// Funciton to change shop
    /// </summary>
    /// <param name="itemType"> Item type </param>
    public void ChangeItemType(string itemType) 
    {
        
        switch (itemType) 
        {
            //if it guns
            case "Guns":
                //change shop to gun
                items_Shop = ShopItemManager.shopInstance.gun_Shop;
                break;
            //if it consumable
            case "Consumables":
                //change shop to consumable
                items_Shop = ShopItemManager.shopInstance.consumable_Shop;
                break;
            //if it emplacement weapons
            case "EmplacementWeapons":
                //change to emplacement weapon shop
                items_Shop = ShopItemManager.shopInstance.emplacementWeapons_Shop;
                break;
        }
        //change to first item of the shop to update
        //to the player that they have moved to a new item shop
        _currentItemId = 0;
        //change shop item
        ChangeItem();
    }


    /// <summary>
    /// function to change to next item
    /// </summary>
    public void ChangeNextItem() 
    {
        //if increased current iteam id not exceed limit of item shop array
        if(_currentItemId + 1 < items_Shop.Length) 
        {
            //increase item id
            _currentItemId++;
        }
        else //if it exceed limitation of item in shop array
        {
            //set currentitem id to 0
            _currentItemId = 0;
        }
        //change shop item 
        ChangeItem();

    }


    /// <summary>
    /// function to change to previous item
    /// </summary>
    public void ChangePreviousItem() 
    { 
        //if decreased item id does not equal to 0
        if(_currentItemId - 1 != 0) 
        {
            //set current item id to be 0
            _currentItemId = 0;
        }
        //change item
        ChangeItem();

    }


    /// <summary>
    /// function to change items in shop
    /// </summary>
    /// <param name="itemID"> item id in array </param>
    public void ChangeItem() 
    {
        //chanmge shop item name for display
        itemName_Text.text = items_Shop[_currentItemId].name;
        //change shop item image for display
        shopItemImage_UI.sprite = items_Shop[_currentItemId].shopItemImg;

    }


    /// <summary>
    /// function to buy item
    /// </summary>
    public void BuyItem() 
    { 
        //checking whether the id have exceed the array of item 
        if(items_Shop[_currentItemId].currentItemToSpawnID < items_Shop[_currentItemId].itemToSpawn.Length) 
        {
            //if it not
            //increase the ID
            items_Shop[_currentItemId].currentItemToSpawnID++;
        }
        else //if it exceed
        {
            //set item id back to 0
            items_Shop[_currentItemId].currentItemToSpawnID = 0;
        }
        
        if(GameManagerClass.gameManaInstance.playerCreditCard_Class.moneyAmont >= items_Shop[_currentItemId].price) 
        {
            //set position of item to spawn position to be at the spawn position
            items_Shop[_currentItemId].itemToSpawn[_currentItemId].gameObject.transform.position = posToSpawnItem.position;
            //activate the bought item
            items_Shop[_currentItemId].itemToSpawn[_currentItemId].gameObject.SetActive(true);
        }
        else 
        {
            //play not enough money sound
            ExitBuy();
        }
       
    }


    /// <summary>
    /// function to exit vending machine
    /// </summary>
    public void ExitBuy() 
    {
        //activate banner
        shopBanner.SetActive(true);
        //release card
        GameManagerClass.gameManaInstance.playerCreditCard_Class.gameObject.SetActive(true);
        //disable vr canvas
        vrCanvas.enabled = false;
    }


    private void OnTriggerEnter(Collider card)
    {
        //checking whether gameobject has tag "credit card"
        if (card.CompareTag("CreditCard")) 
        {
            
            //set credit card at correct postion
            GameManagerClass.gameManaInstance.playerCreditCard_Class.gameObject.transform.position = creditCardPos.position;
            shopBanner.SetActive(false);
            GameManagerClass.gameManaInstance.playerCreditCard_Class.gameObject.SetActive(false);
        }
    }


    
}
