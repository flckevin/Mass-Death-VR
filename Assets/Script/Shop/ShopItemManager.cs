using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class ShopItemManager : MonoBehaviour
{
    public static ShopItemManager shopInstance { get; private set; } // declare poolmanager to set for singleton

    private void Awake()
    {
        //setting singleton for pool
        shopInstance = this;
    }

    [Header("Shop Item Info")]
    public ShopItemBehaviour[] gun_Shop;
    public ShopItemBehaviour[] consumable_Shop;
    public ShopItemBehaviour[] emplacementWeapons_Shop;
}
