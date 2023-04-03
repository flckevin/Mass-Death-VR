using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: every item in shop
 * Content: item info 
 **************************************/
 [CreateAssetMenu(fileName = "ShopItem", menuName = "ScriptableObjects/ShopItem")]
public class ShopItemScriptable : ScriptableObject
{
    public GameObject objToSpawn;//object to spawn
    public int price;//price of object
    public string descriptions;//description of object
}
