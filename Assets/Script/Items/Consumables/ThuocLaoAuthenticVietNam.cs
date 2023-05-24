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
    private float _camFoV;
    private float CamFov
    {
        get{return _camFoV;}
        set
        {
            if(_camFoV >= 150)
            {
                _camFoV = 150;
            }
            else if(_camFoV <= 90)
            {
                _camFoV = 90;
            }
            else
            {
                _camFoV = value;
            }
        }
    }
    private bool _mouthTouched;
    private bool _thuocLaoCouIsPlaying;
    private float sideEffectLength;


    private void Start() 
    {
        _audiosourceBacSiHai = this.gameObject.GetComponent<AudioSource>();
        _mouthTouched = false;
        _thuocLaoCouIsPlaying = false;
    }

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "MainCamera")
        {
            _mouthTouched = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "MainCamera")
        {
            if(_mouthTouched == true)
            {
                NhaKhoi();
            }
            _mouthTouched = false;
        }
    }

    public void OnSmoke()
    {
        if(_mouthTouched == true && _thuocLaoLeft >= 0)
        {
            AudioManager.instanceT.PlayOneShot(ritThuocLaoClip);
            if(!smoke.isPlaying){smoke.Play();}
            CamFov+=1*Time.deltaTime;
            GameManagerClass.instanceT.playerCam.fieldOfView = CamFov;
            _thuocLaoLeft -= 1 *Time.deltaTime;
        }
    }

    public void NhaKhoi()
    {
        AudioManager.instanceT.PlayOneShot(nhaKhoiClip);
        if(smoke.isPlaying){smoke.Stop();}
        if(!_audiosourceBacSiHai.isPlaying){_audiosourceBacSiHai.Play();}
        Time.timeScale = 0.5f;
        if(_thuocLaoCouIsPlaying == true) return;
        sideEffectLength++;
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
        while(sideEffectLength > 0)
        {
            CamFov -= 0.1f*Time.deltaTime;
            sideEffectLength -= 0.5f*Time.deltaTime;
            yield return null;
        }

        CamFov = 90;
        Time.timeScale = 1;
        _audiosourceBacSiHai.Pause();
        CheckThuocLaoLeft();
    }
}
