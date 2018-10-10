using System;
using App;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppController : MonoBehaviour {

	[SerializeField]
	private GameObject _appsGrid;
	
	[SerializeField]
	private GameObject _canvas;

	[SerializeField]
	private GameObject _mainScreenObjects;
	
	[SerializeField]
	private ListObject _appListObject;
	
	[SerializeField]
	private PrefabList _prefabListObject;

	[SerializeField] private DateTime _starttime;

	public TimerModel Timer;
	private Importer _importer;
	private readonly PasswordController _passwordController = new PasswordController();
	
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
			AppView g = Instantiate(_prefabListObject.AppPrefab, _appsGrid.transform).GetComponent<AppView>();
			g.SetAppIcon(_importer.GetIcon(app));
			g.SetApp(_importer.GetAppConfigs(app));  
		}

		//Events
		new EventModel(Timer.Time.Value.AddMinutes(2), Timer, _prefabListObject.EventPrefab, _importer.GetAppConfigs(AppEnum.Calendar), _canvas);
	}

	public void LoadScene(IAppSceneLoading app, IAppLockingSystem lockingApp)
	{
		if(!_passwordController.CheckApp(lockingApp,_prefabListObject.PasswordPanelPrefab, _canvas)){
			var operation = SceneManager.LoadSceneAsync(app.Scene.name,LoadSceneMode.Additive);
		
			operation.completed += _=>
			{
				SceneManager.SetActiveScene(SceneManager.GetSceneByName(app.Scene.name));
			};
		
			_mainScreenObjects.SetActive(false);
		}
		
	}
	
	public void LoadScene(AppEnum app)
	{
		AppConfigurations config = _importer.GetAppConfigs(app);
		var operation = SceneManager.LoadSceneAsync(config.Scene.name,LoadSceneMode.Additive);
		
		operation.completed += _=>
		{
			SceneManager.SetActiveScene(SceneManager.GetSceneByName(config.Scene.name));
		};
		
		_mainScreenObjects.SetActive(false);
	}


	public void BackToMainMenu()
	{
		_mainScreenObjects.SetActive(true);
	}

}


