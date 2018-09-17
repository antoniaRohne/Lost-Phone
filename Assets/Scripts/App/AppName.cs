using UnityEditor;
using UnityEngine;

public class AppName: MonoBehaviour {

	private SceneAsset _scene;

	public void SetSceneName(SceneAsset scene){
		_scene = scene;
	}

	public void GetLoaded(){
		AppController.Instance.LoadScene(_scene);
	}
}
