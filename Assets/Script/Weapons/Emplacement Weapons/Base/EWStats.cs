using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
 [CreateAssetMenu(fileName ="EWStats",menuName = "ScriptableObjects/EwStats")]
public class EWStats : ScriptableObject
{
   public float defaultFuel;
   public float fuelToDecrease;
   public int amountToUpgrade;

}
