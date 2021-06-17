using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
#if UNITY_ANDROID //&& !UNITY_EDITOR
using UnityEngine.XR.ARCore;
#endif

[System.Serializable]
public struct AttachmentPrefabs
{
    public GameObject nosePrefab;
    public GameObject foreheadLeftPrefab;
    public GameObject foreheadRightPrefab;
}

public class FaceRegionAttachmentsX : MonoBehaviour
{
    [SerializeField] ARFaceManager faceManager;
    [SerializeField] AttachmentPrefabs[] attachmentPrefabs;

    // only allow one of each 
    GameObject noseObj;
    GameObject foreheadLeftObj;
    GameObject foreheadRightObj;

#if UNITY_ANDROID //&& !UNITY_EDITOR
    NativeArray<ARCoreFaceRegionData> faceRegions;
#endif

    public void Clear()
    {
        if (noseObj)
        {
            Destroy(noseObj);
            noseObj = null;
        }
        if (foreheadLeftObj)
        {
            Destroy(foreheadLeftObj);
            foreheadLeftObj = null;
        }
        if (foreheadRightObj)
        {
            Destroy(foreheadRightObj);
            foreheadRightObj = null;
        }
    }

    public void AddAttachments(int index)
    {
        Debug.Log("adding attachment " + index);

        if (index < 0 || index >= attachmentPrefabs.Length)
        {
            Debug.LogError($"index out of range: {index}");
            return;
        }
        if (attachmentPrefabs[index].nosePrefab != null)
        {
            if (noseObj) Destroy(noseObj);
            noseObj = Instantiate(attachmentPrefabs[index].nosePrefab);
        }
        if (attachmentPrefabs[index].foreheadLeftPrefab != null)
        {
            if (foreheadLeftObj) Destroy(foreheadLeftObj);
            foreheadLeftObj = Instantiate(attachmentPrefabs[index].foreheadLeftPrefab);
        }
        if (attachmentPrefabs[index].foreheadRightPrefab != null)
        {
            if (foreheadRightObj) Destroy(foreheadRightObj);
            foreheadRightObj = Instantiate(attachmentPrefabs[index].foreheadRightPrefab);
        }
    }


    void Update()
    {
        if (!noseObj && !foreheadLeftObj && !foreheadRightObj)
            return;

        if (faceManager == null)
        {
            Debug.Log("faceManager is null, enabled " + this.enabled);
            faceManager = FindObjectOfType<ARFaceManager>();
        }
#if UNITY_ANDROID //&& !UNITY_EDITOR
        var subsystem = (ARCoreFaceSubsystem)faceManager.subsystem;
        if (subsystem == null)
            return;

        foreach (ARFace face in faceManager.trackables)
        {
            //if (!face.gameObject.activeInHierarchy) continue;
            subsystem.GetRegionPoses(face.trackableId, Allocator.Persistent, ref faceRegions);
            for (int i = 0; i < faceRegions.Length; ++i)
            {
                switch (faceRegions[i].region)
                {
                    case ARCoreFaceRegion.NoseTip:
                        if (noseObj)
                        {
                            noseObj.transform.localPosition = faceRegions[i].pose.position;
                        }
                         break;
                    case ARCoreFaceRegion.ForeheadLeft:
                        if (foreheadLeftObj)
                        {
                            foreheadLeftObj.transform.localPosition = faceRegions[i].pose.position;
                        }

                        break;
                    case ARCoreFaceRegion.ForeheadRight:
                        if (foreheadRightObj)
                        {
                            foreheadRightObj.transform.localPosition = faceRegions[i].pose.position;
                        }
                        break;
                }
            }
            break; // only one
        }
#endif
    }

    void OnDestroy()
    {
#if UNITY_ANDROID //&& !UNITY_EDITOR
        if (faceRegions.IsCreated)
            faceRegions.Dispose();
#endif
    }
}