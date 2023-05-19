using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    public GameObject ragdoll; // player ragdoll
    public float poison;
    private float _Poison
    {
        get{return poison;}
        set{
            if(poison >= 5){poison = 5;}
            else if(poison <= 0){poison = 0;}
        }
    }
    public BNG.SmoothLocomotion playerVRController;
    [Header("Player Stats UI Info")]
    

    private float _maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        _maxHealth = health;
        playerVRController.MovementSpeed = speed;
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
            //if ragdoll does exist
            if(ragdoll != null)
            {
                //activate it
                ragdoll.SetActive(true);
            }
            //disable controller
            GameManagerClass.instanceT.playerController.enabled = false;
            //set time to slow motion
            Time.timeScale = 0.3f;
            //call back to safehouse function
            StartCoroutine(BackToSafeHouse());
        }
        
    }

    //back to safe house
    IEnumerator BackToSafeHouse()
    {
        //wait for few seconds
        yield return new WaitForSeconds(2f);
        Time.timeScale = 1;
        //load back to safe house
        SceneManager.LoadScene("PlayerHub");
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
