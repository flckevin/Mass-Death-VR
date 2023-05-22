using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: every bullet in game
 * Content: hold info varible for bullet
 **************************************/
public class BulletBehaviour : MonoBehaviour
{
   [HideInInspector]public int amountGoThroughObj;
   [HideInInspector]public float damage;
   private void OnCollisionEnter(Collision other) 
   {
      //deactivate object
      this.gameObject.SetActive(false);
   }


   public void OnCollision()
   {
      amountGoThroughObj--;

      if(amountGoThroughObj <= 0)
      {
         //deactivate object
         this.gameObject.SetActive(false);
      }

      
   }

}
