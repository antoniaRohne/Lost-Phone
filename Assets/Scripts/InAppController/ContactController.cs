using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContactController :  MonoBehaviour, IInAppController
{

	private ContactCSVReader _csvReader;

	[SerializeField] private GameObject _contact;
	[SerializeField] private GameObject _parent;
	[SerializeField] private GameObject _infoPanel;
	[SerializeField] private GameObject _info;
	
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
			GameObject contactGameObject = Instantiate(_contact, _parent.transform);
			var view = contactGameObject.GetComponent<ContactView>();
			view.Contact = contact;
		}
	}

	public void ButtonOnClick(ContactModel contact)
	{
		GameObject infoPanel = Instantiate(_infoPanel, GameObject.Find("Canvas").transform);
		ContactPanelView view = infoPanel.GetComponent<ContactPanelView>();
		view.Surname = contact.Surname;
		view.Name = contact.Name;
		view.Age = contact.Age;
		view.EMail = contact.EMail;
		view.Sex = contact.Sex;
	}
}
