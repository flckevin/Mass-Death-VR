using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class EnergyDrink : MonoBehaviour
{
    public float speedToIncrease; // speed to increase
    public float _drinkLeft; // amount of drink left
    public float delay; // delay amount between speed decrease
    private bool _mouthTouched; // identify whether mouth touched
    private bool _opened; // identify whether player opened the drink
    private bool _startedCou; // identify whether couroutine started

    private void OnTriggerEnter(Collider other) 
    {
        //set mouth touched to true
        _mouthTouched = true;
        
    }

    private void OnTriggerExit(Collider other) 
    {
        //set mouth touched to false
        _mouthTouched = false;
    }

    public void OnDrink()
    {
        //if mouth not touching it or player have not open the bottle
        if(_mouthTouched == false || _opened == false) return;
        //if movement speed is less than 5
        if(GameManagerClass.instanceT.playerVRController.MovementSpeed <= 5)
        {
            //increase movement speed
            GameManagerClass.instanceT.playerVRController.MovementSpeed += (speedToIncrease*Time.deltaTime);
        }
        // decrease drink left
        _drinkLeft -=1 *Time.deltaTime;
        if(_startedCou == true) return;
        StartCoroutine(SpeedDecrease());
    }

    //function to open bottle
    public void Open(bool _enable)
    {
        //set open boolian
        _opened = _enable;
    }

    //function to check liquid left
    private void CheckLiquid()
    {
        //if there is non
        if(_drinkLeft <= 0)
        {
            //destroy
            Destroy(this.gameObject);
        }
    }

    IEnumerator SpeedDecrease()
    {
        //set cou started = true to prevent second time
        _startedCou = true;
        //while player speed not = to default speed
        while(GameManagerClass.instanceT.playerVRController.MovementSpeed != GameManagerClass.instanceT.playerBehaviour_G.speed)
        {
            //decrease speed
            GameManagerClass.instanceT.playerVRController.MovementSpeed -= 1;
            yield return new WaitForSeconds(delay);
        }
        //check liquid amount
        CheckLiquid();
        //set cou started = false to be able to call again
        _startedCou = false;
    }
}
