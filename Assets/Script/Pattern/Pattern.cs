using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
namespace CorePattern 
{ 

    public class Singleton<T>:MonoBehaviour where T : MonoBehaviour 
    { 
        public static T instanceT { get; private set; }

        private void Awake()
        {
            instanceT = this as T;
        }
    }

}

