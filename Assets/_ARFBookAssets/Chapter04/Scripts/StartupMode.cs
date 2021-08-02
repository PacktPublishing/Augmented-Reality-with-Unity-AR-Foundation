using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class StartupMode : MonoBehaviour
{
    [SerializeField] string nextMode = "Scan";

     void OnEnable()
    {
        UIController.ShowUI("Startup");
    }

    void Update()
    {
        if (ARSession.state == ARSessionState.Unsupported)
        {
            InteractionController.EnableMode("NonAR");
        }
        else if (ARSession.state >= ARSessionState.Ready)
        {
            //Debug.Log("state " + ARSession.state);
            InteractionController.EnableMode(nextMode);
        }
    }
}
