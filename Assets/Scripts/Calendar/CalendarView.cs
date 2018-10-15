using UnityEngine;
using UnityEngine.UI;

public class CalendarView : MonoBehaviour
{
	[SerializeField] private Text _day;
	[SerializeField] private Text _time;
	[SerializeField] private Text _event;

	private CalendarEntry _entry;

	[SerializeField] private CalendarInAppController _controller;

	public CalendarEntry Entry
	{
		set
		{
			_day.text = value.Day.ToString();
			_time.text = value.Time;
			_event.text = value.Event;
		}
	}

	public void OnClick()
	{
		_controller.ButtonOnClick(_entry);
	}
}
