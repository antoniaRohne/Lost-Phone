using System;
using System.Collections.Generic;
using App;
using UniRx;
using UnityEngine;
using UnityEngine.Experimental.UIElements.StyleEnums;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InternetInAppController : MonoBehaviour
{


    [SerializeField] private AppConfigurations settings;
    
    public void Start()
    {
        //Load Data
    }

    public void Exit()
    {
        SceneManager.UnloadSceneAsync(this.gameObject.scene);
        AppController.Instance.BackToMainMenu();
    }
    
    public void GoToSettings()
    {
        SceneManager.UnloadSceneAsync(this.gameObject.scene);
        AppController.Instance.LoadScene(settings);
    }

}
