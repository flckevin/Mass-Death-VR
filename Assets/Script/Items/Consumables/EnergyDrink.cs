using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
 [RequireComponent(typeof(AudioSource))]
public class EnergyDrink : MonoBehaviour
{
    public float speedToIncrease; // speed to increase
    public float _drinkLeft; // amount of drink left
    public float delay; // delay amount between speed decrease
    public GameObject cap; // drink cap
    public MeshRenderer drinkMesh; // drink mesh
    public BoxCollider drinkCol; // drink collision
    public AudioClip _drinkClip;
    public AudioClip sodaOpenSound;

    private bool _opened; // identify whether player opened the drink
    private bool _startedCou; // identify whether couroutine started
    private AudioSource _audioSrc; //audio source
    

    private void Start() 
    {
        //storing audio source into this class
        _audioSrc = this.gameObject.GetComponent<AudioSource>();    
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("MainCamera"))
        {
           
           if(_opened == false) return;
           if(_audioSrc != null && !_audioSrc.isPlaying) _audioSrc.PlayOneShot(_drinkClip,1);
            OnDrink();
        }
        CheckLiquid();
    }

    private void OnTriggerStay(Collider other) 
    {
        if(other.CompareTag("MainCamera"))
        {
           if(_opened == false) return;
           if(_audioSrc != null && !_audioSrc.isPlaying) _audioSrc.PlayOneShot(_drinkClip,1);
            OnDrink();

        }
    }
    
    private void OnTriggerExit(Collider other) 
    {
        CheckLiquid();
    }


    public void OnDrink()
    {
        
        //if movement speed is less than 5
        if(GameManagerClass.instanceT.playerVRController.MovementSpeed <= 5)
        {
            //increase movement speed
            GameManagerClass.instanceT.playerVRController.MovementSpeed += (speedToIncrease*Time.deltaTime);
        }
        // decrease drink left
        _drinkLeft -=1 *Time.deltaTime;
        if(_startedCou == true) return;
        StartCoroutine(SpeedDecrease());
    }

    //function to open bottle
    public void Open(bool _enable)
    {
        if(_opened == true) return;
        //set open boolian
        _opened = _enable;
        //deactivate cap
        cap.SetActive(false);
        _audioSrc.PlayOneShot(sodaOpenSound,1);
    }

    //function to check liquid left
    private void CheckLiquid()
    {
        if(_drinkLeft > 0) return;
        //if there is non
        if( _startedCou == false)
        {
            //destroy
            Destroy(this.gameObject);
        }
        else
        {
            drinkMesh.enabled = false;
            drinkCol.enabled = false;
        }
    }

    IEnumerator SpeedDecrease()
    {
        //set cou started = true to prevent second time
        _startedCou = true;
        //while player speed not = to default speed
        while(GameManagerClass.instanceT.playerVRController.MovementSpeed != GameManagerClass.instanceT.playerBehaviour_G.speed)
        {
            GameManagerClass.instanceT.playerVRController.MovementSpeed -= 1;
            if(GameManagerClass.instanceT.playerVRController.MovementSpeed < GameManagerClass.instanceT.playerBehaviour_G.speed)
            {
                GameManagerClass.instanceT.playerVRController.MovementSpeed = GameManagerClass.instanceT.playerBehaviour_G.speed;
            }
            yield return new WaitForSeconds(delay);
        }
        //check liquid amount
        CheckLiquid();
        //set cou started = false to be able to call again
        _startedCou = false;
    }
}
