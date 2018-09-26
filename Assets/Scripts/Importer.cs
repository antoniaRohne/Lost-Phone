using System.Collections.Generic;
using System.Linq;
using App;
using UnityEditor;
using UnityEngine;

public class Importer
{
	private Dictionary<AppEnum, SceneAsset> _sceneDictionary;
	private Dictionary<AppEnum, Sprite> _iconDictionary;
	private Dictionary<AppEnum, AppConfigurations> _configurationDictionary;

	private readonly AppConfigurations[] _apps;

	public Importer(AppConfigurations[] appList)
	{
		_apps = appList;
		Setup();
	}

	private void Setup()
	{
		_sceneDictionary = _apps.ToDictionary(x => x.App, y => y.Scene);
		_iconDictionary = _apps.ToDictionary(x => x.App, y => y.Icon);
		_configurationDictionary = _apps.ToDictionary(x => x.App, y => y);
	}

	public Sprite GetIcon(AppEnum app)
	{
		return _iconDictionary[app];
	}

	public SceneAsset GetScene(AppEnum app)
	{
		return _sceneDictionary[app];
	}

	public AppConfigurations GetAppConfigs(AppEnum app)
	{
		return _configurationDictionary[app];
	}
}
