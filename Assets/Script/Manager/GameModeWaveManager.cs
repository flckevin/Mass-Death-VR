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
    public ParticleSystem fireworks; // fire works on finished wave
    public AudioClip fireWorksClip; // fire works audio clip
    public AudioClip onStartWave; // audio clip on start wave
    public AudioClip onDestroyedExtractor; // audio clip on destroy extractor
   
    private AudioSource _audioSrc;// audio source
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
        //call spawn couroutine
        StartCoroutine(SpawnAfter());
        //call on start wave audio
        AudioManager.instanceT.PlayOneShot(onStartWave,1);
    }



    public void ZombieOnKill()
    {
        //decrease amount of total enemy
        amountOfEnemyTotal--;
        //if there arent any enemy left
        if(amountOfEnemyTotal <= 0)
        {
            //increase current wave
            _currentWave++;
            //display current wave
            GameManagerClass.instanceT.currentWaveText.text = "Current wave: " + _currentWave;
            //reset total amount of enemy
            amountOfEnemyTotal = 0;
            //call on finished wave enevt
            OnFinishedWave();
        }
    }

    public void OnFinishedWave()
    {
        //move barrier down
        LeanTween.moveY(barricadeDoor,-0.2f,5);
        //activate fire works
        fireworks.gameObject.SetActive(true);
        //play fireworks effect
        fireworks.Play();
        //play fireworks audio
        _audioSrc.PlayOneShot(fireWorksClip,1);
        
    }

    IEnumerator SpawnAfter()
    {
        //wait for few second
        yield return new WaitForSeconds(5.5f);
        //set activated back to false so player can spawn zombie
        _activated = false;
        //re-enable zombie
        GameManagerClass.instanceT.enemySpawner.OnReEnable();
    }

    public void Extract()
    {
        //player extracting so player wont be able to spawn anymore
        ableToSpawn = false;
        //get gamemamanger class
        GameManagerClass _GM = GameManagerClass.instanceT;
        //activate helicopter
        _GM.helicopterBehaviour.gameObject.SetActive(true);
        //set helicopter target
        _GM.helicopterBehaviour.Move(_GM.helicopterBehaviour.pos[0],_GM.helicopterBehaviour.pos[1],_GM.helicopterBehaviour.pos[2],90,null,2);
        //set helicopter start posiitoin
        _GM.helicopterBehaviour.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x,90,this.transform.eulerAngles.z);
        //set call type
        _GM.helicopterBehaviour.callType = "Extract";
        
    }

    

    
}
