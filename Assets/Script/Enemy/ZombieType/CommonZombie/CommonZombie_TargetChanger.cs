using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: common zombie target changer
 * Content: change target for common zombie
 **************************************/
public class CommonZombie_TargetChanger : TargetChanger_Base
{
    public CommonZombie commonZombie;//common zombie to set target
    public override void OnStart()
    {
        base.OnStart();
        if(commonZombie == null){commonZombie = GetComponentInParent<CommonZombie>();}
    }

    public override void OnAttack(IDamageable targetIdmg = null)
    {
        commonZombie.Attack(targetIdmg);
        base.OnAttack(targetIdmg);
    }

    public override void OnChase(Vector3 target)
    {
        commonZombie.Chase(target);
    }
}
