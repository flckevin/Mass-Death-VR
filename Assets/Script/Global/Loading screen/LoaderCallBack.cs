using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public class LoaderCallBack : MonoBehaviour
{

    public float delay;
    public BNG.ScreenFader screenFade;

    private void Start()
    {
        StartCoroutine(DelayCall());
    }

    IEnumerator DelayCall() 
    {
        yield return new WaitForSeconds(delay);
        LoadScene.LoaderCallBack();
    }
}
