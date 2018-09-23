using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MemoInAppController : MonoBehaviour, IInAppController {

	//maybe get rid of mono through scriptable objects from Importer/AppController
	
	private MemoCSVReader _csvReader;

	[SerializeField] private GameObject _memo;
	[SerializeField] private GameObject _parent;
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

	public void ButtonOnClick(ContactModel c)
	{
		throw new System.NotImplementedException();
	}


	public void CreateNewMemo(string text) 
	{
		GameObject Memo = Instantiate(_memo, _parent.transform); 
		Memo.GetComponentInChildren<Text>().text = text;
	}
}
