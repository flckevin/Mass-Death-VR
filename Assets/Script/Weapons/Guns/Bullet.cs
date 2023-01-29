using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: every bullet in game
 * Content: hold info varible for bullet
 **************************************/
public class Bullet : MonoBehaviour
{
   private void OnCollisionEnter(Collision other) 
   {
      //deactivate object
      this.gameObject.SetActive(false);
   }

}
