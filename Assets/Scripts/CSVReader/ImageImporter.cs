using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ImageImporter
{
    private Sprite[] _images;
    
    public ImageImporter()
    {
       _images = Resources.LoadAll<Sprite>("GalleryImages");
    }

    public List<Sprite> GetImages()
    {
        return _images.ToList();
    }
    
}
