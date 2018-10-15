using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CSVReader;

public class CalendarInAppController : MonoBehaviour
{
	private CalendarCSVReader _csvReader;
	[SerializeField] private List<GameObject> _days;
	[SerializeField] private CalendarView _calendarPrefab;
	[SerializeField] private GameObject _parent;

	private void Start()
	{
		_csvReader = new CalendarCSVReader();
		LoadContent();
	}
	
	private void LoadContent()
	{
		var calendarEntries = _csvReader.GetList();
		foreach (CalendarEntry entry in calendarEntries)
		{
			_days[entry.Day-1].SetActive(true);
		}
	}
	
	public void Exit()
	{
		SceneManager.UnloadSceneAsync(this.gameObject.scene);
		AppController.Instance.BackToMainMenu();
	}

	public void ButtonOnClick(CalendarEntry entry)
	{
		CalendarView view = Instantiate(_calendarPrefab, _parent.transform);
		view.Entry = entry;
	}
}
