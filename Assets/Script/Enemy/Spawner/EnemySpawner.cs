using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: enemy spawner
 * Content: spawn enemy
 **************************************/
[RequireComponent(typeof(AudioSource))]
public class EnemySpawner : MonoBehaviour
{

    public string [] enemies; // enemy pattern to spawn
    public EnemySpawnPatternScriptable[] enemeyPatternHolder; // pattern
    [Range(0,8)]public float spawnDelay; // spawn delay
    public int maxEnemy;//declare float for max enemy
    public AudioClip spawnSoundEffect; // declare audio clip for spawning sound effect

    //ENEMY INFO
    private int _currentPatternHolder;//store current pattern holder
    private int CurrentPatternHolder
    {
        get{return _currentPatternHolder;}
        set
        {
            if(_currentPatternHolder >= enemeyPatternHolder.Length - 1)
            {_currentPatternHolder = 0;}
            else
            {_currentPatternHolder = value;}
        }
    }
    private int _amountOfSpawnedEnemy; // amount of enemy spawned
    private int _waveEnemyAmount; // tracker for maximum nemey
    private int _enemyID = 0; //current enemy in array
    //WAVE INFO
    private int _wavePassedEvent; // passed wave for event
    private int _waveTracker = 0;// track wave
    private Coroutine _spawnerCou; // store ienumerator
    private AudioSource _audioSrc; // storing audio source
    
    private void Start() 
    {
        //storing audio source into this class
        _audioSrc = this.gameObject.GetComponent<AudioSource>();
        //if max enemy have not been set 
        //then set 200 as default
        if(maxEnemy == 0){maxEnemy = 200;}
        _currentPatternHolder = 0;
        //choose first pattern
        enemies = enemeyPatternHolder[_currentPatternHolder].pattern1;
        //Debug.Log(enemies.Length);
        _waveEnemyAmount = 6;
    }


    //function for re enabling spawner
    public void OnReEnable() 
    {
        //increase wave 
        _waveTracker++;
        GameManagerClass.instanceT.currentWaveText.text = "WAVE: " + _waveTracker;
        //increase max enemy
        _waveEnemyAmount += 4;
        //checking if max enemy reach to limit amount
        if(_waveEnemyAmount >= maxEnemy){_waveEnemyAmount = maxEnemy;}
        //set spawned enemy back to 0
        _amountOfSpawnedEnemy = 0;
        //reset enemy ID
        _enemyID = 0;
        //set total amount of enemy in wave manager
        GameManagerClass.instanceT.waveMode.amountOfEnemyTotal = _waveEnemyAmount;
        //decrease spawner time
        spawnDelay -= 0.1f;
        //if spawn delay is less or equal to 1 then set 1 as maximum
        if(spawnDelay <= 1){spawnDelay = 1;}
        
        //Debug.Log("NEW WAVE: " + _waveTracker);
        //starting spawner
        _spawnerCou = StartCoroutine(SpawnerIE());

        //Debug.Log("SPAWNED ENEMY: " + _amountOfSpawnedEnemy + " ENEMYID: " + _enemyID);
    }


    //spawner function
    IEnumerator SpawnerIE()
    {
        Debug.Log("Wave: " + _waveTracker + " AMOUNT: " + _amountOfSpawnedEnemy + " ENEMYAMOUNT: " + _waveEnemyAmount);
        //while amount of spaned enemy not reach to maximum
        while(_amountOfSpawnedEnemy < _waveEnemyAmount)
        {
            //if enemy ID exceed enemy array length
            if(_enemyID >= enemies.Length - 1 || _enemyID == -1){_enemyID = 0;}
            
            //store chosen enemy to spawn
            EnemyBase _enemy = ZombieSpawn(enemies[_enemyID]);
            //random x
            float randX = Random.Range(-5,5);
            //setting enemy position
            _enemy.transform.position = new Vector3(this.transform.position.x + randX,_enemy.transform.position.y,this.transform.position.z);
            //set position
            //_enemy.gameObject.transform.position = this.transform.localPosition;
            _enemy.gameObject.SetActive(true);
            //call revive function
            _enemy.OnRevive();
            //play sapwn effect
            PoolManager.instanceT.spawnEffect[PoolManager.instanceT.SpawnEffectID].transform.position = _enemy.transform.position;
            PoolManager.instanceT.spawnEffect[PoolManager.instanceT.SpawnEffectID].gameObject.SetActive(true);
            PoolManager.instanceT.spawnEffect[PoolManager.instanceT.SpawnEffectID].Play();
            PoolManager.instanceT.SpawnEffectID++;
            //increase enemy ID
            _enemyID++;
            //increase amount of enemy spawned
            _amountOfSpawnedEnemy++;
            //play spawn sound effect
            _audioSrc.PlayOneShot(spawnSoundEffect,1);

            //Debug.Log("Enemy id: " + _enemyID + " spawned: " + _amountOfSpawnedEnemy + " waveAmount: " + _waveEnemyAmount);
            yield return new WaitForSeconds(spawnDelay);
            
        }

        //increase wavepassed and wave tracker
        _wavePassedEvent++;
    
        //checking how many wave passed
        //to change enemy pattern
        switch(_wavePassedEvent)
        {
            case 2:
            //randomize pattern from pattern holder
            enemies = enemeyPatternHolder[CurrentPatternHolder].RandommizedPattern();
            break;

            case 8:
            //increase pattern holder to change whole new pattern holder
            CurrentPatternHolder++;
            //set new pattern holder
            enemies = enemeyPatternHolder[CurrentPatternHolder].pattern1;
            //set wave passed back to 0
            _wavePassedEvent = 0;
            break;
            
        }

        StopCoroutine(_spawnerCou);
        //disable spawner
        //StopCoroutine(_spawner);
    }

    private EnemyBase ZombieSpawn(string _zombieType)
    {
        //declare enemy base to store chosen zombie to be spawn
        EnemyBase chosenZombie = null;

        switch(_zombieType)
        {
            //common
            case "C":
            chosenZombie = GameManagerClass.instanceT.common_C[GameManagerClass.instanceT.Common_C_ID];
            //increase common id
            GameManagerClass.instanceT.Common_C_ID++;
            break;

            //runner
            case "R":
            chosenZombie = GameManagerClass.instanceT.runner_R[GameManagerClass.instanceT.Runner_R_ID];
            GameManagerClass.instanceT.Runner_R_ID++;
            break;

            //tanker
            case "T":
            chosenZombie = GameManagerClass.instanceT.tanker_T[GameManagerClass.instanceT.Tanker_T_ID];
            GameManagerClass.instanceT.Tanker_T_ID++;
            break;

            //squirter
            case "S":
            chosenZombie = GameManagerClass.instanceT.squirter_S[GameManagerClass.instanceT.Squirter_S_ID];
            GameManagerClass.instanceT.Squirter_S_ID++;
            break;
        }

        return chosenZombie;
    }

}
