using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeableFace : MonoBehaviour
{
    GameObject currentPosePrefab;
    GameObject poseObj;

    Dictionary<GameObject, GameObject> accessories = new Dictionary<GameObject, GameObject>();

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
}
