using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FacePoseAttachment : MonoBehaviour
{
    [SerializeField] ARFaceManager faceManager;

    GameObject poseObj;

    public void Clear()
    {
        if (poseObj) Destroy(poseObj);
        poseObj = null;
    }

    public void SetAttachment(GameObject prefab)
    {
        if (poseObj) Destroy(poseObj);
        poseObj = Instantiate(prefab);
        foreach (ARFace face in faceManager.trackables)
        {
            if (!face.gameObject.activeInHierarchy) continue;
            poseObj.transform.SetParent(face.transform, false);
            //break; // only one
        }
    }

    private void Update()
    {
        if (!poseObj) return;

        foreach (ARFace face in faceManager.trackables)
        {
            if (!face.gameObject.activeInHierarchy) continue;
            if (poseObj.transform.parent != face.transform)
            {
                poseObj.transform.SetParent(face.transform, false);
            }
            break; // only one
        }
    }
}
