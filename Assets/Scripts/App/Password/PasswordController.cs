
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
	public bool CheckApp(IAppLockingSystem app, GameObject prefab)
	{
		if (app.LockingState)
		{
			StartUnlockingProcess(app, prefab);
			return true;
		}
			return false;
		
	}

	private void StartUnlockingProcess(IAppLockingSystem app, GameObject prefab)
	{
		var lockingPanel = GameObject.Instantiate(prefab, GameObject.Find("Canvas").transform); //CANVAS STUFF
		view = lockingPanel.GetComponent<PasswordPanelView>();
		view.CreatePasswordPanel(app);
		//view.password.Where(x => x.Equals(app.Password)).Subscribe(x => UnlockSuccessfully()).AddTo(this);
		lockingPanel.GetComponent<PasswordPanelView>().password.Where(x => x.Equals(app.Password)).Subscribe(x => UnlockSuccessfully(app));
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