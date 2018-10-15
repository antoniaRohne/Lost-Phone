using System.Collections.Generic;
using CSVReader;
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
        _images = _imageImporter.GetList();
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
