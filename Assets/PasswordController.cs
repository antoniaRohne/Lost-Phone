
using App;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class PasswordController : MonoBehaviour
{

	[SerializeField] private Text _inputtext;
	[SerializeField] private Image _indicator;

	ReactiveProperty<IObservable<Unit>> password { get; set; }
	AppConfigurations App;

	public void SetApp(AppConfigurations app)
	{
		App = app;
		password = new ReactiveProperty<IObservable<Unit>>(_inputtext.UpdateAsObservable()); //IObservable<string>
		password.Where(x => x.Equals(App.Password)).Subscribe(x => UnlockSuccessfully());
		Debug.Log(App.Password);
	}

	private void UnlockSuccessfully()
	{
		Debug.Log("unlocked");
		App.LockingState = false;
		_indicator.color = Color.green;
		AppController.Instance.LoadScene(App);
	}
}