using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: Blade
 * Content: blade spinning behaviour
 **************************************/
public class Blade : MonoBehaviour
{
    public float bladeRotateAmount;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating( "RotateBlade",1,1);
    }

    void RotateBlade()
    {
        transform.Rotate(new Vector3(this.transform.rotation.x,bladeRotateAmount,this.transform.rotation.z));
    }

    private void OnTriggerEnter(Collider obj) 
    {
        if(obj.CompareTag("Damageable"))
        {
            obj.GetComponent<IDamageable>().Damage(2,false);
        }
    }
}
