using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeableFace : MonoBehaviour
{
    GameObject currentPosePrefab;
    GameObject poseObj;

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
}
