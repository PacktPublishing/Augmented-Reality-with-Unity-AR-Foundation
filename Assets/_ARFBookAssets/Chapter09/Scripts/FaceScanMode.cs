using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FaceScanMode : MonoBehaviour
{
    [SerializeField] ARFaceManager faceManager;

    private void OnEnable()
    {
        UIController.ShowUI("Scan");
    }

    void Update()
    {
        if (faceManager.trackables.count > 0)
        {
            InteractionController.EnableMode("Main");
        }
    }
}