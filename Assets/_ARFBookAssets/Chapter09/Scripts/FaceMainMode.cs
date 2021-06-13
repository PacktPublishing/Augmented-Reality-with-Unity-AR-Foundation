using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FaceMainMode : MonoBehaviour
{
    [SerializeField] GameObject materialzeablePrefab; // eg AR Default Prefab
    [SerializeField] ARFaceManager faceManager;

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

    //IEnumerator _DoChangeFacePrefab(GameObject prefab)
    //{
    //    faceManager.facePrefab = prefab;
    //    //faceManager.enabled = false;
    //    faceManager.gameObject.SetActive(false);
    //    yield return null;
    //    //faceManager.enabled = true;
    //    faceManager.gameObject.SetActive(true);
    //}

    //public void ChangeFacePrefab(GameObject prefab)
    //{
    //    foreach (ARFace trackable in faceManager.trackables)
    //    {
    //        for (int i = trackable.transform.childCount - 1; i >= 0; i--)
    //        {
    //            GameObject.Destroy(trackable.transform.GetChild(i).gameObject);
    //        }
    //        GameObject newFace = Instantiate(prefab);
    //        prefab.transform.SetParent(trackable.transform);
    //    }
    //}

    IEnumerator _DoChangeFacePrefab(GameObject prefab, Material mat = null)
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
    }

 
    //public void ChangeFaceObject(string name)
    //{
    //    foreach (ARFace trackable in faceManager.trackables)
    //    {
    //        ChangeableFace changeable = trackable.GetComponent<ChangeableFace>();
    //        changeable.ChangeFace(name);
    //    }
    //}
}
