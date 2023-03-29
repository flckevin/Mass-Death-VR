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
public class EnemyBase : MonoBehaviour,IDamageable
{
    [Header("Zombie Info")]
    
    
    public ZombieStats zombieStats;//scriptable object stats for zombie
    public GameObject targetChanger;

    #region zombieComponents
    [HideInInspector]public float zombieHealth;//declare float for zombie health
    [HideInInspector] public MeshAnimatorBase meshAnims;//declare mesh animator base to controll animation
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
        meshAnims = this.gameObject.GetComponent<MeshAnimatorBase>();


        //setting zombie health
        zombieHealth = zombieStats.zombieHealth;
        //setting target
        this.gameObject.transform.GetChild(0).GetComponent<TargetChanger_Base>().SetTarget();
        //set zombie speed
        navAgent.speed = zombieStats.zombieSpeed;
        
        VirtualStart();
    }

    public virtual void VirtualStart(){}
    

    //function to receive damage
    public void DamageReceiver(float damageDealt,Transform bulletPos,bool instantDeactivation)
    {
        #region Decrease Health
        //decreasing zombie health
        zombieHealth -= damageDealt;

        #region Squirt blood
        //playing blood particle
        ParticleSystemPlayer.instanceT.PlayeParticle(PoolManager.instanceT.blood[PoolManager.instanceT.bloodID],bulletPos.transform);
        //increase blood ID
        PoolManager.instanceT.bloodID++;
        #endregion

        //if zombie health is less than 0
        if (zombieHealth <= 0) 
        {
            //deactivate object
            this.gameObject.SetActive(instantDeactivation);
            //call die function
            OnDie(damageDealt*10,bulletPos);
        }
        #endregion

    }


    //funciton for zombie to die
    public virtual void OnDie(float forceToAddToRagdoll,Transform posToPush)
    {
        //disable target system
        targetChanger.SetActive(false);

        meshAnims.Play("Death_Slashed");
        
        //if nav aganet have not stop
        if(navAgent.velocity!=Vector3.zero)
        {
            //set velocity of nav agent to be 0 to stop it
            navAgent.velocity = Vector3.zero;
            //stop nav agent
            navAgent.Stop();
        }

        //dsiable navmesh agent
        navAgent.enabled = false;

        //set tag to be dead enemy
        this.gameObject.tag = "DeadEnemy";
        
    }

    //function to reveive zombie
    public void OnRevive()
    {
        //enable target system
        targetChanger.SetActive(true);

        //set back to default health
        zombieHealth = zombieStats.zombieHealth;
        
        //check whether nav agent does exist
        if(navAgent != null)
        {
            //enable navmesh agent
            navAgent.enabled = true;
        }

        //set back to default tag
        this.gameObject.tag = "Zombie";

        //call set target function
        this.gameObject.transform.GetChild(0).GetComponent<TargetChanger_Base>().SetTarget();
    }

    private void OnTriggerEnter(Collider other) 
    {
        //if bullet enter to zombie
        if(other.CompareTag("Bullet") && this.gameObject.tag == "Zombie")
        {
            //receive damage
            DamageReceiver(int.Parse(other.name),other.transform,true);
        }
    }

    void IDamageable.Damage(float amount, bool instantDeactivate)
    {
        DamageReceiver(amount,this.transform,instantDeactivate);
    }
}
