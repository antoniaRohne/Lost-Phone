using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class TimerView: MonoBehaviour
{

	[SerializeField] private Text _timeText;

	private void Start()
	{
		AppController.Instance.Timer.Time.Subscribe(x => _timeText.text = x.ToShortTimeString()).AddTo(this);
	}
}
