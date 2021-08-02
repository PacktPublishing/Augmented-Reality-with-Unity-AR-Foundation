using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditPictureMode07 : MonoBehaviour
{
    public FramedPhoto07 currentPicture;
    [SerializeField] SelectImageMode07 selectImage;
    Camera camera;

    void Start()
    {
        camera = Camera.main;
    }

    private void OnEnable()
    {
        UIController.ShowUI("EditPicture");
        if (currentPicture)
            currentPicture.BeingEdited(true);
    }

    void OnDisable()
    {
        if (currentPicture)
            currentPicture.BeingEdited(false);
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
        if (Physics.Raycast(ray, out hit, 50f, layerMask))
        {
            if (hit.collider.gameObject != currentPicture.gameObject)
            {
                currentPicture.BeingEdited(false);
                FramedPhoto07 picture = hit.collider.GetComponentInParent<FramedPhoto07>();
                currentPicture = picture;
                picture.BeingEdited(true);
            }
        }
    }

    public void DeletePicture()
    {
        GameObject.Destroy(currentPicture.gameObject);
        InteractionController.EnableMode("Main");
    }

    public void SelectImageToReplace()
    {
        selectImage.isReplacing = true;
        InteractionController.EnableMode("SelectImage");
    }
}
