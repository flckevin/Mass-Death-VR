using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
/***************************************
 * Authour: HAN 18080038
 * Object hold: All shop pages 
 * Content: assigning pages content and on select behaviour of item selection
 **************************************/
public class PageContentHolder : MonoBehaviour
{
    public GameObject[] pages;//store pages
   
    [Tooltip("button and obj amount need to be the same")]public BNG.Button[] buttons;//buttons
    [Tooltip("button and obj amount need to be the same")]public ShopItemScriptable[] shopItems;//shop item
   

    private ShopBehaviour _shop;//shop behaviour class

    // Start is called before the first frame update
    void Start()
    {
        //getcomponbent of shop
        _shop = gameObject.transform.root.GetComponent<ShopBehaviour>();
        //if button length or object to spawn length not equal to each other then return
        if(buttons.Length != shopItems.Length || shopItems.Length != buttons.Length) return;

        //loop every buttons and object in array
        for(int i = 0; i < shopItems.Length ; i++)
        {
            //declare int to store i loop value
            int x = i;
            //add listener to that button in array
            buttons[x].onButtonDown.AddListener(() => AssignItem(x));
            
            
        }
    }

    //function to assign item
    void AssignItem(int value)
    {
        //assign item name to display
        _shop.nameText.text = "NAME: " + shopItems[value].objToSpawn.name.ToString();
        //assign object to spawn
        _shop.ObjToSpawn = shopItems[value].objToSpawn;
        //assign price of the object
        _shop.price = shopItems[value].price;
        //assign price
        _shop.priceText.text = "PRICE: " + shopItems[value].price.ToString() + "$";
        //assign description
        _shop.description.text = "DES: " + shopItems[value].descriptions.ToString();
        
        //assign object image to display
        /*
        if(_shop.img != null)
        {
            _shop.img.sprite = itemImg[value];
        }
        */
        //assign object price to display

    }

   
}
