using UnityEngine;
using UnityEngine.SceneManagement;

public class ContactController :  MonoBehaviour, IInAppController
{

	private ContactCSVReader _csvReader;

	[SerializeField] private ContactView _contact;
	[SerializeField] private GameObject _parent;
	[SerializeField] private ContactPanelView _infoPanel;
	
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
		foreach (ContactModel contact in contacts)
		{
			ContactView contactGameObject = Instantiate(_contact, _parent.transform);
			contactGameObject.Contact = contact;
		}
	}

	public void ButtonOnClick(ContactModel contact)
	{
		ContactPanelView infoPanel = Instantiate(_infoPanel, _parent.transform);
		infoPanel.Surname = contact.Surname;
		infoPanel.Name = contact.Name;
		infoPanel.Age = contact.Age;
		infoPanel.EMail = contact.EMail;
		infoPanel.Sex = contact.Sex;
	}
}
