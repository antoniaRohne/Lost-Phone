using System;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MemoInAppController: MonoBehaviour{

	[SerializeField] private GameObject _memo;
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

	public void LoadContent()
	{
		var memos = _csvReader.GetMemos();
		foreach (string memo in memos)
		{
			CreateMemos(memo);
		}
	}

	private void CreateMemos(string text)
	{
		GameObject Memo = GameObject.Instantiate(_memo, _parent.transform); 
		Memo.GetComponentInChildren<Text>().text = text;
	}

	public void CreateNewMemo()
	{
		GameObject Memo = GameObject.Instantiate(_memo, _parent.transform); 
		Memo.GetComponentInChildren<Text>().text = _newMemoText.text;
		_newMemoText.text = String.Empty;
	}
	
}
