using App;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AppView :MonoBehaviour{

    private AppConfigurations _app;

    public void SetApp(AppConfigurations app){
        this._app = app;
    }
    
    public void SetAppIcon(Sprite icon)
    {
        GetComponent<Image>().sprite = icon;
    }

    public void GetLoaded(){
        AppController.Instance.LoadScene(_app, _app);
    }
}