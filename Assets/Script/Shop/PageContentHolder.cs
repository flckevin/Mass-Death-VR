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
    [Tooltip("button and obj amount need to be the same")]public GameObject[] objToSpawn;//object to spawn
    
    [Tooltip("price array value need to be the same as item value pos in array")] public int[] price;//price of object
    [Tooltip("Image array value need to be the same as item value pos in array")]public Sprite[] itemImg; // image of each item in shop

    private ShopBehaviour _shop;//shop behaviour class

    // Start is called before the first frame update
    void Start()
    {
        //getcomponbent of shop
        _shop = gameObject.transform.root.GetComponent<ShopBehaviour>();
        //if button length or object to spawn length not equal to each other then return
        if(buttons.Length != objToSpawn.Length || objToSpawn.Length != buttons.Length) return;

        //loop every buttons and object in array
        for(int i = 0; i < objToSpawn.Length ;i++)
        {
            //declare int to store i loop value
            int x = i;
            //add listener to that button in array
            buttons[i].onButtonDown.AddListener(() => AssignItem(x));
            
        }
    }

    //function to assign item
    void AssignItem(int value)
    {
        //assign item name to display
        _shop.nameText.text = "NAME: " + objToSpawn[value].name;
        //assign object to spawn
        _shop.ObjToSpawn = objToSpawn[value];
        //assign price of the object
        _shop.price = price[value];
        _shop.priceText.text = "PRICE: " + price[value].ToString() + "$";
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
