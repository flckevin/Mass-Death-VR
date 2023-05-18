using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class AI_Steering_Sebas 
{
    public float angular; //rotation from 0 to 360
    public Vector3 linear; //instaneous velocity

    //constructor
    public AI_Steering_Sebas()
    {
        angular = 0;
        linear = new Vector3();
    }
}
