using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: tutorial pads
 * Content: tutorial pad behaviour
 **************************************/
 [CreateAssetMenu(fileName = "Tutorial Page", menuName = "ScriptableObjects/TutorialPages")]
public class TutorialPagesScriptable : ScriptableObject
{
   public string tutorialSectionName;
   public string[] text;
   public Sprite[] images;

   public AudioClip[] tutorialClip;
}
