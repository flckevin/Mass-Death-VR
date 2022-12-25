using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: player
 * Content: player behaviours
 **************************************/
public class PlayerBehaviour : MonoBehaviour,IDamageable
{
    private PlayerStats _playerStats;//decl
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// function player receive damage
    /// </summary>
    /// <param name="damage"> damage value </param>
    public void OnDamage(float damage) 
    {
        //decrease player's health
        _playerStats.health -= damage;
        //checking whether player's health reach to 0
        if(_playerStats.health <= 0) 
        { 
            //player dies
        }
    }


    /// <summary>
    /// function to receive more health
    /// </summary>
    /// <param name="amount"> amount to add into health </param>
    public void OnReciveHealth(float amount) 
    {
        //adding more health to the player
        _playerStats.health += amount;
        //checking whether player health exceed the limit
        if(_playerStats.health > 100) 
        {
            //if it does
            //set to maximum which is 100
            _playerStats.health = 100;
        }
    }

    void IDamageable.Damage(float amount, RaycastHit effect, bool deactivateObjectInstant)
    {
        
    }

    void IDamageable.Damage(float amount, bool instantDeactivate)
    {
        OnDamage(amount);
    }
}
