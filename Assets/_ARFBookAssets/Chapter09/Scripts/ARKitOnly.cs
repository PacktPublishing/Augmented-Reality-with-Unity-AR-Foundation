using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARKitOnly : MonoBehaviour
{
    private void Awake()
    {
#if !UNITY_IOS
        gameObject.SetActive(false);
#endif
    }
}
