
using System.Collections;
using System.Runtime.Remoting.Messaging;
using System.Text;
using App;
using UniRx;
using UniRx.Triggers;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PasswordController
{
	private PasswordPanelView view;
	public bool CheckApp(IAppLockingSystem app, GameObject prefab, GameObject parent)
	{
		if (app.LockingState)
		{
			StartUnlockingProcess(app, prefab, parent);
			return true;
		}
			return false;
		
	}

	private void StartUnlockingProcess(IAppLockingSystem app, GameObject prefab, GameObject parent)
	{
		var lockingPanel = GameObject.Instantiate(prefab, parent.transform); 
		view = lockingPanel.GetComponent<PasswordPanelView>();
		view.CreatePasswordPanel(app);
		//view.password.Where(x => x.Equals(app.Password)).Subscribe(x => UnlockSuccessfully()).AddTo(this);
		view.password.Where(x => x.Equals(app.Password)).Subscribe(x => UnlockSuccessfully(app));
	}

	private void UnlockSuccessfully(IAppLockingSystem app)
	{
		Debug.Log("unlocked");
		app.LockingState = false;
		view.Unlock();
		MainThreadDispatcher.StartCoroutine(LoadNewScene(app));
		
	}

	IEnumerator LoadNewScene(IAppLockingSystem app)
	{
		yield return new WaitForSeconds(3);
		view.Destroy();
		AppController.Instance.LoadScene(app.Name);
	}
}