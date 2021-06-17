using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARCoreOnly : MonoBehaviour
{
    private void Awake()
    {
#if !UNITY_ANDROID
        gameObject.SetActive(false);
#endif
#if UNITY_EDITOR
        Button button = GetComponent<Button>();
        button.interactable = false;
#endif
    }
}
