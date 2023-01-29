using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public interface IDamageable 
{
    void Damage(float amount = 0,bool instantDeactivate = false);
}
