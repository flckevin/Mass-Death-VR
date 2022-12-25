using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSG.MeshAnimator;
using UnityEngine.AI;

/***************************************
 * Authour: HAN18080038
 * Object hold: Every enemy 
 * Content: Behaviour of zombie in game
 **************************************/
public class EnemyBehaviour : MonoBehaviour
{
    [Header("Zombie Info")]
    
    public float zombieHealth;//declare float for zombie health

    public ZombieStats zombieStats;

    #region zombieComponents
    protected float _defaultZombieSpeed;//declare float to store default nav agent speed
    [HideInInspector] public MeshAnimatorBase meshAnimsBase;//declare mesh animator base to controll animation
    [HideInInspector] public NavMeshAgent navAgent;//declare nav mesh agent to chase to target
    protected IZombieStateBase _State;//declare zombie state interface to change state of zombie
    protected string _currentState; //declare current state to identify which state zombie current in
    
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
        //storing navmesh agent class into this class
        navAgent = this.gameObject.GetComponent<NavMeshAgent>();

        //storing meshanimatorbase class into this class
        meshAnimsBase = this.gameObject.GetComponent<MeshAnimatorBase>();

        //storing default speed
        _defaultZombieSpeed = navAgent.speed;
        
        VirtualStart();
    }

    public virtual void VirtualStart(){}
    
    #region Damage Receive
    //function to squirt blood and receive damage
    public void DamageReceiver(float damageDealt,RaycastHit posToSquirtBloodRaycast,bool deactivateObject) 
    {

        #region Blood Squirting

        //squirt blood
        //if blood id is exceed from the blood array length
        if(PoolManager.instanceT.bloodID_Blood > PoolManager.instanceT.bloodG_Blood.Length - 1) 
        {
            //set blood id back to 0 (from beginning)
            PoolManager.instanceT.bloodID_Blood = 0;
        }

        //if that blood pool does exist
        if(PoolManager.instanceT.bloodG_Blood[PoolManager.instanceT.bloodID_Blood] != null) 
        {
            //deactivate blood object to replay squirting blood
            PoolManager.instanceT.bloodG_Blood[PoolManager.instanceT.bloodID_Blood].SetActive(false);
            //set position to squirt out of blood
            PoolManager.instanceT.bloodG_Blood[PoolManager.instanceT.bloodID_Blood].transform.position = posToSquirtBloodRaycast.point;

            //getting correct angle to squirt blood
            float angle = Mathf.Atan2(posToSquirtBloodRaycast.normal.x, posToSquirtBloodRaycast.normal.z) * Mathf.Rad2Deg + 180;
            //setting correct rotation to squirt blood
            PoolManager.instanceT.bloodG_Blood[PoolManager.instanceT.bloodID_Blood].transform.rotation = Quaternion.Euler(0, angle + 90, 0);

            //activate blood object to play squirting blood
            PoolManager.instanceT.bloodG_Blood[PoolManager.instanceT.bloodID_Blood].SetActive(true);
            
        }

        //increase blood id to move to next blood object
        PoolManager.instanceT.bloodID_Blood++;
        #endregion
        //calling damage function to damage zombie itself
        DamageReceiver(damageDealt,deactivateObject);
    }

    //function to receive damage
    public void DamageReceiver(float damageDealt,bool instantDeactivation)
    {
        #region Decrease Health
        //decreasing zombie health
        zombieHealth -= damageDealt;
        //if zombie health is less than 0
        if (zombieHealth <= 0) 
        {
            //call die function
            OnDie();
        }
        #endregion

        //deactivate object
        this.gameObject.SetActive(instantDeactivation);
        
    }
    #endregion

    //funciton for zombie to die
    public void OnDie()
    {
        //dsiable navmesh agent
        navAgent.enabled = false;
        //play zombie death animation
        meshAnimsBase.Play("Z_FallingBack");
        //set tag to be dead enemy
        this.gameObject.tag = "DeadEnemy";
        //disable enemy script
        this.enabled = false;
    }

    //function to reveive zombie
    public void OnRevive()
    {
        //set back to default health
        zombieHealth = zombieStats.zombieHealth;
        //enable navmesh agent
        navAgent.enabled = true;
        //set back to default tag
        this.gameObject.tag = "Zombie";
    }

      private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Bullet"))
        {
            //get bullet component to access to amount of damage
            //call damage function
        }
    }


}
