using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/***************************************
 * Authour: HAN 18080038
 * Object hold: player
 * Content: player behaviours
 **************************************/
public class PlayerBehaviour : MonoBehaviour,IDamageable
{
    [Header("Player General Info")]
    public float health; // player health
    public float speed; //player speed
    [Header("Player Stats UI Info")]
    

    private float _maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        _maxHealth = health;
    }

    /// <summary>
    /// function player receive damage
    /// </summary>
    /// <param name="damage"> damage value </param>
    public void OnDamage(float damage) 
    {
        //decrease player's health
        health -= damage;
        GameManagerClass.instanceT.healthText.text = "Health: " + health;
        //checking whether player's health reach to 0
        if(health <= 0) 
        { 
            //player dies
        }
        /*
        if(healthSlider == null) return;
        healthSlider.value = health/_maxHealth;
        */
        
        
    }


    /// <summary>
    /// function to receive more health
    /// </summary>
    /// <param name="amount"> amount to add into health </param>
    public void OnReciveHealth(float amount) 
    {
        //adding more health to the player
        health += amount;
        GameManagerClass.instanceT.healthText.text = "Health: " + health;
        //checking whether player health exceed the limit
        if(health > 100) 
        {
            //if it does
            //set to maximum which is 100
            health = 100;
        }

    }
    

    void IDamageable.Damage(float amount, bool instantDeactivate)
    {
        OnDamage(amount);
    }

  
}
