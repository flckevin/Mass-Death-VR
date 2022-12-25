using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: every consumable items
 * Content:base for items
 **************************************/
public class ConsumableItemNEW_NoGasBase : MonoBehaviour,IHammerAble
{

    // Start is called before the first frame update
   [SerializeField] protected bool _ableToUse;//declare bool to check wheter be able to use
    protected bool _used;//declare bool to check whether player have used item

    public virtual void OnsueEWnItem() 
    { 
    
    }

    public virtual void OnSetDefaultEWnItem() 
    {
        
    }

    public virtual void UpgradeEW()
    {

    }

    public void OnUpgrade()
    {
        UpgradeEW();
        
    }

    public void OnFix()
    {
        throw new System.NotImplementedException();
    }
}
