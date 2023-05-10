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
    public PlayerBehaviour playerBehaviour_G;
    public bool playerIsDead_B = false;
    public CreditCard playerCreditCard_Class;
    public Grabber[] grab;
    public UpgradeGunBehaviour upgradeGun;

    [Space(10)]
    [Header("PlayerUI_INFO")]
    public Text healthText;
    public Text currentWaveText;

    [Space(10)]
    [Header("Objective_INFO")]
    public GameObject[] objective;
    public int objectiveID = 0;
    public int ObjectiveID
    {
        get
        {
            return objectiveID;
        }
        set
        {
            if(objectiveID >= objective.Length)
            {
                objectiveID = 0;
            }
            else
            {
                objectiveID = value;
            }
        }
    }
    public int generatorLeft;


    [Space(10)]
    [Header("Objective_Tablet_UI")]
    public UnityEngine.UI.Slider extractorHealth_UI;
    public Text extractTimeLeft_UI;
    public Text generatorLeft_UI;

    [Space(10)]
    [Header("GAMEMODE")]
    public GameModeWaveManager waveMode;

    [Space(10)]
    [Header("Spawner_INFO")]
    public EnemySpawner enemySpawner;
    public Transform[] spawnPos;
    public EnemyBase[] common_C;
    [HideInInspector]public int common_C_ID;
    public int Common_C_ID
    {
        get{return common_C_ID;}

        set
        {
            if(common_C_ID >= common_C.Length-1)
            {
                common_C_ID = 0;
            }
            else
            {
                common_C_ID = value;
            }
        }

    }
    public EnemyBase[] tanker_T;
    [HideInInspector]public int tanker_T_ID;
    public int Tanker_T_ID
    {
        get{return tanker_T_ID;}

        set
        {
            if(tanker_T_ID >= tanker_T.Length-1)
            {
                tanker_T_ID = 0;
            }
            else
            {
                tanker_T_ID = value;
            }
        }

    }
    public EnemyBase[] squirter_S;
    [HideInInspector]public int squirter_S_ID;
    public int Squirter_S_ID
    {
        get{return squirter_S_ID;}

        set
        {
            if(squirter_S_ID >= squirter_S.Length-1)
            {
                squirter_S_ID = 0;
            }
            else
            {
                squirter_S_ID = value;
            }
        }

    }
    public EnemyBase[] runner_R;
    public int runner_R_ID;
    public int Runner_R_ID
    {
        get{return runner_R_ID;}

        set
        {
            if(runner_R_ID >= runner_R.Length-1)
            {
                runner_R_ID = 0;
            }
            else
            {
                runner_R_ID = value;
            }
        }

    }

    
}
