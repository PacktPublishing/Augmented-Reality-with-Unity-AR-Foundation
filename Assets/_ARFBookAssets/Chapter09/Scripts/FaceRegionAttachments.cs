using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
#if UNITY_ANDROID
using UnityEngine.XR.ARCore;
#endif

public class FaceRegionAttachments : MonoBehaviour
{
    public GameObject nosetipPrefab;
    public GameObject foreheadLeftPrefab;
    public GameObject foreheadRightPrefab;
    [SerializeField] ARFaceManager faceManager;

    GameObject nosetipObj;
    GameObject foreheadLeftObj;
    GameObject foreheadRightObj;

#if UNITY_ANDROID
    NativeArray<ARCoreFaceRegionData> faceRegions;
#endif

    private void Start()
    {
        Refresh();
    }

    public void Clear()
    {
        Destroy(nosetipObj);
        nosetipObj = null;
        Destroy(foreheadLeftObj);
        foreheadLeftObj = null;
        Destroy(foreheadRightObj);
        foreheadRightObj = null;
    }

    public void Refresh()
    {
        Clear();
        if (nosetipPrefab)
        {
            nosetipObj = Instantiate(nosetipPrefab);
        }
        if (foreheadLeftPrefab)
        {
            foreheadLeftObj = Instantiate(foreheadLeftPrefab);
        }
        if (foreheadRightPrefab)
        {
            foreheadRightObj = Instantiate(foreheadRightPrefab);
        }
    }

    void Update()
    {
#if UNITY_ANDROID
        var subsystem = (ARCoreFaceSubsystem)faceManager.subsystem;
        if (subsystem == null)
            return;

        foreach (ARFace face in faceManager.trackables)
        {
            subsystem.GetRegionPoses(face.trackableId, Allocator.Persistent, ref faceRegions);
            for (int i = 0; i < faceRegions.Length; ++i)
            {
                switch (faceRegions[i].region)
                {
                    case ARCoreFaceRegion.NoseTip:
                        if (nosetipObj)
                        {
                            nosetipObj.transform.localPosition = faceRegions[i].pose.position;
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
        }
#endif
    }

    void OnDestroy()
    {
#if UNITY_ANDROID
        if (faceRegions.IsCreated)
            faceRegions.Dispose();
#endif
    }
}