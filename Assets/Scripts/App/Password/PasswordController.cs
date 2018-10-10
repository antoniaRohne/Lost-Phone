
using System;
using App;
using UniRx;
using UnityEngine;
using Object = UnityEngine.Object;

public class PasswordController
{
	private PasswordPanelView _lockingPanel;
	
	public bool CheckApp(IAppLockingSystem app, PasswordPanelView prefab, GameObject parent)
	{
		if (app.LockingState)
		{
			StartUnlockingProcess(app, prefab, parent);
			return true;
		}
			return false;
		
	}

	private void StartUnlockingProcess(IAppLockingSystem app, PasswordPanelView prefab, GameObject parent)
	{
		_lockingPanel = Object.Instantiate(prefab, parent.transform); 
		_lockingPanel.CreatePasswordPanel(app);
		_lockingPanel.Password.Where(x => x.Equals(app.Password)).Subscribe(x => UnlockSuccessfully(app)).AddTo(_lockingPanel);
	}

	private void UnlockSuccessfully(IAppLockingSystem app)
	{
		Debug.Log("unlocked");
		app.LockingState = false;
		_lockingPanel.Unlock();
		Observable.Timer(TimeSpan.FromSeconds(3)).Subscribe(x => LoadNewScene(app));
	}

	private void LoadNewScene(IAppLockingSystem app)
	{
		_lockingPanel.Destroy();
		AppController.Instance.LoadScene(app.Name);
	}
}