using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GalleryInAppController : MonoBehaviour {

    private ImageImporter _imageImporter;
    private List<Sprite> _images;
    private int _currentIndex;

    [SerializeField] private Image _currentImage;
	
    public void Start()
    {
        //Load Contact Data
        _imageImporter = new ImageImporter();
        _images = new List<Sprite>();
        _currentIndex = 0;
        LoadContent();
    }

    public void Exit()
    {
        SceneManager.UnloadSceneAsync(this.gameObject.scene);
        AppController.Instance.BackToMainMenu();
    }

    private void LoadContent()
    {
        var pics = _imageImporter.GetList();
        foreach (Sprite pic in pics)
        {
            _images.Add(pic);
        }
        _currentImage.sprite = _images[_currentIndex];
    }


    public void OnNext()
    {
        if(_currentIndex +1 < _images.Count)
        _currentImage.sprite = _images[++_currentIndex];
        
    }
    
    public void OnPrevious()
    {
        if (_currentIndex - 1 >= 0)
        {
            _currentImage.sprite = _images[--_currentIndex];
        }
        
    }
}
