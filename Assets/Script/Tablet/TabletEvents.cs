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
    [Header("Flare Info")]
    public GameObject flareSpawn_G;
    public GameObject flareWarningScreen;
    public float flareDelay;
    public Transform falreSpawnPos;
    private float _defaultFlareDelay;
    private bool _ableToSpawn;

    private void Start() 
    {
        _defaultFlareDelay = flareDelay;
    }
   
    public void SpawnFlare()
    {
        //if object to spawn does exist
        if(flareSpawn_G!=null && _ableToSpawn == true)
        {
            _ableToSpawn = false;
            flareDelay = _defaultFlareDelay;
            //spawn it
            Instantiate(flareSpawn_G,falreSpawnPos.localPosition,Quaternion.identity);
            StartCoroutine(FlareDelay());
        }
        else // not able to spawn flare
        {
            //if not able to spawn flare
            if(flareWarningScreen == null || flareWarningScreen.activeSelf == true) return;
            StartCoroutine(FlareWarningScreen());
        }
        
    }

    IEnumerator FlareWarningScreen()
    {
        flareWarningScreen.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        flareWarningScreen.SetActive(false);
    }

    IEnumerator FlareDelay()
    {
        while(flareDelay > 0)
        {
            flareDelay -= 1 *Time.deltaTime;
            yield return null;
        }

        _ableToSpawn = true;

    }
}
