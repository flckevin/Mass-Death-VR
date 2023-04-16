using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: consumable items drinks
 * Content: alcolhol behaviour
 **************************************/
public class Alcolhol : ConsumableItem
{
    [Range(0,500)]public float amountInDrinkLeft;
    public float shakeSpeed;
    private float ShakeSpeed
    {
        get{return ShakeSpeed;} 
        set{if(ShakeSpeed >= 0.5f){ShakeSpeed = 0.5f;}}
    } 
    public GameObject cap;
    
    private float shakePose;
    private float _ShakePose
    {
        get{return _ShakePose;} 
        set{if(_ShakePose > 1){_ShakePose = 1;}}
    } 
    private float shakeLength;
    private IEnumerator side;

    public override void OnUseItem()
    {
        if(amountInDrinkLeft > 0)
        {
            _ableToUse = true;
            if(cap == null)return;
            cap.SetActive(false);
        }
        base.OnUseItem();
    }

    public override void OnDisableItem()
    {
        _ableToUse = false;
        if(cap == null)return;
        cap.SetActive(true);

        base.OnDisableItem();
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Drink();
            if(side == null) return;
            side = SideEffect();
            StartCoroutine(side);
        }

        if(amountInDrinkLeft <= 0)
        {
            this.gameObject.SetActive(false);
            if(side == null)Destroy(this.gameObject);
        }
    }
    
    private void OnCollisionStay(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Drink();
        }
    }

    private void Drink()
    {
        amountInDrinkLeft--;
        shakeLength++;
        shakeSpeed++;
        _ShakePose++;
    }

    IEnumerator SideEffect()
    {
        while(shakeLength < 1)
        {
            //lean tween cam for shake effect
            shakeLength--;
            shakeSpeed--;
            shakePose--;
            yield return null;
        }
        side = null;
        if(amountInDrinkLeft <= 0)  Destroy(this.gameObject);
       //set cam back to default
    }

}
