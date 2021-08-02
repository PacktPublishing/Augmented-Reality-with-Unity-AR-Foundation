using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine.XR.ARFoundation;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class PlanetPrefabDictionary : SerializableDictionaryBase<string, GameObject> { }

public class PlanetsMainMode : MonoBehaviour
{
    [SerializeField] ARTrackedImageManager imageManager;
    [SerializeField] TMP_Text planetName;
    [SerializeField] Toggle infoButton;
    [SerializeField] GameObject detailsPanel;
    [SerializeField] TMP_Text detailsText;
    [SerializeField] PlanetPrefabDictionary planetPrefabs;

    Camera camera;
    int layerMask;

    void Start()
    {
        camera = Camera.main;
        layerMask = 1 << LayerMask.NameToLayer("PlacedObjects");
    }

    void OnEnable()
    {
        UIController.ShowUI("Main");

        planetName.text = "";
        infoButton.interactable = false;
        detailsPanel.SetActive(false);

        foreach (ARTrackedImage image in imageManager.trackables)
        {
            InstantiatePlanet(image);
        }
        imageManager.trackedImagesChanged += OnTrackedImageChanged;
    }

    void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnTrackedImageChanged;
    }

    void Update()
    {
        if (imageManager.trackables.count == 0)
        {
            Debug.Log("PlanetsMainMode no trackables, going to Scan mode");
            InteractionController.EnableMode("Scan");
        }
        else
        {
            Ray ray = new Ray(camera.transform.position, camera.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Planet planet = hit.collider.GetComponentInParent<Planet>();
                planetName.text = planet.planetName;
                detailsText.text = planet.description;
                infoButton.interactable = true;
            }
            else
            {
                planetName.text = "";
                detailsText.text = "";
                infoButton.interactable = false;
            }
        }

    }

    void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage newImage in eventArgs.added)
        {
            InstantiatePlanet(newImage);
        }

        //foreach (var updatedImage in eventArgs.updated)
        //{
        //    // Handle updated event
        //    Debug.Log("updated " + updatedImage.referenceImage.name);
        //}

        //foreach (ARTrackedImage removedImage in eventArgs.removed)
        //{
        //    // Handle removed event
        //    Debug.Log("removed " + removedImage.referenceImage.name);
        //    removedImage.gameObject.DestroyAllChildren();
        //}
    }

    void InstantiatePlanet(ARTrackedImage image)
    {
        string name = image.referenceImage.name.Split('-')[0];
        if (image.transform.childCount == 0)
        {
            //Debug.Log($"adding {name}");
            GameObject planet = Instantiate(planetPrefabs[name]);
            planet.transform.SetParent(image.transform, false);
        }
        else
        {
            Debug.Log($"{name} already instantiated");
        }
    }

}