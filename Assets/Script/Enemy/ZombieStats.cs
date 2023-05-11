using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
 [CreateAssetMenu(fileName = "ZombieStats", menuName = "ScriptableObjects/ZombieStats")]
public class ZombieStats : ScriptableObject
{
    public float zombieHealth;
    public float zombieDamageAmount;
    public float zombieSpeed;
    public int moneyReceive;
}
