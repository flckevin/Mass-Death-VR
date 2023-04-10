using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: enemy spawner
 * Content: spawn enemy
 **************************************/

public class EnemySpawner : MonoBehaviour
{

    public string [] enemies; // enemy pattern to spawn
    public EnemySpawnPatternScriptable[] enemeyPatternHolder; // pattern
    [Range(0,8)]public float spawnDelay; // spawn delay
    public int maxEnemy;//declare float for max enemy

    //ENEMY INFO
    private int _currentPatternHolder;//store current pattern holder
    private int _amountOfSpawnedEnemy; // amount of enemy spawned
    private int _maxEnemy; // tracker for maximum nemey
    private int _enemyID; //current enemy in array
    //WAVE INFO
    private int _wavePassedEvent; // passed wave for event
    private int _waveTracker;// track wave
    private IEnumerator _spawner; // store ienumerator


    private void Start() 
    {
        //if max enemy have not been set 
        //then set 200 as default
        if(maxEnemy == 0){maxEnemy = 200;}
        _currentPatternHolder = 0;
        //choose first pattern
        enemies = enemeyPatternHolder[_currentPatternHolder].pattern1;
        //storing ienumerator
        _spawner = Spawner();
        //starting spawner
        StartCoroutine(_spawner);
    }


    //function for re enabling spawner
    private void OnEnable() 
    {
        //increase max enemy
        _maxEnemy += 4;
        //checking if max enemy reach to limit amount
        if(_maxEnemy >= maxEnemy){_maxEnemy = maxEnemy;}
        //set spawned enemy back to 0
        _amountOfSpawnedEnemy = 0;
        //decrease spawner time
        spawnDelay -= 0.1f;
        //if spawn delay is less or equal to 1 then set 1 as maximum
        if(spawnDelay <= 1){spawnDelay = 1;}
        //starting spawner
        StartCoroutine(_spawner);
    }


    //spawner function
    IEnumerator Spawner()
    {
        //while amount of spaned enemy not reach to maximum
        while(_amountOfSpawnedEnemy != _maxEnemy)
        {
            //if enemy ID exceed enemy array length
            if(_enemyID >= enemies.Length - 1){_enemyID = 0;}
            //store chosen enemy to spawn
            EnemyBase _enemy = ZombieSpawn(enemies[_enemyID]);
            //set position
            _enemy.gameObject.transform.position = this.transform.position;
            //call revive function
            _enemy.OnRevive();
            
            //increase enemy ID
            _enemyID++;
            //increase amount of enemy spawned
            _amountOfSpawnedEnemy++;
            yield return new WaitForSeconds(spawnDelay);
        }
        
        //increase wavepassed and wave tracker
        _wavePassedEvent++;
        _waveTracker++;

        //checking how many wave passed
        //to change enemy pattern
        switch(_wavePassedEvent)
        {
            case 2:
            //randomize pattern from pattern holder
            enemies = enemeyPatternHolder[_currentPatternHolder].RandommizedPattern();
            break;

            case 8:
            //increase pattern holder to change whole new pattern holder
            _currentPatternHolder++;
            //set new pattern holder
            enemies = enemeyPatternHolder[_currentPatternHolder].pattern1;
            //set wave passed back to 0
            _wavePassedEvent = 0;
            break;
            
        }

        //disable spawner
        this.enabled = false;
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
            break;

            //runner
            case "R":
            chosenZombie = GameManagerClass.instanceT.runner_R[GameManagerClass.instanceT.Runner_R_ID];
            break;

            //tanker
            case "T":
            chosenZombie = GameManagerClass.instanceT.tanker_T[GameManagerClass.instanceT.Tanker_T_ID];
            break;

            //squirter
            case "S":
            chosenZombie = GameManagerClass.instanceT.squirter_S[GameManagerClass.instanceT.Squirter_S_ID];
            break;
        }

        return chosenZombie;
    }

}
