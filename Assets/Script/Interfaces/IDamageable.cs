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
    void RaycastDamage(float amount, RaycastHit effect,bool deactivateObjectInstant);
    
    void Damage(float amount,bool instantDeactivate);
}
