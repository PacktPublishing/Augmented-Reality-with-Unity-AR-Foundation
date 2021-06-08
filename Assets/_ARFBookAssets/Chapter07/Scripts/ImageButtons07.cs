using UnityEngine;
using UnityEngine.UI;

public class ImageButtons07 : MonoBehaviour
{
    [SerializeField] GameObject imageButtonPrefab;
    [SerializeField] ImagesData imagesData;
    [SerializeField] SelectImageMode07 selectImage;

    void Start()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(transform.GetChild(i).gameObject);
        }

        foreach (ImageInfo image in imagesData.images)
        {
            GameObject obj = Instantiate(imageButtonPrefab, transform);
            RawImage rawimage = obj.GetComponent<RawImage>();
            rawimage.texture = image.texture;
            Button button = obj.GetComponent<Button>();
            button.onClick.AddListener(() => OnClick(image));
        }
    }

    void OnClick(ImageInfo image)
    {
        //Debug.Log($"Image clicked {image.texture.name}");
        selectImage.ImageSelected(image);
    }
}
