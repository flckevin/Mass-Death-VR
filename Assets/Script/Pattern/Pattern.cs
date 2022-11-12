using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: none
 * Content: singleton behaviour
 **************************************/
namespace CorePattern 
{ 
    
    public class Singleton<T>:MonoBehaviour where T : MonoBehaviour 
    { 
        private static T _instance;
        public static object _lock = new object();
        
        public static T instanceT { 

            get
            {
                //lock statement incase multi thread cpu doing multiple thing, lock will lock 
                //statement to do all of these logic first before moving on
                 lock (_lock)
                {
                    //if instance does not exist
                    if(_instance == null)
                    {
                        //find object has instance type
                        var instances = FindObjectsOfType<T>();
                        if(instances.Length > 1 )
                        {
                            //set instance to be the first instance that got found
                            _instance = instances[0];
                            //stop and return instance
                            return _instance;
                        }
                    }

                    //if instance still not exist
                    if(_instance == null)
                    {
                        //create new gameobject and add singleton type
                        _instance = new GameObject().AddComponent<T>();
                        //change name
                        _instance.name = $"{typeof(T)} (Singleton)";
                        //DontDestroyOnLoad(_instance);
                    }
                }
                return _instance;
            }

           
           
        }

        private void Awake()
        {
            _instance = this as T;
        }
    }

}

