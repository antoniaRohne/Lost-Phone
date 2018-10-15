using CSVReader;
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
	[SerializeField] private MessageView _message;
	
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
		var contacts = _csvContactReader.GetList();
		foreach (ContactModel contact in contacts)
		{
			ContactView contactGameObject = Instantiate(_contact, _contactParent.transform);
			contactGameObject.Contact = contact;
		}
	}

	public void ButtonOnClick(ContactModel c)
	{
		Instantiate(_messagePanel, _messagePanelParent.transform);
		
		for(var i = 0; i<c.Messages.Length;i++){
			
			MessageView messageView = Instantiate(_message, GameObject.Find("MessageContent").transform); //GameObjectFind
			
			string message = c.Messages[i];
			string[] messageIndicator = message.Split(new char[] {'_'});
			
			messageView.MessageText.text= messageIndicator[1];
			if (messageIndicator[0] == "O")
			{
				messageView.setAlignmentToRight();
			}
		}
	}
}