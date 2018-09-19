using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MemoInAppController : MonoBehaviour, InAppController {

	//maybe get rid of mono through scriptable objects from Importer/AppController
	
	private MemoCSVReader _csvReader;

	[SerializeField] private GameObject _memo;
	[SerializeField] private Text _newMemoText;
	
	public void Start()
	{
		//Load Contact Data
		_csvReader = new MemoCSVReader();
		LoadContent();
	}

	public void Exit()
	{
		SceneManager.UnloadSceneAsync(this.gameObject.scene);
		AppController.Instance.BackToMainMenu();
	}

	public void LoadContent()
	{
		var memos = _csvReader.GetMemos();
		foreach (string memo in memos)
		{
			CreateNewMemo(memo);
		}
	}

	public void CreateNewMemo(string text) 
	{
		GameObject Memo = Instantiate(_memo, GameObject.Find("Content").transform); //monobehaviour -> get rid of find
		Memo.GetComponentInChildren<Text>().text = text;
	}
}
