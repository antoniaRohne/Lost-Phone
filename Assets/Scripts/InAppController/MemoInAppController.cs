using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MemoInAppController: MonoBehaviour{

	[SerializeField] private Image _memo;
	[SerializeField] private GameObject _parent;
	[SerializeField] private Text _newMemoText;
	
	private MemoCSVReader _csvReader;	
	
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

	private void LoadContent()
	{
		var memos = _csvReader.GetMemos();
		foreach (string memo in memos)
		{
			CreateMemos(memo);
		}
	}

	private void CreateMemos(string text)
	{
		Image memo = GameObject.Instantiate(_memo, _parent.transform); 
		memo.GetComponentInChildren<Text>().text = text;				//GetComponentinChildren
	}

	public void CreateNewMemo()
	{
		Image memo = GameObject.Instantiate(_memo, _parent.transform); 
		memo.GetComponentInChildren<Text>().text = _newMemoText.text;
		_newMemoText.text = String.Empty;
	}
	
}
