using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class Extractor : MonoBehaviour,IDamageable
{
    [Header("EXTRACTOR EXTRACTION INFO")]
    public float timeToExtract; //declare float for time to progress extraction
    public int goal;//declare int for goal to reach for extraction
    [SerializeField]private float progressed;//declare float to store progress
    [Header("EXTRACTOR INFO")]
    public float health;//declare float for health of machine
    private float deafultHealth;//declare float to store default health to display on slider
    // Start is called before the first frame update

    private void Start() 
    {
        //storing default health
        deafultHealth = health;
        //setting slider value
        GameManagerClass.instanceT.extractorHealth_UI.value = health/deafultHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //increase progress
        progressed += timeToExtract*Time.deltaTime;
        //if progress reach to goal
        if(progressed >= goal)
        {
            //set progress back to 0
            progressed = 0;
            
            Debug.Log("SPAWN SAMPLE");
            //spawn out sample
        }
        //update progress on ui
        GameManagerClass.instanceT.extractTimeLeft_UI.text = ("EXTRACTION TIME LEFT: " + Mathf.Round(progressed) + "/" + goal).ToString(); 
    }

    private void OnCollisionEnter(Collision other) 
    {
        Debug.Log(other.gameObject.name);
        //if it collide with zombie
        if(other.gameObject.CompareTag("Zombie"))
        {
            OnDamage();
        }
    }

    private void OnCollisionStay(Collision other) 
    {
        //if it collide with zombie
        if(other.gameObject.CompareTag("Zombie"))
        {
            OnDamage();
        }
    }

    private void OnDamage()
    {
        //decrease machine health
        health -= 0.5f;
        //setting slider value
        GameManagerClass.instanceT.extractorHealth_UI.value = health/deafultHealth;

        //check if health reach to 0
        //if it is
        //game over
        //set all objective target to null
        //change objective to player

        if(health <= 0)
        {
            this.gameObject.tag = "BrokenObjective";
            AudioManager.instanceT.PlayOneShot(AudioManager.instanceT.commonClip[3].clip,1);
            GameManagerClass.instanceT.modeManager.Extract();
        }
    }

    public void Damage(float amount = 0, bool instantDeactivate = false)
    {
        OnDamage();
    }
}
