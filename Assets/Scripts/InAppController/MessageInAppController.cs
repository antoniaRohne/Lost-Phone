using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MessageInAppController : MonoBehaviour,InAppController {
	
	private void Start()
	{
		//Load Contact Data
		//_csvReader = new ContactCSVReader();
		LoadContent();
	}

	public void Exit()
	{
		SceneManager.UnloadSceneAsync(this.gameObject.scene);
		AppController.Instance.BackToMainMenu();
	}


	public void LoadContent()
	{
		throw new System.NotImplementedException();
	}
}
