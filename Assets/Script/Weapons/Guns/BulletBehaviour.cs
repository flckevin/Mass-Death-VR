using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: every bullet in game
 * Content: hold info varible for bullet
 **************************************/
public class BulletBehaviour : MonoBehaviour
{
   [HideInInspector]public int amountGoThroughObj;
   private void OnCollisionEnter(Collision other) 
   {
      amountGoThroughObj--;
      if(amountGoThroughObj <= 0)
      {
         //deactivate object
         this.gameObject.SetActive(false);
      }
      Debug.Log(this.gameObject.name);
   }

}
