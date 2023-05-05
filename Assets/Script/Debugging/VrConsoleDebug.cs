using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
/***************************************
 * Authour: HAN 18080038
 * Object hold: debug watch
 * Content: debug for VR
 **************************************/
public class VrConsoleDebug : MonoBehaviour
{
    string output = "";
    string stack = "";
    // Start is called before the first frame update
    public Text display;

    private void OnEnable() 
    {
        Application.logMessageReceived += HandeLogs;
    }

    private void OnDisable() 
    {
        Application.logMessageReceived -= HandeLogs;
        output = "";
    }

    private void HandeLogs(string _logString,string _stackTrace, LogType _logType)
    {
       output = _logString + "\n" + output;
       stack = _stackTrace;
       display.text = output;
    }


}
