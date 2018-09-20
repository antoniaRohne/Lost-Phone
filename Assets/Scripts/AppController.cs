using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using App;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.Audio.Google;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AppController : MonoBehaviour {

	//Prefabs
	[SerializeField]
	private GameObject _appIconPrefab;
	
	[SerializeField]
	private GameObject _pushNotificationPrefab;
	
	[SerializeField]
	private GameObject _unlockPanelPrefab;

	[SerializeField]
	private GameObject _appsGrid;

	[SerializeField]
	private GameObject _mainScreenObjects;
	
	[SerializeField]
	private ListObject<AppConfigurations> _appListObject;
	
	[SerializeField]
	private ListObject<GameObject> _prefabListObject;

	[SerializeField] private DateTime _starttime;

	public TimerModel Timer;
	
	public EventFactory EventFactory = new EventFactory();
	private Importer _importer;

	private List<ContactModel> _contacts;
	
	public static AppController Instance = null;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
	    
	    //Setup
	    _starttime = new DateTime(2018, 09, 22, 12, 24, 0);
	    Timer = new TimerModel(_starttime);
		 _importer = new Importer(_appListObject.GetList());
    }

	void Start()
	{
		//Load Sprites
		foreach(var app in (AppEnum[]) Enum.GetValues(typeof(AppEnum)))
		{
			var g = Instantiate(_appIconPrefab, _appsGrid.transform);
			g.GetComponent<AppName>().SetApp(_importer.GetAppConfigs(app));
			g.GetComponent<Image>().sprite = _importer.GetIcon(app);
		}

		//Events
		EventFactory.CreateEvent("Calendar", Timer.Time.Value.AddMinutes(2), Timer, _pushNotificationPrefab, _importer.GetAppConfigs(AppEnum.Calendar));
		
	}

	public void LoadScene(AppConfigurations app){
		if (app.LockingState)
		{
			Instantiate(_unlockPanelPrefab);
		}
		else
		{
			var operation = SceneManager.LoadSceneAsync(app.Scene.name,LoadSceneMode.Additive);
		
			operation.completed += _=>
			{
				SceneManager.SetActiveScene(SceneManager.GetSceneByName(app.Scene.name));
			};
		
			_mainScreenObjects.SetActive(false);
		}
		
	}

	public void BackToMainMenu(){
		_mainScreenObjects.SetActive(true);
	}
	
}


