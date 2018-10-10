using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ImageImporter: ICSVReader<Sprite>
{
    private readonly Sprite[] _images;
    
    public ImageImporter()
    {
       _images = Resources.LoadAll<Sprite>("GalleryImages");
    }

    public List<Sprite> GetList()
    {
        return _images.ToList();
    }
}
