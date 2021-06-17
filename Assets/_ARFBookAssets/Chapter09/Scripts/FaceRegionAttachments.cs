using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using UnityEngine.XR.ARFoundation;
#if UNITY_ANDROID
using UnityEngine.XR.ARCore;
#endif

public class FaceRegionAttachments : MonoBehaviour
{
    ARFaceManager faceManager;
    ARFace face;

    Dictionary<ARCoreFaceRegion, GameObject> prefabs = new Dictionary<ARCoreFaceRegion, GameObject>();
    Dictionary<ARCoreFaceRegion, GameObject> objs = new Dictionary<ARCoreFaceRegion, GameObject>();

#if UNITY_ANDROID && !UNITY_EDITOR
    NativeArray<ARCoreFaceRegionData> faceRegions;
#endif

    private void Start()
    {
        faceManager = FindObjectOfType<ARFaceManager>();
        face = GetComponent<ARFace>();
    }

    public void SetRegionAttachment(ARCoreFaceRegion region, GameObject prefab)
    {
        GameObject obj;
        if (objs.TryGetValue(region, out obj))
        {
            GameObject currentPrefab = prefabs[region];
            Destroy(obj);
            prefabs.Remove(region);
            objs.Remove(region);
            if (prefab == currentPrefab)
                return;
        }

        obj = Instantiate(prefab);
        prefabs.Add(region, prefab);
        objs.Add(region, obj);
    }

    public void Reset()
    {
        foreach (ARCoreFaceRegion region in objs.Keys)
        {
            Destroy(objs[region]);
        }
        objs.Clear();
        prefabs.Clear();
    }

    private void Update()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        var subsystem = (ARCoreFaceSubsystem)faceManager.subsystem;
        if (subsystem == null)
            return;

        subsystem.GetRegionPoses(face.trackableId, Allocator.Persistent, ref faceRegions);
        for (int i = 0; i < faceRegions.Length; ++i)
        {
            GameObject obj;
            if (objs.TryGetValue(faceRegions[i].region, out obj))
            {
                obj.transform.localPosition = faceRegions[i].pose.position;
            }
        }

#endif
    }

    void OnDestroy()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (faceRegions.IsCreated)
            faceRegions.Dispose();
#endif
    }
}
