using UnityEngine;
using CorePattern;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class ParticleSystemPlayer : Singleton<ParticleSystemPlayer>
{
    public void PlayeParticle(ParticleSystem particle,Transform position)
    {
        if(particle != null)
        {
            particle.gameObject.SetActive(true);
            particle.transform.position = position.position;
            particle.Play();
        }
    }
}
