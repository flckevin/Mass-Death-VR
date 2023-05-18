using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/***************************************
 * Authour: HAN 18080038
 * Object hold: game mode manager
 * Content: wave game mode manager
 **************************************/
public class GameModeWaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject barricadeDoor; // gameobject for huge door to start wave
    [HideInInspector]public int amountOfEnemyTotal; // total amount of kills
    private int _currentWave; // current wave
    private bool _activated; // make sure that there won't be a duplication
    private bool ableToSpawn = true; // able to spawn
    public void OnStartWave()
    {
        //if able to spawn
        if(ableToSpawn == false) return;
        //check barricade whether exist
        if(barricadeDoor == null || _activated == true)return;
        //set activated to true incase duplication
        _activated = true;
        //move barricade door
        LeanTween.moveY(barricadeDoor,12,5);
        StartCoroutine(SpawnAfter());

    }

    public void OnsetDefault()
    {
        LeanTween.moveY(barricadeDoor,-0.2f,5);
    }

    IEnumerator SpawnAfter()
    {
        yield return new WaitForSeconds(5.5f);
        _activated = false;
        GameManagerClass.instanceT.enemySpawner.OnReEnable();
    }

    public void ZombieOnKill()
    {
        amountOfEnemyTotal--;
        if(amountOfEnemyTotal <= 0)
        {
            _currentWave++;
            GameManagerClass.instanceT.currentWaveText.text = "Current wave: " + _currentWave;
            amountOfEnemyTotal = 0;
            OnsetDefault();
        }
    }


    public void Extract()
    {
        ableToSpawn = false;
        GameManagerClass _GM = GameManagerClass.instanceT;
        _GM.helicopterBehaviour.gameObject.SetActive(true);
        _GM.helicopterBehaviour.Move(_GM.helicopterBehaviour.pos[0],_GM.helicopterBehaviour.pos[1],_GM.helicopterBehaviour.pos[2],-90,2);
        _GM.helicopterBehaviour.callType = "Extract";
        StartCoroutine(loadBackToSafeHouse());
    }

    IEnumerator loadBackToSafeHouse()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("PlayerHub");
    }

    
}
