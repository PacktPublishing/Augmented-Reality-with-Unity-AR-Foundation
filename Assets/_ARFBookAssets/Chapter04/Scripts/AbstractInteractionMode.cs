using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInteractionMode : MonoBehaviour
{
    [SerializeField] string uiPanelName;

    protected virtual void Start()
    {
        Setup();
    }

    protected virtual void OnEnable()
    {
        Setup();
    }

    protected virtual void Setup()
    {
        if (!string.IsNullOrEmpty(uiPanelName))
        {
            UIController.ShowUI(uiPanelName);
        }
    }
}


