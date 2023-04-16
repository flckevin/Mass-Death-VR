using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
 [CreateAssetMenu(fileName = "Tutorial Page", menuName = "ScriptableObjects/TutorialPages")]
public class TutorialPagesScriptable : ScriptableObject
{
   public string tutorialSectionName;
   public string[] text;
   public Sprite[] images;
}
