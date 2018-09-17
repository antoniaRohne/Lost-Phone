using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ContactView : MonoBehaviour
{
	[SerializeField]
	private Text _surname;
	[SerializeField]
	private Text _name;
	
	public string Surname
	{
		get { return _surname.text; }
		set { _surname.text = value; }
	}
	
	public string Name
	{
		get { return _name.text; }
		set { _name.text = value; }
	}

}
