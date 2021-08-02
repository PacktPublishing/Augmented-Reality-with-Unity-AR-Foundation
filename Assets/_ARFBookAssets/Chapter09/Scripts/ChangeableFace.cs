using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ChangeableFace : MonoBehaviour
{
    GameObject currentPosePrefab;
    GameObject poseObj;

    Dictionary<GameObject, GameObject> accessories = new Dictionary<GameObject, GameObject>();

    ARFaceMeshVisualizer meshVisualizer;
    MeshRenderer renderer;

    private void Start()
    {
        meshVisualizer = GetComponent<ARFaceMeshVisualizer>();
        meshVisualizer.enabled = false;
        renderer = GetComponent<MeshRenderer>();
        renderer.enabled = false;
    }

    public void SetPosePrefab(GameObject prefab)
    {
        if (prefab == currentPosePrefab)
            return;

        if (poseObj != null) 
            Destroy(poseObj);

       currentPosePrefab = prefab;
       if (prefab != null)
            poseObj = Instantiate(prefab, transform, false);
    }

    public void AddAccessory(GameObject prefab)
    {
        GameObject obj;
        if (accessories.TryGetValue(prefab, out obj) && obj.activeInHierarchy)
        {
            obj.SetActive(false);
            return;
        }
        else if (obj != null)
        {
            obj.SetActive(true);
        }
        else
        {
            obj = Instantiate(prefab, transform, false);
            accessories.Add(prefab, obj);
        }
    }

    public void ResetAccessories()
    {
        foreach (GameObject prefab in accessories.Keys)
        {
            accessories[prefab].SetActive(false);
        }
    }

    public void SetMeshMaterial(Material mat)
    {
        if (mat == null)
        {
            meshVisualizer.enabled = false;
            renderer.enabled = false;
            return;
        }

        renderer.material = mat;
        meshVisualizer.enabled = true;
        renderer.enabled = true;
    }
}
