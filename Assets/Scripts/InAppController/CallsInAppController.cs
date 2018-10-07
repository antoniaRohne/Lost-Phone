using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CallsInAppController : MonoBehaviour
{
	private ICSVReader<Call> _csvReader;
	[SerializeField] public GameObject _callPrefab;
	[SerializeField] private GameObject _parent;
	public void Start()
	{
		_csvReader = new CallCSVReader();
		LoadContent();
	}

	public void LoadContent()
	{
		var calls = _csvReader.GetList();
		int x = 0;
		foreach (Call call in calls)
		{
			GameObject callsGameObject = Instantiate(_callPrefab, _parent.transform);
			var view = callsGameObject.GetComponent<CallView>();
			view.Caller = call.Caller;
			view.Time = call.CallTime;
			view.Amount = call.AmountOfCalls;
		}
	}
	
	public void Exit()
	{
		SceneManager.UnloadSceneAsync(this.gameObject.scene);
		AppController.Instance.BackToMainMenu();
	}
}
