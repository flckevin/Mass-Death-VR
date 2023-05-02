using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: game mode manager
 * Content: wave game mode manager
 **************************************/
public class GameModeWaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject barricadeDoor;
    [HideInInspector]public int amountOfEnemyTotal;
    private int _currentWave;
    private bool _activated;
    public void OnStartWave()
    {
        if(barricadeDoor == null || _activated == true)return;
        _activated = true;
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

    
}
