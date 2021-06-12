using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;

[System.Serializable]
public class FaceObjectbDictionary : SerializableDictionaryBase<string, GameObject> { }

public class ChangeableFace : MonoBehaviour
{
    [SerializeField] string defaultFaceName;
    [SerializeField] FaceObjectbDictionary faces;

    void Start()
    {
        ResetFaces();
        faces[defaultFaceName].SetActive(true);
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

    public void ChangeMaterial(Material mat)
    {
        ChangeFace();
        faces[defaultFaceName].GetComponent<Renderer>().material = mat;
    }

    private void ResetFaces()
    {
        foreach (GameObject face in faces.Values)
        {
            face.SetActive(false);
        }
    }
}
