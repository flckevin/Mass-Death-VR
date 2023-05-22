using UnityEngine;
using CorePattern;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class ParticleSystemPlayer : Singleton<ParticleSystemPlayer>
{
    public void PlayeParticle(ParticleSystem _particle,Transform _position)
    {
        if(_particle != null)
        {
            _particle.gameObject.SetActive(true);
            _particle.transform.position = _position.position;
            _particle.Play();
        }
    }
    public void PlayeParticleFromPool(ParticleSystem[] _particle,int _ID,Transform _position)
    {
        if(_particle[_ID] != null)
        {
            _particle[_ID].gameObject.SetActive(true);
            _particle[_ID].transform.position = _position.position;
            _particle[_ID].Play();
        }
        _ID++;
    }

}
