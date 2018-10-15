using CSVReader;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CallsInAppController : MonoBehaviour
{
	private CallCSVReader _csvReader;
	[SerializeField] private CallView _callPrefab;
	[SerializeField] private GameObject _parent;
	
	public void Start()
	{
		_csvReader = new CallCSVReader();
		LoadContent();
	}

	private void LoadContent()
	{
		var calls = _csvReader.GetList();
		foreach (Call call in calls)
		{
			CallView callsGameObject = Instantiate(_callPrefab, _parent.transform);
			callsGameObject.Caller = call.Caller;
			callsGameObject.Time = call.CallTime;
			callsGameObject.Amount = call.AmountOfCalls;
		}
	}
	
	public void Exit()
	{
		SceneManager.UnloadSceneAsync(this.gameObject.scene);
		AppController.Instance.BackToMainMenu();
	}
}
