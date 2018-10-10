using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ContactView : MonoBehaviour
{
	[SerializeField]
	private Text _surname;

	private ContactModel _contact;
	
	public ContactModel Contact
	{
		get { return _contact; }
		set { _contact = value;
			_surname.text = value.Surname;
		}
	}
	
	public void OnClick()
	{
		GameObject.Find("InAppController").GetComponent<ContactController>().ButtonOnClick(_contact);

	}
	
}
