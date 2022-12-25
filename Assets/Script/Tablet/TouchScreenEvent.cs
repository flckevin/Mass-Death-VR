using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class TouchScreenEvent : MonoBehaviour
{
   public UnityEvent OnTouch;

   private void OnTriggerEnter(Collider other) 
   {
      if(other.CompareTag("Finger"))
      {
         OnTouch.Invoke();
         Debug.Log("DOING");
      }
   }
}
