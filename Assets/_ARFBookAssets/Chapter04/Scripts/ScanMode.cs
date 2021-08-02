using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ScanMode : MonoBehaviour
{
    [SerializeField] ARPlaneManager planeManager;

     void OnEnable()
    {
        UIController.ShowUI("Scan");
    }

    void Update()
    {
        if (planeManager.trackables.count > 0)
        {
            InteractionController.EnableMode("Main");
        }
    }
}