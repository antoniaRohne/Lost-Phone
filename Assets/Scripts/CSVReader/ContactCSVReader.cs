using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CSVReader
{
	public class ContactCSVReader : CSVReader<ContactModel>
	{	
		public ContactCSVReader(): base(){}
	
		protected override void GetContent()
		{
			TextAsset contacts = Resources.Load<TextAsset>("CSVFiles/Contacts");
		
			string[] contactList = contacts.text.Split(new char[] {'\n'});
		
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
			
				Data.Add(contactModel);
			}
		
			ReadMessages();
		}

		private void ReadMessages()
		{
			var messageCsvReader = new MessageCSVReader();
			SetMessages(messageCsvReader.GetList());
		}

		private void SetMessages(List<string[]> messages)
		{
			foreach (string[] message in messages)
			{
				ContactModel contact = FindContact(message[0]);
				contact.Messages = message.Skip(1).ToArray();
			}
		}
	
		private ContactModel FindContact(string id)
		{
			foreach (ContactModel contact in Data)
			{
				if (contact.Id.Equals(id))
				{
					return contact;
				}
			}

			Debug.Log("no such contact found");
			return null;
		}

	
	}
}
