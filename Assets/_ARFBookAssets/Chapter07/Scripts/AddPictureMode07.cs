using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AddPictureMode07 : MonoBehaviour
{
    [SerializeField] ARRaycastManager raycaster;
    [SerializeField] GameObject placedPrefab;
    public ImageInfo imageInfo;
    [SerializeField] float defaultScale = 0.5f;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void OnEnable()
    {
        UIController.ShowUI("AddPicture");
    }

    public void OnPlaceObject(InputValue value)
    {
        Vector2 touchPosition = value.Get<Vector2>();
        Debug.Log("OnPlaceObject " + touchPosition);
        PlaceObject(touchPosition);
    }

    void PlaceObject(Vector2 touchPosition)
    {
        if (raycaster.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            ARRaycastHit hit = hits[0];

            Vector3 position = hit.pose.position;
            Vector3 normal = -hit.pose.up;
            Quaternion rotation = Quaternion.LookRotation(normal, Vector3.up);

            GameObject spawned = Instantiate(placedPrefab, position, rotation);
            spawned.transform.SetParent(transform.parent);

            FramedPhoto07 picture = spawned.GetComponent<FramedPhoto07>();
            picture.SetImage(imageInfo);

            spawned.transform.localScale = new Vector3(defaultScale, defaultScale, 1.0f);

 
            InteractionController.EnableMode("Main");
        }
    }

}
