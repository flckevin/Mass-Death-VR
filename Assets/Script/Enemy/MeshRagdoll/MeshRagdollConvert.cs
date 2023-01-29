
using UnityEngine;
/***************************************
 * Authour: HAN 18080038
 * Object hold: Every Zombie's ragdoll
 * Content: Convert ragdoll to a normal mesh 
 **************************************/
public class MeshRagdollConvert : MonoBehaviour
{
    [Header("RAGDOLL_INFO")]
    public int amountOfLimb; //amount of limb to track
    public SkinnedMeshRenderer skinMesh;//store skinnedmesh
    public MeshFilter meshFilter; //store meshfilter
    public GameObject ragdollBones;//store ragdoll gameobject
    private int defaultAmountOfLimb;//store default amount of limb

    private void Awake() 
    {
        //setting default amount of limbs
        defaultAmountOfLimb = amountOfLimb;
    }

    //function to convert ragdoll skinned mesh to mesh
    public void Convert()
    {
        //checking if amount of limb less or equal to 0
        if(amountOfLimb <= 0)
        {
            //create new mesh to store baked mesh
            Mesh m = new Mesh();
            //bake skinned mesh
            skinMesh.BakeMesh(m);
            //set meshfilter to be ragdoll mesh
            meshFilter.mesh = m;
            //deactivate skinned mesh
            skinMesh.gameObject.SetActive(false);
            //deactivate ragdoll
            ragdollBones.gameObject.SetActive(false);
        }
    }

    //function to set back to default value of amount of limbs
    public void SetToDefault()
    {
        //setting back to default value
        amountOfLimb = defaultAmountOfLimb;
        //disable mesh
        meshFilter.gameObject.SetActive(false);
        //activate ragdoll bone
        ragdollBones.SetActive(true);
        //disable current object holding this class
        this.gameObject.SetActive(false);
    }


}
