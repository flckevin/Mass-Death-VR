using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: Thuoc Lao
 * Content: THUOC LAO VIETNAMMMMMMM SMOKE IT N U GONNA SEE VIETNAM FRONT OF UR EYES 
 * NOTICE : ** THIS IS NOT ILLIGAL DRUG IN VIETNAM THIS IS A COMMON SMOKING PIPE IN VIETNAM PLEASE DO GOOGLE SEARCH "THUOC LAO" FOR MORE DETAIL
 **************************************/
[RequireComponent(typeof(AudioSource))]
public class ThuocLaoAuthenticVietNam : MonoBehaviour
{
    public ParticleSystem smoke; // smoke particle
    public AudioClip ritThuocLaoClip; // audio clip of smoking
    public AudioClip nhaKhoiClip; // audioclip of realising smoke
    public float _thuocLaoLeft; // amount of thuoc lao left

    private AudioSource _audiosourceBacSiHai; // audio source
    private bool litted; // bool to check whether is activated
    private bool _thuocLaoCouIsPlaying; // bool to check whether couroutine is playing
    private bool _smoking = false; // bool to identiy whether is smoking
    private float _sideEffectLength; // side effect length
    private float SideEffectLength
    {
        get{return _sideEffectLength;}
        set
        {
            if(_sideEffectLength > 300)
            {
                _sideEffectLength = 300;
            }
            else if(_sideEffectLength < 0)
            {
                _sideEffectLength = 0;
            }
            else
            {
                _sideEffectLength = value;
            }
        }
    }

    private void Start() 
    {
        //get audio source
        _audiosourceBacSiHai = this.gameObject.GetComponent<AudioSource>();
        //set activated to false 
        litted = false;
        //set couroutine to false
        _thuocLaoCouIsPlaying = false;
       
        
    }

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other) 
    {
        //if player have lighten up thuoc lao and player is putting into their mouth
        if(litted == true && other.gameObject.tag == "MainCamera")
        {
            //set smoke to true
            _smoking = true;
            //call smoke function
            OnSmoke();
        }  
    }

    private void OnTriggerStay(Collider other) 
    {
        //if player have lighten up thuoc lao and player is putting into their mouth
        if(litted == true && other.gameObject.tag == "MainCamera")
        {
            //set smoke to true
            OnSmoke();
            //call smoke function
            _smoking = true;
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        //if player have lighten up thuoc lao and player is putting into their mouth
        if(other.gameObject.tag == "MainCamera" && _smoking == true)
        {
            //release smoke function
            NhaKhoi();
            //set lighten up to false
            litted = false;
            //set smoking to false
            _smoking = false;
        }
    }

    //smoking function
    public void OnSmoke()
    {
        //check whether there is thuoc lao left
        if(_thuocLaoLeft >= 0)
        {
            //if it is
            //play smoke audio
            if(!AudioManager.instanceT.audioSrc.isPlaying)
            {
                
                AudioManager.instanceT.PlayOneShot(ritThuocLaoClip,1);
            }
            
        }
    }

    public void Onactivate()
    {
        //if there arent any thuoc lao left then stop light up
        if(_thuocLaoLeft < 0) return;
        //set lighten up to true
        litted = true;
        //if smoke particle not playing yet then play smoke particle
        if(!smoke.isPlaying)
        {
            smoke.gameObject.SetActive(true);
            smoke.Play();
        }
        
    }

    public void NhaKhoi()
    {
        //increase side effect length
        SideEffectLength+=30;
        //decrease amount of thuoc lao
        _thuocLaoLeft -= 5;
        //play music
        _audiosourceBacSiHai.Play();
        //play release smoke audio
        AudioManager.instanceT.PlayOneShot(nhaKhoiClip,1);
        //if smoke still playing then stop
        if(smoke.isPlaying)
        {
            smoke.Stop();
            smoke.gameObject.SetActive(false);
        }
        //slow down time
        Time.timeScale = 0.5f;
       //if couroutine is playing then stop execute
        if(_thuocLaoCouIsPlaying == true) return;
        //execute couroutine
        StartCoroutine(SideEffectStop());
    }

    void CheckThuocLaoLeft()
    {
        //if there is still thuoc lao left then stop execute
        if(_thuocLaoLeft > 0) return;
        //destroy thuoc lao
        Destroy(this.gameObject);
        
    }

   IEnumerator SideEffectStop()
   {
        //set thuoc lao couroutine is playing to true
        _thuocLaoCouIsPlaying = true;
        //wait until side effect length finished
        yield return new WaitForSeconds(SideEffectLength);
        //set time scale back to normal
        Time.timeScale = 1;
        //pause music
        _audiosourceBacSiHai.Pause();
        //check amount of thuoc lao left
        CheckThuocLaoLeft();
        //set thuoc lao is playing to false
        _thuocLaoCouIsPlaying = false;
   }
}
