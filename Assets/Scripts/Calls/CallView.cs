using UnityEngine;
using UnityEngine.UI;

public class CallView : MonoBehaviour
{

	[SerializeField] private Text _caller;
	[SerializeField] private Text _time;
	[SerializeField] private Text _amount;

	public string Caller
	{
		set {_caller.text = value;}
	}

	public string Time
	{
		set{_time.text = value;}
	}

	public int Amount
	{
		set {_amount.text = value.ToString();} 
	}
}
