using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
/***************************************
 * Authour: HAN
 * Object hold:
 * Content:
 **************************************/
public static class LoadScene 
{
    public enum Scene 
    { 
        Level,
        PlayerHub,
        Tutorial,
        LoadingScreen,
    
    }

    private static Action onLoaderCallBack;

    public static void Load(Scene scene) 
    {

        onLoaderCallBack = () => { SceneManager.LoadScene(scene.ToString()); };

        SceneManager.LoadScene(Scene.LoadingScreen.ToString());
    }

    public static void LoaderCallBack() 
    {
        if (onLoaderCallBack != null) 
        {
            onLoaderCallBack();
            onLoaderCallBack = null;
        }
    }
}
