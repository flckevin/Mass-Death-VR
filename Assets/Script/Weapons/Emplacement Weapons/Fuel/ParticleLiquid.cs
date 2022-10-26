using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: fuel
 * Content: On pour liquid
 **************************************/
public class ParticleLiquid : MonoBehaviour
{
    public ParticleSystem particle;//declare particle for particle to be play
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //comparing whether the angle of object is less or queal to 90 
        if(Vector3.Angle(Vector3.down,transform.forward) >= 90) 
        {
            Debug.Log("Play");
            //play particle
            if (!particle.isPlaying) 
            {
                particle.Play();
            }
        }
        else 
        {
            Debug.Log("stop");
            //stop the particle
            if (particle.isPlaying) 
            {
                particle.Stop();
            }
           
        }
    }
}
