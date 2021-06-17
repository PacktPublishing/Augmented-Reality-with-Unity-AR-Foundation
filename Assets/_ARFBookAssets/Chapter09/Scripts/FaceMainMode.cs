using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
#if UNITY_ANDROID 
using UnityEngine.XR.ARCore;
#endif
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

    public void ChangeMaterial(Material mat)
    {
        foreach (ARFace face in faceManager.trackables)
        {
            ChangeableFace changeable = face.GetComponent<ChangeableFace>();
            if (changeable != null)
            {
                changeable.SetMeshMaterial(mat);
            }
        }
    }

    public void ResetFace()
    {
        foreach (ARFace face in faceManager.trackables)
        {
            ChangeableFace changeable = face.GetComponent<ChangeableFace>();
            FaceRegionAttachments regionAttachments = face.GetComponent<FaceRegionAttachments>();
            if (changeable != null)
            {
                changeable.SetPosePrefab(null);
                changeable.ResetAccessories();
                changeable.SetMeshMaterial(null);
                regionAttachments.Reset();
            }
        }
    }


    public void SetNoseAttachment(GameObject prefab)
    {
        SetRegionAttachment(ARCoreFaceRegion.NoseTip, prefab);
    }

    public void SetForeheadLeftAttachment(GameObject prefab)
    {
        SetRegionAttachment(ARCoreFaceRegion.ForeheadLeft, prefab);
    }

    public void SetForeheadRightAttachment(GameObject prefab)
    {
        SetRegionAttachment(ARCoreFaceRegion.ForeheadRight, prefab);
    }

    private void SetRegionAttachment(ARCoreFaceRegion region, GameObject prefab)
    {
        foreach (ARFace face in faceManager.trackables)
        {
            FaceRegionAttachments regionAttachments = face.GetComponent<FaceRegionAttachments>();
            if (regionAttachments != null)
            {
                regionAttachments.SetRegionAttachment(region, prefab);
            }
        }
    }
}
