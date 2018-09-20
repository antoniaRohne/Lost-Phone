using App;
using UnityEditor;
using UnityEngine;

public class AppName: MonoBehaviour {

	private AppConfigurations _app;

	public void SetApp(AppConfigurations app){
		this._app = app;
	}

	public void GetLoaded(){
		AppController.Instance.LoadScene(_app);
	}
}
