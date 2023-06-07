using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class DamageableMD : MonoBehaviour,IDamageable
{
    public float health;
    public bool reactiveAble;
    public float reactiveDelay;
    public MeshRenderer mesh;
    public Collider col;

    private void Awake()
    {
        if (mesh == null)
        {
            mesh = this.gameObject.GetComponent<MeshRenderer>();
        }
        if (col == null)
        {
            col = this.gameObject.GetComponent<Collider>();
        }
    }

    public void Damage(float amount = 0, bool instantDeactivate = false)
    {
        DamageReceive(amount);
        
    }

    

    void DamageReceive(float amount) 
    {
        health--;
        if (health <= 0) 
        {
            mesh.enabled = false;
            col.enabled = false;
            if (reactiveAble == true)
            {
                StartCoroutine(Reactive());
            }
            else 
            {
                Destroy(this.gameObject);
            }
        }
    
    }

    IEnumerator Reactive() 
    {
        yield return new WaitForSeconds(reactiveDelay);
        mesh.enabled = true;
        col.enabled = true;
    }
}
