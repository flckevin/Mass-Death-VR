using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
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
    public bool playerIsDead = false;
   
}
