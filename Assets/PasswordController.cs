
using App;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class PasswordController : MonoBehaviour
{

	[SerializeField] private Text _inputtext;
	[SerializeField] private Image _indicator;

	IReadOnlyReactiveProperty<string> password { get; set; }
	AppConfigurations App;

	public void SetApp(AppConfigurations app)
	{
		App = app;
		password = _inputtext.ObserveEveryValueChanged(text => text.text).ToReactiveProperty();
		password.Where(x => x.Equals(App.Password)).Subscribe(x => UnlockSuccessfully()).AddTo(this);		
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