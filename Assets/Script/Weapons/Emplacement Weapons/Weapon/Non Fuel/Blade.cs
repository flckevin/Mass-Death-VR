using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/***************************************
 * Authour: HAN 18080038
 * Object hold: Blade
 * Content: blade spinning behaviour
 **************************************/
public class Blade : NonFuelEmplacementWeaponsBase
{
    [Header("Blade Info")]
    public GameObject blade1;
    public GameObject blade2;
    private Vector3 _spinDir;

    public override void Start()
    {
        //function to random of spinning direction
            Func<Vector3> tempFunc = () =>{ Vector3 c; 
                                            int rand = UnityEngine.Random.Range(0,5);
                                            if(rand <= 5){c = Vector3.up;} else{c = -Vector3.up;}
                                            return c;};

        _spinDir = tempFunc();
        base.Start();
    }

    public override void OnInitiate(bool _activation)
    {
        if(_activation == false)
        {
            LeanTween.rotateZ(blade1,0,initiationLength);
            LeanTween.rotateZ(blade2,0,initiationLength);        
        }
        else
        {
            LeanTween.rotateZ(blade1,-90,initiationLength);
            LeanTween.rotateZ(blade2,-90,initiationLength);
        }
        base.OnInitiate(_activation);
    }

    public override void OnActivation(bool _activation)
    {
        if(_activation == true)
        {
            
            //rotate balde
            LeanTween.rotateAround(this.gameObject, _spinDir, 360, 2.5f).setLoopClamp();
        }
        else
        {
            LeanTween.pause(this.gameObject);
        }

        base.OnActivation(_activation);
    }

    
    

}
