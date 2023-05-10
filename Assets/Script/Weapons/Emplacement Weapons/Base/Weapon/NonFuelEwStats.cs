using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
 [CreateAssetMenu(fileName ="EWStats",menuName = "ScriptableObjects/EwNonFuelStats")]
public class NonFuelEwStats : ScriptableObject
{
    public float initiationLength;
    public float activationLength;
    public float delay;
    public int damage;
    public int upgradeCost;
    
}
