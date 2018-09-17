using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MemoInAppController : MonoBehaviour, InAppController {

	private MemoCSVReader _csvReader;

	[SerializeField] private GameObject _memo;
	
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
		GameObject Memo = Instantiate(_memo, GameObject.Find("Content").transform);
		Memo.GetComponentInChildren<Text>().text = text;
	}
}
