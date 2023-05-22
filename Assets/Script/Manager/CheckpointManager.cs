using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class CheckpointManager : MonoBehaviour
{
    public Transform[] checkpoints;
    public List<Transform> randCheckpointPos = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        RandomCheckPointPos();
    }
    
    public void RandomCheckPointPos()
    {
        Rand(randCheckpointPos);
        if(checkpoints.Length == 0 || randCheckpointPos.Count == 0) return;

        for(int i =0 ; i < checkpoints.Length ; i++)
        {
            checkpoints[i].position = randCheckpointPos[i].position;
        }

    }


    public void Rand(List<Transform> _target)
    {
       for(int i = 0; i < _target.Count ; i ++)
       {
         Transform item = _target[i];
         int rand = Random.Range(1,_target.Count);
         _target[i] = _target[rand];
         _target[rand] = item;
       }
    }
}
