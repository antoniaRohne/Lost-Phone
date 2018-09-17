using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContactController :  MonoBehaviour, InAppController
{

	private ContactCSVReader _csvReader;

	[SerializeField] private GameObject _contact;
	
	public void Start()
	{
		//Load Contact Data
		_csvReader = new ContactCSVReader();
		LoadContent();
	}

	public void Exit()
	{
		SceneManager.UnloadSceneAsync(this.gameObject.scene);
		AppController.Instance.BackToMainMenu();
	}

	public void LoadContent()
	{
		var contacts = _csvReader.GetModelList();
		int x = 0;
		foreach (ContactModel contact in contacts)
		{
			GameObject contactGameObject = Instantiate(_contact, GameObject.Find("Content").transform);
			var view = contactGameObject.GetComponent<ContactView>();
			view.Surname = contact.Surname;
			view.Name = contact.Name;
		}
	}
}
