using UnityEngine;

public class SelectImageMode07 : MonoBehaviour
{
    [SerializeField] AddPictureMode07 addPicture;
    [SerializeField] EditPictureMode07 editPicture;
    public bool isReplacing = false;

    private void OnEnable()
    {
        UIController.ShowUI("SelectImage");
    }

    public void ImageSelected(ImageInfo image)
    {
        if (isReplacing)
        {
            editPicture.currentPicture.SetImage(image);
            InteractionController.EnableMode("EditPicture");
        }
        else
        {
            addPicture.imageInfo = image;
            InteractionController.EnableMode("AddPicture");
        }
    }
}
