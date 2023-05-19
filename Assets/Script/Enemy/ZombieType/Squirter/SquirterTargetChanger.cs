using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: squirter
 * Content: squirter target changer
 **************************************/
public class SquirterTargetChanger : TargetChanger_Base
{
    public SquirterBehaviour sqrtZombie; // store zombie that going to use this class

    public override void OnStart()
    {
        //check wheter zombie been assigned
        if(sqrtZombie == null){sqrtZombie.GetComponentInParent<SquirterBehaviour>();}
        base.OnStart();
    }

    public override void OnChase(Vector3 target)
    {
        //call squirter chase function
        sqrtZombie.Chase(target);
        base.OnChase(target);
    }

    public override void OnAttack(Transform targetTrans = null)
    {
        //call squirter attack function
        sqrtZombie.OnAttack(targetTrans);
        base.OnAttack(targetTrans);
    }
    
}

