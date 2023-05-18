using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: every AI
 * Content: agent behaviour
 **************************************/
public class AI_AgentBehaviour_Sebas : MonoBehaviour
{
   public float weight = 1.0f;
   public GameObject target;
   protected AI_Agent_Sebas agent;
   public Vector3 destination;

   public float maxSpeed = 50.0f;
   public float maxAccel = 50.0f;
   public float maxRotation = 5.0f;
   public float maxAngularAccel = 5.0f;

    public virtual void Start() {
        agent = this.gameObject.GetComponent<AI_Agent_Sebas>();
    }

    public virtual void Update() {
        agent.SetSteering(GetSteering(),weight);
    }

    public float MapToRange(float _rotation)
    {
        _rotation %= 360.0f;
        if(Mathf.Abs(_rotation) > 180.0f)
        {
            if(_rotation < 0.0f)
            {
                _rotation += 360f;
            }
            else
            {
                _rotation -= 360f;
            }
        }

        return _rotation;
    }

    public virtual AI_Steering_Sebas GetSteering()
    {
        return new AI_Steering_Sebas();
    }

}
