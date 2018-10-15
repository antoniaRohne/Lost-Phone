using UnityEngine;

namespace CSVReader
{
    public class ImageImporter: CSVReader<Sprite>
    {
    
        public ImageImporter():base(){}

        protected override void GetContent()
        {
            Sprite[] _images = Resources.LoadAll<Sprite>("GalleryImages");
            foreach (Sprite s in _images)
            {
                Data.Add(s);
            }
        }
    }
}
