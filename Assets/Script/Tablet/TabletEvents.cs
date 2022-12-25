using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class TabletEvents : MonoBehaviour
{
    [Header("Tablet Section info")]
    public GameObject minimap_Sec; //declare gameobject for minimap section
    public GameObject flare_Sec;//declare gameobject for flare section
    
    [Header("Flare Info")]
    public GameObject flare_G; // declare gameobject for flare to spawn
    public GameObject flareTouchScreen; //declare gameobject for flare touch screen
    public GameObject flareCoolDown; //declare gameobject for flare cool down screen
    
    public void MinimapActivate()
    {
        //activate minimap section
        minimap_Sec.SetActive(true);
        //deactivate flare section
        flare_Sec.SetActive(false);
        
    }

    public void FlareActivate()
    {
        //deactivate minimap section
        minimap_Sec.SetActive(false);
        //activate flare section
        flare_Sec.SetActive(true);
    }

    public void SpawnFlare()
    {
        //if object to spawn does exist
        if(flare_G!=null)
        {
            //spawn it
            Instantiate(flare_G,this.transform.position,Quaternion.identity);
        }
        //deactivate flare touch screen
        flareTouchScreen.SetActive(false);
        //activate flare cooldown
        flareCoolDown.SetActive(true);
    }
}
