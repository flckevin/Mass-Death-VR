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
    private bool attacking; // declare bool to identify whether zombie is attacking

    public override void OnAttack(IDamageable targetIdmg = null)
    {
        if(attacking == true) return;
        base.OnAttack(targetIdmg);
        tankBhaviour.meshAnims.Play("TankAttack");
        //call tank attack function
        StartCoroutine(DealDamage());
        attacking = true;
    }

    IEnumerator DealDamage()
    {
        yield return new WaitForSeconds(1.3f);
        tankBhaviour.OnAttackRadius();
        yield return new WaitForSeconds(2.7f);
        attacking = false;
    }

    public override void OnChase(Transform target)
    {
        if(attacking == false)
        {
            base.OnChase(target);
            //call tank chase function
            tankBhaviour.OnChase(target);
        }
        else
        {
            StartCoroutine(Chase(target));
        }
        

    }

    IEnumerator Chase(Transform _target)
    {
        yield return new WaitForSeconds(tankBhaviour.meshAnims.animations[0].Length);
        tankBhaviour.OnChase(_target);
    } 
}
