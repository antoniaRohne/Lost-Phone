﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MessageInAppController : MonoBehaviour,IInAppController
{
	private ContactCSVReader _csvContactReader;
	[SerializeField] private GameObject _contact;
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
			GameObject contactGameObject = Instantiate(_contact, _contactParent.transform);
			var view = contactGameObject.GetComponent<ContactView>();
			view.Contact = contact;
		}
	}

	public void ButtonOnClick(ContactModel c)
	{
		GameObject panel = Instantiate(_messagePanel, _messagePanelParent.transform);
		for(var i = 0; i<c.Messages.Length;i++){
			var messageObject = Instantiate(_message, GameObject.Find("MessageContent").transform);
			string message = c.Messages[c.Messages.Length-1-i];
			string[] messageIndicator = message.Split(new char[] {'_'});
			
			if (messageIndicator[0] == "O")
			{
				_message.GetComponentInChildren<TextMeshProUGUI>().alignment = TextAlignmentOptions.Right;
			}
			
			_message.GetComponentInChildren<TextMeshProUGUI>().text = messageIndicator[1];
		}
	}
}