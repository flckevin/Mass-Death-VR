using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: GameManager
 * Content: hold the varible that use alot in game
 **************************************/
public class GameManagerClass : MonoBehaviour
{
    //setting singleton for game manager
    public static GameManagerClass gameManaInstance { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        //set gamemanager instance
        gameManaInstance = this;
    }

    [Header("Player_Info")]
    public GameObject player_G;
    public bool playerIsDead_B = false;
    public CreditCard playerCreditCard_Class;
}
