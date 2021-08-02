using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MovePicture : MonoBehaviour
{
    ARRaycastManager raycaster;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    Camera camera;
    int layerMask;

    void Start() {
        raycaster = FindObjectOfType<ARRaycastManager>();
        camera = Camera.main;
        layerMask = 1 << LayerMask.NameToLayer("PlacedObjects");
    }

    public void OnMoveObject(InputValue value)
    {
        if (!enabled) return;
        if (EventSystem.current.IsPointerOverGameObject(0)) return;

        Vector2 touchPosition = value.Get<Vector2>();
        MoveObject(touchPosition);
    }

    void MoveObject(Vector2 touchPosition)
    {
        Ray ray = camera.ScreenPointToRay(touchPosition);
        if (Physics.Raycast(ray, Mathf.Infinity, layerMask))
        {
            if (raycaster.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                ARRaycastHit hit = hits[0];
                Vector3 position = hit.pose.position;
                Vector3 normal = -hit.pose.up;
                Quaternion rotation = Quaternion.LookRotation(normal, Vector3.up);
                transform.position = position;
                transform.rotation = rotation;
            }
        }
    }
}
