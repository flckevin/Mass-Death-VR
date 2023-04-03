using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: turret in player hub
 * Content: rotation script
 **************************************/
public class RotateObject : MonoBehaviour
{
    // Start is called before the first frame update
    public int firstRotateValue; // first value to rotate
    public int secondRotateValue; // second value to rotte
    public float speed; // speed
    private float currentChosenRotateValue; // store which value been chosen
    void Start()
    {
        //repeate rotate function
        InvokeRepeating("Rotate",1,speed + 1.5f);
    }

    private void Rotate()
    {
        //set rotate value
        float _rotateValue = RotateValue();
        //rotate
        LeanTween.rotateLocal(this.gameObject,new Vector3(this.gameObject.transform.rotation.x,_rotateValue,this.gameObject.transform.rotation.z),speed);
       
    }

    //function to set rotation value
    private float RotateValue()
    {
        //store rotation value
        float _rotateValue = 0;

        //checking which value it chosen
        if(currentChosenRotateValue == 2 || currentChosenRotateValue == 0)
        {
            //set rotate value
            _rotateValue = firstRotateValue;
            currentChosenRotateValue = 1;
        }
        else
        {
            //set rotate value
            _rotateValue = secondRotateValue;
            currentChosenRotateValue = 2;
        }

        //return selected value
        return _rotateValue;

    }
}
