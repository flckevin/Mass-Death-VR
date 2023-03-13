using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: credit card in game
 * Content: hold amount of money for the player
 **************************************/

public class CreditCard : MonoBehaviour
{
    public int moneyAmount;//declare int to store amount of money
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Shop")
        {
            ShopBehaviour shop = other.transform.root.GetComponent<ShopBehaviour>();
            shop.OnCardInsert();
            this.gameObject.SetActive(false);
            
        }
    }


    
}
