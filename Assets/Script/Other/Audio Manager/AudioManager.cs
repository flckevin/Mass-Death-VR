using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorePattern;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
 [RequireComponent(typeof(AudioSource))]

public class AudioManager : Singleton<AudioManager>
{


    public AudioSource audioSrc;
    public List<AudioClipHolder> commonClip = new List<AudioClipHolder>();


    private void Start() 
    {
        audioSrc = this.gameObject.GetComponent<AudioSource>();
    }
    public void PlayOneShot(AudioClip _audio = null, float volume = 1)
    {
       audioSrc.PlayOneShot(_audio,volume);
    }
    
    public void Stop()
    {
        audioSrc.Stop();
    }

    

}
