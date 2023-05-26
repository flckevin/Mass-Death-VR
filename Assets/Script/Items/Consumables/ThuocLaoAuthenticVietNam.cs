using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: Thuoc Lao
 * Content: THUOC LAO VIETNAMMMMMMM SMOKE IT N U GONNA SEE VIETNAM FRONT OF UR EYES
 **************************************/
[RequireComponent(typeof(AudioSource))]
public class ThuocLaoAuthenticVietNam : MonoBehaviour
{
    public ParticleSystem smoke;
    public MeshRenderer thuoclaoMesh;
    public BoxCollider thuoclaoCol;
    public AudioClip ritThuocLaoClip;
    public AudioClip nhaKhoiClip;
    public float _thuocLaoLeft;

    private AudioSource _audiosourceBacSiHai;
    private bool activated;
    private bool _thuocLaoCouIsPlaying;
    private bool _smoking = false;
    private float _sideEffectLength;
    private float SideEffectLength
    {
        get{return _sideEffectLength;}
        set
        {
            if(_sideEffectLength >= 300 )
            {
                _sideEffectLength = 300;
            }
            else if(_sideEffectLength <= 0)
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
        _audiosourceBacSiHai = this.gameObject.GetComponent<AudioSource>();
        activated = false;
        _thuocLaoCouIsPlaying = false;
        Debug.Log("CALLED");
        //NhaKhoi();
        
    }

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log(other.name);
        if(activated == true && other.gameObject.tag == "MainCamera")
        {
            _smoking = true;
            OnSmoke();
        }  
    }

    private void OnTriggerStay(Collider other) 
    {
        if(activated == true && other.gameObject.tag == "MainCamera")
        {
            OnSmoke();
            _smoking = true;
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "MainCamera" && _smoking == true)
        {
            
            NhaKhoi();
            activated = false;
            _smoking = false;
        }
    }

    public void OnSmoke()
    {
        if(_thuocLaoLeft >= 0)
        {
            if(!AudioManager.instanceT.audioSrc.isPlaying)
            {
                AudioManager.instanceT.PlayOneShot(ritThuocLaoClip,1);
            }
            SideEffectLength+=10*Time.deltaTime;
            _thuocLaoLeft -= 1 *Time.deltaTime;
        }
    }

    public void Onactivate()
    {
        activated = true;
        if(!smoke.isPlaying)
        {
            smoke.gameObject.SetActive(true);
            smoke.Play();
        }
        Debug.Log("ACTIVATED");
    }

    public void NhaKhoi()
    {
        //AudioManager.instanceT.PlayOneShot(nhaKhoiClip,1);
        if(smoke.isPlaying)
        {
            smoke.Stop();
            smoke.gameObject.SetActive(false);
        }
        
       _audiosourceBacSiHai.Play();
        Debug.Log("BAC SI HAI");
        
        Time.timeScale = 0.5f;
        Debug.Log("NHA KHOI");
        if(_thuocLaoCouIsPlaying == true) return;
        StartCoroutine(ThuocLaoEffectRunningOut());
    }

    void CheckThuocLaoLeft()
    {
        if(_thuocLaoLeft > 0) return;
        if(_thuocLaoCouIsPlaying)
        {
            thuoclaoMesh.enabled = false;
            thuoclaoCol.enabled = false;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator ThuocLaoEffectRunningOut()
    {
        while(SideEffectLength > 0)
        {
            SideEffectLength -= 0.1f*Time.deltaTime;
            yield return null;
        }
        Time.timeScale = 1;
        _audiosourceBacSiHai.Pause();
        CheckThuocLaoLeft();
    }
}
