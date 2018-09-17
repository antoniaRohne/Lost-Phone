using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactCSVReader
{	
	private List<ContactModel> ContactList = new List<ContactModel>();
	
	public ContactCSVReader()
	{
		TextAsset _contacts = Resources.Load<TextAsset>("CSVFiles/Contacts");
		
		string[] contactList = _contacts.text.Split(new char[] {'\n'});

		for (var i = 1; i < contactList.Length; i++)
		{
			string[] contact = contactList[i].Split(new char[] {','});
			ContactModel contactModel = new ContactModel();
			contactModel.Id = Convert.ToInt32(contact[0]);
			contactModel.Surname = contact[1];
			contactModel.Name = contact[2];
			
			ContactList.Add(contactModel);
		}
	}

	public List<ContactModel> GetModelList()
	{
		return ContactList;
	}
	
}
