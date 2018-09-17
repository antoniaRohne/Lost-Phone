using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.WSA.Persistence;

public class Importer
{
	private Dictionary<AppEnum, SceneAsset> _sceneDictionary;
	private Dictionary<AppEnum, Sprite> _iconDictionary;

	public Importer()
	{
		Setup();
	}

	private void Setup()
	{
		var apps = Resources.LoadAll<AppConfigurations>("Apps");
		_sceneDictionary = apps.ToDictionary(x => x.App, y => y.Scene);
		_iconDictionary = apps.ToDictionary(x => x.App, y => y.Icon);
	}

	public Sprite GetIcon(AppEnum app)
	{
		return _iconDictionary[app];
	}

	public SceneAsset GetScene(AppEnum app)
	{
		return _sceneDictionary[app];
	}

}
