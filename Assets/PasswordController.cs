
using System.Collections;
using App;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class PasswordController : MonoBehaviour
{

	[SerializeField] private Text _inputtext;
	[SerializeField] private Image _indicator;
	[SerializeField] private Image _unlockStateImage;
	
	[SerializeField] private Sprite _unlockStateSprite;

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
		_unlockStateImage.sprite = _unlockStateSprite;
		StartCoroutine(LoadNewScene());
		
	}

	IEnumerator LoadNewScene()
	{
		yield return new WaitForSeconds(3);
		AppController.Instance.LoadScene(App);
		Destroy(this.gameObject);
	}
}