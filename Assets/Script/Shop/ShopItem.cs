using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/***************************************
 * Authour: HAN 18080038
 * Object hold: every item in shop
 * Content: item content in shop
 **************************************/
public class ShopItem : MonoBehaviour
{
    public Image shopItemImg;
    public string shopItemName;

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
