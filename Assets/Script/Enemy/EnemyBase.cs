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
    public TargetChanger_Base targetChanger;
    public string[]deathAnimations;
    #region zombieComponents
    [HideInInspector]public float zombieHealth;//declare float for zombie health
    [HideInInspector] public MeshAnimatorBase meshAnims;//declare mesh animator base to controll animation
    [HideInInspector] public NavMeshAgent navAgent;//declare nav mesh agent to chase to target

    protected IZombieStateBase _State;//declare zombie state interface to change state of zombie
    protected string _currentState; //declare current state to identify which state zombie current in
    
    
    #endregion

    // Start is called before the first frame update

    private void Awake() 
    {
        //storing navmesh agent class into this class
        navAgent = this.gameObject.GetComponent<NavMeshAgent>();
        //storing meshanimatorbase class into this class
        meshAnims = this.gameObject.GetComponent<MeshAnimatorBase>();
        
        //setting zombie health
        zombieHealth = zombieStats.zombieHealth;
        //setting target
        //this.gameObject.transform.GetChild(0).GetComponent<TargetChanger_Base>().SetTarget();
        //set zombie speed
        navAgent.speed = zombieStats.zombieSpeed;
        //deactivate object
        this.gameObject.SetActive(false);
        VirtualAwake();
    }

    public virtual void VirtualAwake(){}
    

    //function to receive damage
    public void DamageReceiver(float damageDealt,Vector3 bulletPosNMelee,bool instantDeactivation)
    {
        
        #region Decrease Health
        //decreasing zombie health
        zombieHealth -= damageDealt;
        //play audio clip
        AudioManager.instanceT.PlayOneShot(AudioManager.instanceT.commonClip[0].clip,1);
        #region Squirt blood
        //declare pool manager
        PoolManager poolM = PoolManager.instanceT;
        //if pool manager exceed pool blood length
        
        //playing blood particle
        poolM.blood[poolM.BloodID].transform.position = bulletPosNMelee;
        poolM.blood[poolM.BloodID].gameObject.SetActive(true);
        poolM.blood[poolM.BloodID].Play();
        #endregion

        //if zombie health is less than 0
        if (zombieHealth <= 0) 
        {
            //deactivate object
            //this.gameObject.SetActive(instantDeactivation);
            //call die function
            OnDie(bulletPosNMelee);
        }
        #endregion

    }


    //funciton for zombie to die
    public virtual void OnDie(Vector3 bulletPos)
    {
        //play money particle
        PoolManager poolM = PoolManager.instanceT;
        poolM.money[poolM.MoneyID].transform.position = bulletPos;
        poolM.money[poolM.MoneyID].gameObject.SetActive(true);
        poolM.money[poolM.MoneyID].Play();
        //play audio clip
        AudioManager.instanceT.PlayOneShot(AudioManager.instanceT.commonClip[1].clip,1);
        //set tag to be dead enemy
        this.gameObject.tag = "DeadEnemy";
        //disable target system
        targetChanger.gameObject.SetActive(false);

        //play death animation
        int _rand = UnityEngine.Random.Range(0,deathAnimations.Length);
        meshAnims.Play(deathAnimations[_rand]);
        
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

        
        //call zombie on kill event
        GameManagerClass.instanceT.waveMode.ZombieOnKill();
        //add more money to player
        GameManagerClass.instanceT.playerCreditCard_Class.moneyAmount += zombieStats.moneyReceive;
        //deactivate zombie corpse
        StartCoroutine(OnDeactivation(2));
    }

    IEnumerator OnDeactivation(float _time = 0)
    {
        yield return new WaitForSeconds(_time);
        this.gameObject.SetActive(false);
    }

    //function to reveive zombie
    public virtual void OnRevive()
    {
        //enable target system
        targetChanger.gameObject.SetActive(true);

        //set back to default health
        zombieHealth = zombieStats.zombieHealth;

        //enable navmesh agent
        navAgent.enabled = true;
        

        //set back to default tag
        this.gameObject.tag = "Zombie";

        
    }

    private void OnTriggerEnter(Collider other) 
    {
        //if zombie not alive
        if(this.gameObject.tag != "Zombie") return;

        //if bullet enter to zombie
        if(other.CompareTag("Bullet"))
        {
            //get bullet behaviour
            BulletBehaviour bullet = other.GetComponent<BulletBehaviour>();
            //receive damage
            DamageReceiver(bullet.damage,other.transform.position,false);
            bullet.OnCollision();
          
        }
        //if it melee
        else if(other.CompareTag("Melee"))
        {
            DamageReceiver(int.Parse(other.name),other.transform.position,false);
        }
        
        
    }

    private void OnTriggerStay(Collider other) 
    {
         //if zombie not alive
        if(this.gameObject.tag != "Zombie") return;

        //if bullet enter to zombie
        if(other.CompareTag("Bullet"))
        {
            //get bullet behaviour
            BulletBehaviour bullet = other.GetComponent<BulletBehaviour>();
            //receive damage
            DamageReceiver(bullet.damage,other.transform.position,false);
            bullet.OnCollision();
          
        }
        //if it melee
        else if(other.CompareTag("Melee"))
        {
            DamageReceiver(int.Parse(other.name),other.transform.position,false);
        }
    }


    void IDamageable.Damage(float amount, bool instantDeactivate)
    {
        DamageReceiver(amount,this.transform.position,instantDeactivate);
    }
}
