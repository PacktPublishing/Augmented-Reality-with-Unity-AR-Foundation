using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestInputSystem : MonoBehaviour
{
    private void Awake()
    {
        
    }
    public void OnPlaceObject(InputValue value)
    {
        Debug.Log("*** in OnPlaceObject");
    }
}