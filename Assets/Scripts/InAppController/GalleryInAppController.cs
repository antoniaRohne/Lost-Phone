using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Experimental.UIElements.StyleEnums;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GalleryInAppController : MonoBehaviour {

    //maybe get rid of mono through scriptable objects from Importer/AppController

    private ImageImporter _imageImporter;
    private List<Sprite> _images;
    private int currentIndex;

    [SerializeField] private Image _currentImage;
	
    public void Start()
    {
        //Load Contact Data
        _imageImporter = new ImageImporter();
        _images = new List<Sprite>();
        currentIndex = 0;
        LoadContent();
    }

    public void Exit()
    {
        SceneManager.UnloadSceneAsync(this.gameObject.scene);
        AppController.Instance.BackToMainMenu();
    }

    private void LoadContent()
    {
        var pics = _imageImporter.GetImages();
        foreach (Sprite pic in pics)
        {
            _images.Add(pic);
        }
        _currentImage.sprite = _images[currentIndex];
    }


    public void onNext()
    {
        if(currentIndex +1 < _images.Count)
        _currentImage.sprite = _images[++currentIndex];
        //currentIndex++;
    }
    
    public void onPrevious()
    {
        if (currentIndex - 1 > 0)
        {
            _currentImage.sprite = _images[--currentIndex];
            //currentIndex--;
        }
    }
}
