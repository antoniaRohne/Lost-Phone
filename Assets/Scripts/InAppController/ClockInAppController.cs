using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClockInAppController : MonoBehaviour {

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
