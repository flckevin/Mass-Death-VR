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
public class EnemyBehaviour : MonoBehaviour,IDamageable
{
    [Header("Zombie Info")]
    public float zombieHealth;//declare float for zombie health
    [HideInInspector]public float defaultZombieSpeed;//declare float to store default nav agent speed
    [Header("Zombie Component")]
    [HideInInspector] public MeshAnimatorBase _meshAnimsBase;//declare mesh animator base to controll animation
    [HideInInspector] public NavMeshAgent _navAgent;//declare nav mesh agent to chase to target
    protected IZombieStateBase _currentState;//declare zombie state interface to change state of zombie
    // Start is called before the first frame update
    void Start()
    {
        //storing navmesh agent class into this class
        _navAgent = this.gameObject.GetComponent<NavMeshAgent>();
        //storing meshanimatorbase class into this class
        _meshAnimsBase = this.gameObject.GetComponent<MeshAnimatorBase>();
        //storing default speed
        defaultZombieSpeed = _navAgent.speed;

        //DamageReceiver(100);
    }


    /// <summary>
    /// Function to deal damage to zombie
    /// </summary>
    /// <param name="damageDealt"> Value to deal damage to zombie </param>
    /// /// <param name="posToSquirtBloodRaycast"> Position to squirt out of blood </param>
    public void DamageReceiver(float damageDealt,RaycastHit posToSquirtBloodRaycast,bool deactivateObject) 
    {

        #region Blood Squirting
        //decreasing zombie health
        zombieHealth -= damageDealt;
        //squirt blood
        //if blood id is exceed from the blood array length
        if(PoolManager.poolInstance.bloodID_Int > PoolManager.poolInstance.blood_G.Length - 1) 
        {
            //set blood id back to 0 (from beginning)
            PoolManager.poolInstance.bloodID_Int = 0;
        }

        //if that blood pool does exist
        if(PoolManager.poolInstance.blood_G[PoolManager.poolInstance.bloodID_Int] != null) 
        {
            //deactivate blood object to replay squirting blood
            PoolManager.poolInstance.blood_G[PoolManager.poolInstance.bloodID_Int].SetActive(false);
            //set position to squirt out of blood
            PoolManager.poolInstance.blood_G[PoolManager.poolInstance.bloodID_Int].transform.position = posToSquirtBloodRaycast.point;

            //getting correct angle to squirt blood
            float angle = Mathf.Atan2(posToSquirtBloodRaycast.normal.x, posToSquirtBloodRaycast.normal.z) * Mathf.Rad2Deg + 180;
            //setting correct rotation to squirt blood
            PoolManager.poolInstance.blood_G[PoolManager.poolInstance.bloodID_Int].transform.rotation = Quaternion.Euler(0, angle + 90, 0);

            //activate blood object to play squirting blood
            PoolManager.poolInstance.blood_G[PoolManager.poolInstance.bloodID_Int].SetActive(true);
            
        }

        //increase blood id to move to next blood object
        PoolManager.poolInstance.bloodID_Int++;
        #endregion

        #region Decrease Health
        //if zombie health is less than 0
        if (zombieHealth <= 0) 
        {
            //dsiable navmesh agent
            _navAgent.enabled = false;
            //play zombie death animation
            _meshAnimsBase.Play("Z_FallingBack");
            this.gameObject.tag = "DeadEnemy";
            //disable enemy script
            this.enabled = false;
        }
        #endregion

        if(deactivateObject == true) 
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Damage(float amount, RaycastHit effect, bool deactivateObjectInstant)
    {
        DamageReceiver(amount, effect, deactivateObjectInstant);
    }
}
