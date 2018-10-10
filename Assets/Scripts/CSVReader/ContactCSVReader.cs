using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ContactCSVReader
{	
	private readonly List<ContactModel> _contactList = new List<ContactModel>();

	public ContactCSVReader()
	{
		TextAsset contacts = Resources.Load<TextAsset>("CSVFiles/Contacts");
		
		string[] contactList = contacts.text.Split(new char[] {'\n'});

		//google c# utility csvreader -> in eine klasse ?
		
		for (var i = 0; i < contactList.Length-1; i++)
		{
			string[] contact = contactList[i].Split(new char[] {','});
			ContactModel contactModel = new ContactModel();
			
			contactModel.Id = contact[0];
			contactModel.Surname = contact[1];
			contactModel.Name = contact[2];
			contactModel.Age = contact[3];
			contactModel.EMail = contact[4];
			contactModel.Sex = contact[5];
			
			_contactList.Add(contactModel);
		}
		
		ReadMessages();
	}

	private void ReadMessages()
	{
		var messageCsvReader = new MessageCSVReader();
		SetMessages(messageCsvReader.GetUpdatedContacts());
	}

	public List<ContactModel> GetModelList()
	{
		return _contactList;
	}

	private void SetMessages(Dictionary<string, string[]> messages)
	{
		foreach (KeyValuePair<string, string[]> message in messages)
		{
			Debug.Log("Message Key:"  + message.Key);
			ContactModel contact = FindContact(message.Key);
			contact.Messages = message.Value.Skip(1).ToArray();
			Debug.Log(contact.Messages);
		}
	}
	
	private ContactModel FindContact(string id)
	{
		foreach (ContactModel contact in _contactList)
		{
			Debug.Log(contact.Id);
			Debug.Log(id);
			if (contact.Id.Equals(id))
			{
				return contact;
			}
		}

		Debug.Log("no such contact found");
		return null;
	}
	
}
