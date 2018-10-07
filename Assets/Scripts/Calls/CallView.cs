using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CallView : MonoBehaviour
{

	[SerializeField] private Text caller;
	[SerializeField] private Text time;
	[SerializeField] private Text amount;

	public string Caller
	{
		set {caller.text = value;}
	}

	public string Time
	{
		set{time.text = value;}
	}

	public int Amount
	{
		set {amount.text = value.ToString();} 
	}
}
