using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GalleryMainMode : MonoBehaviour
{
    [SerializeField] EditPictureMode07 editMode;
    [SerializeField] SelectImageMode07 selectImage;
    Camera camera;

    void Start()
    {
        camera = Camera.main;
    }


    private void OnEnable()
    {
        UIController.ShowUI("Main");
    }

    public void OnSelectObject(InputValue value)
    {
        Vector2 touchPosition = value.Get<Vector2>();
        FindObjectToEdit(touchPosition);
    }

    void FindObjectToEdit(Vector2 touchPosition)
    {
        Ray ray = camera.ScreenPointToRay(touchPosition);
        RaycastHit hit;
        int layerMask = 1 << LayerMask.NameToLayer("PlacedObjects");
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            FramedPhoto07 picture = hit.collider.GetComponentInParent<FramedPhoto07>();
            editMode.currentPicture = picture;
            InteractionController.EnableMode("EditPicture");
        }
    }

    public void SelectImageToAdd()
    {
        selectImage.isReplacing = false;
        InteractionController.EnableMode("SelectImage");
    }
}
