using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorePattern;
using BNG;
using UnityEngine.UI;
/***************************************
 * Authour: HAN 18080038
 * Object hold: GameManager
 * Content: hold the varible that use alot in game
 **************************************/
public class GameManagerClass : Singleton<GameManagerClass>
{
   
    [Header("Player_Info")]
    public PlayerBehaviour player_G;
    public bool playerIsDead_B = false;
    public CreditCard playerCreditCard_Class;
    public PlayerStats playerStat;
    public Grabber[] grab;


    [Header("Objective_INFO")]
    public GameObject[] objective;
    [Header("Objective_Tablet_UI")]
    public UnityEngine.UI.Slider extractorHealth;
    public Text extractTimeLeft;


    [Header("Spawner_INFO")]
    public Transform[] spawnPos;

    
}
