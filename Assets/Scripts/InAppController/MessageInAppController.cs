using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MessageInAppController : MonoBehaviour,IInAppController
{
	private ContactCSVReader _csvContactReader;
	[SerializeField] private ContactView _contact;
	[SerializeField] private GameObject _contactParent;
	[SerializeField] private GameObject _messagePanelParent;
	[SerializeField] private GameObject _messagePanel;
	[SerializeField] private GameObject _message;
	
	private void Start()
	{
		//Load Contact Data
		_csvContactReader = new ContactCSVReader();
		LoadContent();
	}

	public void Exit()
	{
		SceneManager.UnloadSceneAsync(this.gameObject.scene);
		AppController.Instance.BackToMainMenu();
	}


	public void LoadContent()
	{
		var contacts = _csvContactReader.GetModelList();
		foreach (ContactModel contact in contacts)
		{
			ContactView contactGameObject = Instantiate(_contact, _contactParent.transform);
			contactGameObject.Contact = contact;
		}
	}

	public void ButtonOnClick(ContactModel c)
	{
		GameObject panel = Instantiate(_messagePanel, _messagePanelParent.transform);
		for(var i = 0; i<c.Messages.Length;i++){
			Instantiate(_message, panel.transform);
			string message = c.Messages[c.Messages.Length-1-i];
			string[] messageIndicator = message.Split(new char[] {'_'});
			
			_message.GetComponentInChildren<TextMeshProUGUI>().text = messageIndicator[1];
		}
	}
}