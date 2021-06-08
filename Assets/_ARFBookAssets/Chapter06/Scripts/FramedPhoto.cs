#define CHAPTER6

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramedPhoto : MonoBehaviour
{
    [SerializeField] Transform scalerObject;
    [SerializeField] GameObject imageObject;

    ImageInfo imageInfo;

    public void SetImage(ImageInfo image)
    {
        imageInfo = image;

        Renderer renderer = imageObject.GetComponent<Renderer>();
        Material material = renderer.material;
        material.SetTexture("_BaseMap", imageInfo.texture);

        AdjustScale();
    }

    public void AdjustScale()
    {
        Vector2 scale = ImagesData.AspectRatio(imageInfo.width, imageInfo.height);
        scalerObject.localScale = new Vector3(scale.x, scale.y, 1f);
    }
}
