using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class MainMenu : MonoBehaviour
{
   public void load(string _scene)
   {
        switch (_scene) 
        {
            case "Level":
                LoadScene.Load(LoadScene.Scene.Level);
                break;
            case "Tutorial":
                LoadScene.Load(LoadScene.Scene.Tutorial);
                break;
        
        }
        

   }
}
