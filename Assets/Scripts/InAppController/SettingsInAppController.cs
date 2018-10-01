using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Experimental.UIElements.StyleEnums;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsInAppController : MonoBehaviour {

    //maybe get rid of mono through scriptable objects from Importer/AppController
	
    public void Start()
    {
        //Load Data
    }

    public void Exit()
    {
        SceneManager.UnloadSceneAsync(this.gameObject.scene);
        AppController.Instance.BackToMainMenu();
    }

}
