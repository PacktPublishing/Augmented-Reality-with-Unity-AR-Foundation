using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCoreOnly : MonoBehaviour
{
    private void Awake()
    {
#if !UNITY_ANDROID
        gameObject.SetActive(false);
#endif
    }
}
