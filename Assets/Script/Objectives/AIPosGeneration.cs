using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class AIPosGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    /*
    public int amountGeneration;
    public float randPosRange;
    public List<Vector3> AIPos = new List<Vector3>();
    private int _AIPosID;
    public int AIPosID
    {
        get{return _AIPosID;}
        set
        {
            if(_AIPosID >= AIPos.Count - 1)
            {
                _AIPosID = 0;
            }
            else
            {
                _AIPosID = value;
            }
        }
    }
    void Start()
    {
        GeneratePos(amountGeneration);
    }

    void GeneratePos(int _amount)
    {
        for(int i =0;i<_amount;i++)
        {
            Vector3 _result;
            if(RandomPoint(this.gameObject.transform.position,out _result))
            {
                AIPos.Add(_result);
            }
        }
    }

    bool RandomPoint(Vector3 center, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * randPosRange; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, randPosRange, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        { 
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
    */
    public Transform[] positions;
    public int PosID
    {
        get{return _posID;}
        set
        {
            if(_posID >= positions.Length - 1)
            {
                _posID = 0;
            }
            else
            {
                _posID = value;
            }
        }
    }
    private int _posID;

    public Vector3 GetPos()
    {
        Vector3 _pos = new Vector3();
        PosID++;
        _pos = positions[PosID].position;
        Debug.Log(PosID);
        return _pos;
    }
}
