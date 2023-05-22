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


    private AudioSource _audioSrc;
    public List<AudioClipHolder> commonClip = new List<AudioClipHolder>();


    private void Start() 
    {
        _audioSrc = this.gameObject.GetComponent<AudioSource>();
    }
    public void PlayOneShot(AudioClip _audio, float volume)
    {
       _audioSrc.PlayOneShot(_audio,volume);
    }
    
    public void Stop()
    {
        _audioSrc.Stop();
    }

    

}
