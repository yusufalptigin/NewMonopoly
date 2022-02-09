using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;
using Image = UnityEngine.UI.Image;

public class PropertyImageReset : MonoBehaviour
{
    // Start is called before the first frame update
    public Image[] allImages;
    
    
    public void ImageReset()
    {
        foreach (Image img in allImages)
        {
            img.DOFade(0, 0.1f);
        }
    }
}
