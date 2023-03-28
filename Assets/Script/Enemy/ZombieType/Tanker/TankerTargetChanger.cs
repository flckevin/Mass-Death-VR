using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: tank target changer
 * Content: target changer for tank
 **************************************/
public class TankerTargetChanger : TargetChanger_Base
{
    public TankerBehaviour tankBhaviour; // store tank behaviour

    public override void OnAttack(IDamageable targetIdmg = null)
    {
        
        base.OnAttack(targetIdmg);
        //call tank attack function
        tankBhaviour.OnAttackRadius();
    }

    public override void OnChase(Transform target)
    {
        base.OnChase(target);
        //call tank chase function
        tankBhaviour.OnChase(target);
    }
}
