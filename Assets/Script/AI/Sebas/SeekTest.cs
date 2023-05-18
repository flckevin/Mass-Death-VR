using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
 [RequireComponent(typeof(AIBehaviour_Seek))]
public class SeekTest : MonoBehaviour
{
    public GameObject target;
    private AIBehaviour_Seek seek;
    // Start is called before the first frame update
    void Start()
    {
        seek = this.gameObject.GetComponent<AIBehaviour_Seek>();
        seek.target = target;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
