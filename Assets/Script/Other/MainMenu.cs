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
        SceneManager.LoadScene(_scene);
   }
}
