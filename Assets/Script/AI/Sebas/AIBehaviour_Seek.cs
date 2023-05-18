using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class AIBehaviour_Seek : AI_AgentBehaviour_Sebas
{
  

    public override AI_Steering_Sebas GetSteering()
    {
        AI_Steering_Sebas steer = new AI_Steering_Sebas();
        steer.linear = target.transform.position - transform.position;
        steer.linear.Normalize();
        steer.linear = steer.linear*agent.maxAccel;

        return steer;
    }

}
