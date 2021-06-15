using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
#if UNITY_ANDROID
using UnityEngine.XR.ARCore;
#endif

public class FaceMainMode : MonoBehaviour
{
    [SerializeField] GameObject materialzeablePrefab; // eg AR Default Prefab
    [SerializeField] GameObject attachablePrefab;
    [SerializeField] ARFaceManager faceManager;

    FacePoseAttachment poseAttachment;
    FaceRegionAttachments regionAttachments;

    void Start()
    {
        poseAttachment = GetComponent<FacePoseAttachment>();
        regionAttachments = GetComponent<FaceRegionAttachments>();
    }

    void OnEnable()
    {
        UIController.ShowUI("Main");
    }

    public void ChangeFaceMaterial(Material mat)
    {
        if (faceManager.facePrefab != materialzeablePrefab)
        {
            StartCoroutine(_DoChangeFacePrefab(materialzeablePrefab, mat));
        }
        else
        {
            _ChangeTrackablesMaterial(mat);
        }
    }

    void _ChangeTrackablesMaterial(Material mat)
    {
        foreach (ARFace trackable in faceManager.trackables)
        {
            if (!trackable.gameObject.activeInHierarchy) continue;
            ChangeableFace changeable = trackable.GetComponent<ChangeableFace>();
            changeable.ChangeMaterial(mat);
        }
    }

    public void ChangeFacePrefab(GameObject prefab)
    {
        if (faceManager.facePrefab != prefab)
        {
            StartCoroutine(_DoChangeFacePrefab(prefab));
        }
    }

    IEnumerator _DoChangeFacePrefab(GameObject prefab, Material mat = null, int attachmentIndex = -1)
    {
        GameObject sessionOrigin = faceManager.gameObject;
        foreach (ARFace trackable in faceManager.trackables)
        {
            trackable.gameObject.SetActive(false);
        }
        Destroy(faceManager);
        yield return null;

        faceManager = sessionOrigin.AddComponent<ARFaceManager>() as ARFaceManager;
        faceManager.facePrefab = prefab;

        if (mat)
        {
            while (faceManager.trackables.count == 0)
            {
                yield return null;
            }
            _ChangeTrackablesMaterial(mat);
        }

        poseAttachment.Clear();

        regionAttachments.Clear();
        if (attachmentIndex >= 0)
        {
            regionAttachments.AddAttachments(attachmentIndex);
        }
    }

    public void ChangeFaceAttachment(GameObject prefab)
    {
        poseAttachment.SetAttachment(prefab);
    }

    public void ChangeRegionAttachment(int attachmentIndex)
    {
        if (faceManager.facePrefab != attachablePrefab)
        {
            StartCoroutine(_DoChangeFacePrefab(attachablePrefab, null, attachmentIndex));
        }
        else
        {
           regionAttachments.AddAttachments(attachmentIndex);
        }
    }
}
