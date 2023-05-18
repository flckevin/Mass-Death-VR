using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: AI
 * Content: agent script for basic things like walking
 **************************************/
public class AI_Agent_Sebas : MonoBehaviour
{
    public float maxSpeed = 10f; // max speed
    public float trueMaxSpeed; // for boids to match other max speed
    public float maxAccel = 30.0f; // max acceleration

    public float orientation;
    public float rotation; // each frame how much going to be rotate
    public Vector3 velocity; // velocity moving at
    protected AI_Steering_Sebas steeringAI; // steering apply on update
    public float maxRotation = 45f;
    public float maxAngularAccel = 45f;
    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;
        steeringAI = new AI_Steering_Sebas();
        trueMaxSpeed = maxSpeed;
    }

    public void SetSteering(AI_Steering_Sebas _steer,float _weight)
    {
        this.steeringAI.linear +=(_weight*_steer.linear);
        this.steeringAI.angular += (_weight*_steer.angular);
    }

    // change the transform based off of last frame steering
    public virtual void Update()
    {
        Vector3 displacement = velocity *Time.deltaTime;
        orientation += rotation *Time.deltaTime;

        //locking orentation between 0 to 360
        if(orientation < 0)
        {
            orientation += 360;
        }
        else if(orientation > 360)
        {
            orientation -= 360;
        }

        transform.Translate(displacement,Space.World);
        transform.rotation = new Quaternion();
        transform.Rotate(Vector3.up,orientation);
    }

    //update movement for next frame
    public virtual void LateUpdate() 
    {
        velocity += steeringAI.linear * Time.deltaTime;
        rotation += steeringAI.angular * Time.deltaTime;
        if(velocity.magnitude > maxSpeed)
        {
            velocity.Normalize();
            velocity = velocity*maxSpeed;
        }
        if(steeringAI.linear.magnitude == 0f)
        {
            velocity = Vector3.zero;
        }
        steeringAI = new AI_Steering_Sebas();
    }

    public void SpeedReset()
    {
        maxSpeed = trueMaxSpeed;
    }
}
