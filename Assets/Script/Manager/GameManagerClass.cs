using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorePattern;
using BNG;
/***************************************
 * Authour: HAN 18080038
 * Object hold: GameManager
 * Content: hold the varible that use alot in game
 **************************************/
public class GameManagerClass : Singleton<GameManagerClass>
{
   
    [Header("Player_Info")]
    public GameObject player_G;
    public bool playerIsDead_B = false;
    public CreditCard playerCreditCard_Class;
    public PlayerStats playerStat;
    public Grabber leftGrab;
    public Grabber rightGrab;
}
