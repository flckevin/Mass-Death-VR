using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/***************************************
 * Authour: HAN 18080038
 * Object hold: sniper rifle
 * Content: sniper rifle behaviour
 **************************************/
public class SniperGunBehaviour : GunBehaviour
{
    [Header("Sniper gun info")]
    public Camera sniperCam; // sniper camera
    public RawImage scope;// sniper scope
    private RenderTexture rendTex;//sniper scope render texture

    public override void Start()
    {
        //create new texture
        if(sniperCam != null && scope != null)
        {
            //create new texture
            rendTex = new RenderTexture(100,100,16,RenderTextureFormat.Default);
            //apply to scope and cam
            sniperCam.targetTexture = rendTex;
            scope.texture = rendTex;
        }
        
        base.Start();
    }


    //function to activate sniper cam
    public void SniperCamEnabler(bool activation)
    {
        //enable sniper cam
        sniperCam.enabled = activation;
    }
}
