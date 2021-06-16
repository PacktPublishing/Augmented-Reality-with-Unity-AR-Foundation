using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FaceMainMode : MonoBehaviour
{
    [SerializeField] ARFaceManager faceManager;

    void OnEnable()
    {
        UIController.ShowUI("Main");
    }

    public void ChangePosePrefab(GameObject prefab)
    {
        foreach (ARFace face in faceManager.trackables)
        {
            ChangeableFace changeable = face.GetComponent<ChangeableFace>();
            if (changeable != null)
            {
                changeable.SetPosePrefab(prefab);
            }
        }
    }

    public void AddAccessory(GameObject prefab)
    {
        foreach (ARFace face in faceManager.trackables)
        {
            ChangeableFace changeable = face.GetComponent<ChangeableFace>();
            if (changeable != null)
            {
                changeable.AddAccessory(prefab);
            }
        }
    }

    public void ResetFace()
    {
        foreach (ARFace face in faceManager.trackables)
        {
            ChangeableFace changeable = face.GetComponent<ChangeableFace>();
            if (changeable != null)
            {
                changeable.SetPosePrefab(null);
                changeable.ResetAccessories();
            }
        }
    }
}
