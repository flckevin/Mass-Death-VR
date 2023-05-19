using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class RunnerTargetChanger : TargetChanger_Base
{
   public RunnerBehaviour runner;//common zombie to set target
    public override void OnStart()
    {
        
        base.OnStart();
        if(runner == null){runner = GetComponentInParent<RunnerBehaviour>();}
    }

    public override void OnAttack(IDamageable targetIdmg = null)
    {
        runner.Attack(targetIdmg);
        base.OnAttack(targetIdmg);
    }

    public override void OnChase(Vector3 target)
    {
        runner.Chase(target);
    }
}
