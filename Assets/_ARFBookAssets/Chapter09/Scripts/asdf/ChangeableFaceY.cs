using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;

[System.Serializable]
public class FaceObjectbDictionary : SerializableDictionaryBase<string, GameObject> { }

public class ChangeableFaceY : MonoBehaviour
{

    public void ChangeMaterial(Material mat)
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer)
           renderer.material = mat;
    }

}
