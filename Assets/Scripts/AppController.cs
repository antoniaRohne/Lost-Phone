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
	private GameObject _appsGrid;

	[SerializeField]
	private GameObject _mainScreenObjects;
	//
	
	[SerializeField]
	private ListObject<AppConfigurations> _appListObject;
	
	[SerializeField]
	private ListObject<GameObject> _prefabListObject;

	[SerializeField] private DateTime _starttime;

	public TimerModel Timer;
	
	private readonly EventFactory _eventFactory = new EventFactory();
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
			g.GetComponent<AppName>().SetSceneName(_importer.GetScene(app));
			g.GetComponent<Image>().sprite = _importer.GetIcon(app);
		}

		//Events
		_eventFactory.CreateEvent("Calendar", Timer.Time.Value.AddMinutes(2), Timer, _pushNotificationPrefab, _importer.GetAppConfigs(AppEnum.Calendar));
		
	}

	public void LoadScene(SceneAsset scene){
		var operation = SceneManager.LoadSceneAsync(scene.name,LoadSceneMode.Additive);
		operation.completed += _=>
		{
			SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene.name));
		};				

		if (scene.name == "Messages")
		_eventFactory.CreateEvent(scene.name, Timer.Time.Value.AddMinutes(1), Timer, _pushNotificationPrefab,_importer.GetAppConfigs(AppEnum.Messages));
		
		_mainScreenObjects.SetActive(false);
	}

	public void BackToMainMenu(){
		_mainScreenObjects.SetActive(true);
	}
	
}


