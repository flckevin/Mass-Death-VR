using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/***************************************
 * Authour: HAN 18080038
 * Object hold: every item in shop
 * Content: item content in shop
 **************************************/
public class ShopItemBehaviour : MonoBehaviour
{
    public Sprite shopItemImg;//declare image for Item image to display on shop
    public string shopItemName;//declare string for item name
    public GameObject[] itemToSpawn;//declare array of gameobject pool
    public int currentItemToSpawnID;//declare int to store the current id that being assign to spawn item from array
    public int price;//declare int for price of the item
    private void Start()
    {
        //checking whether shop item name is empty
        if(shopItemName == string.Empty) 
        {
            //setting shop item name to be the same as the object holding the class
            shopItemName = this.gameObject.name;
        }
    }
}
