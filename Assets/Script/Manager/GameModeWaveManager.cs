using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/***************************************
 * Authour: HAN 18080038
 * Object hold: game mode manager
 * Content: wave game mode manager
 **************************************/
 [RequireComponent(typeof(AudioSource))]
public class GameModeWaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject barricadeDoor; // gameobject for huge door to start wave
    [HideInInspector]public int amountOfEnemyTotal; // total amount of kills
    public ParticleSystem fireworks;
    public AudioClip fireWorksClip;
    public AudioClip onFinishedWave;
    public AudioClip onStartWave;
    public AudioClip onDestroyedExtractor;
   
    private AudioSource _audioSrc;
    private int _currentWave; // current wave
    private bool _activated; // make sure that there won't be a duplication
    private bool ableToSpawn = true; // able to spawn
    
    private void Start() 
    {
        //storing audio source
        _audioSrc = this.gameObject.GetComponent<AudioSource>();
    }
    
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
        AudioManager.instanceT.PlayOneShot(onStartWave,1);
    }

    public void ZombieOnKill()
    {
        amountOfEnemyTotal--;
        if(amountOfEnemyTotal <= 0)
        {
            _currentWave++;
            GameManagerClass.instanceT.currentWaveText.text = "Current wave: " + _currentWave;
            amountOfEnemyTotal = 0;
            OnFinishedWave();
        }
    }

    public void OnFinishedWave()
    {
        LeanTween.moveY(barricadeDoor,-0.2f,5);
        fireworks.gameObject.SetActive(true);
        fireworks.Play();
        _audioSrc.PlayOneShot(fireWorksClip,1);
        AudioManager.instanceT.PlayOneShot(onFinishedWave,1);
    }

    IEnumerator SpawnAfter()
    {
        yield return new WaitForSeconds(5.5f);
        _activated = false;
        GameManagerClass.instanceT.enemySpawner.OnReEnable();
    }

    public void Extract()
    {
        ableToSpawn = false;
        GameManagerClass _GM = GameManagerClass.instanceT;
        _GM.helicopterBehaviour.gameObject.SetActive(true);
        _GM.helicopterBehaviour.Move(_GM.helicopterBehaviour.pos[0],_GM.helicopterBehaviour.pos[1],_GM.helicopterBehaviour.pos[2],-90,2);
        _GM.helicopterBehaviour.callType = "Extract";
        
    }

    

    
}
