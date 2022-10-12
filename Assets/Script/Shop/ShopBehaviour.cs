using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/***************************************
 * Authour: HAN 18080038
 * Object hold: vending machine (shop)
 * Content: shop behaviour
 **************************************/
public class ShopBehaviour : MonoBehaviour
{
    
    public GameObject[] items_Gameobject;
    public Transform weaponPos_Transform;
    public Text weaponName_Text;
    // Start is called before the first frame update
    void Start()
    {
        items_Gameobject = PoolManager.poolInstance.gun_Shop;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeItem(string itemType) 
    {
        switch (itemType) 
        {
            case "Guns":
                items_Gameobject = PoolManager.poolInstance.gun_Shop;
                break;
            case "Consumable":
                items_Gameobject = PoolManager.poolInstance.consumable_Shop;
                break;
            case "EmplacementWeapons":
                items_Gameobject = PoolManager.poolInstance.emplacementWeapons_Shop;
                break;
        }
    }

    public void ChangeItem() 
    {
        items_Gameobject[items_Gameobject.Length].gameObject.transform.position = weaponPos_Transform.position;
        weaponName_Text.text = items_Gameobject[items_Gameobject.Length].name;
        //scale down
        //enable rotate script
    }

    public void BuyItem() 
    { 
    
    }
}
