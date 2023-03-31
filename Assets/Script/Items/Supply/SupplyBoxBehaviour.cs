using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/***************************************
 * Authour: HAN 18080038
 * Object hold: supply box
 * Content: supply box behaviour
 **************************************/
public class SupplyBoxBehaviour : MonoBehaviour
{
    public GameObject [] items; // array of items
    public Rigidbody [] shatters;//declare gameobject for shatters

    public GameObject [] spawnPos; // array for spawn position

    public GameObject platform;//declare platform to enable

    private List<GameObject> _selectedItems = new List<GameObject>(); // list of randomiezed items

    private bool _spawned;//declare bool to prevent 2 times spawning

    private void Start() 
    {
        //randomize to select item to spawn
        for(int i =0; i< spawnPos.Length;i++)
        {
            //storing selected item to list
            int rand = Random.Range(0,items.Length-1);
            _selectedItems.Add(items[i]);
        }
    }
    
    private void OnCollisionEnter(Collision other) 
    {
        OpenBox();
    }

    //function to open box
    private void OpenBox()
    {

        //if crate spawned items then stop
        if(_spawned == true) return;

        //disable collision to prevent rigibody conflict and mesh of crate
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        

        //if platform does exist
        if(platform != null)
        {
            //activate it
            platform.SetActive(true);
        }

        //getting all shatters pieces
        for(int i =0;i<shatters.Length - 1;i++)
        {
            //if that shatter piece does exist
            if(shatters[i] != null)
            {
                //activate that shatter piece
                shatters[i].gameObject.SetActive(true);
                //addforce to shatter piece
                shatters[i].AddForce((shatters[i].transform.position - this.transform.position)*500);
            }
        }
        
        //loop all selected items
        for(int i = 0;i<_selectedItems.Count;i++)
        {
            //spawn at each given spawn position
            Instantiate(_selectedItems[i],spawnPos[i].transform.position,Quaternion.identity);
        }

        #region play particle effect

        //get pool manager
        PoolManager poolM = PoolManager.instanceT;

        //if ground slam particle does not exist or it exceed array
        if(poolM.groundSlamParticle[poolM.groundSlamParticleID] == null || poolM.groundSlamParticleID >= poolM.groundSlamParticle.Length - 1)
        {
            //set back to first item in array
            poolM.groundSlamParticleID = 0;
        }

        //set particle to be at crate position
        poolM.groundSlamParticle[poolM.groundSlamParticleID].gameObject.transform.position = this.transform.position;
        //activate particle
        poolM.groundSlamParticle[poolM.groundSlamParticleID].gameObject.SetActive(true);
        //play particle
        poolM.groundSlamParticle[poolM.groundSlamParticleID].Play();
        //increase particle id
        poolM.groundSlamParticleID++;

        #endregion
        
        //set spawn to true to prevent second time spawning it
        _spawned = true;

        //destroy spawning crate
        Destroy(this.gameObject,5.5f);       
        
    }

}
