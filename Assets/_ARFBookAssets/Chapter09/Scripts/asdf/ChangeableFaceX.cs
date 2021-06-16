using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;

//[System.Serializable]
//public class FaceObjectbDictionary : SerializableDictionaryBase<string, GameObject> { }

// this version has dict of sub gameobjects that switch -- doesnt work ??
// ref: 

public class ChangeableFaceX : MonoBehaviour
{
    [SerializeField] string defaultFaceName;
    [SerializeField] FaceObjectbDictionary faces;

    void Start()
    {
        ResetFaces();
        faces[defaultFaceName].SetActive(true);
    }

    public void ChangeMaterial(Material mat)
    {
        faces[defaultFaceName].GetComponent<Renderer>().material = mat;
    }



    public void ChangeFace(string name = "")
    {
        ResetFaces();
        if (string.IsNullOrEmpty(name))
        {
            faces[defaultFaceName].SetActive(true);
        }
        else if (faces[name])
        {
            faces[name].SetActive(true);
        }
        else
        {
            Debug.LogError($"Face name {name} not in dictionary");
        }
    }

    private void ResetFaces()
    {
        foreach (GameObject face in faces.Values)
        {
            face.SetActive(false);
        }
    }
}
