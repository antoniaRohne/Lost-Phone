using System;
using System.Collections;
using UniRx;
using UnityEngine;

public class TimerModel
{
	//[SerializeField] private int _hours;
	//[SerializeField] private int _minutes;

	//public ReactiveProperty<int> HoursProperty { get; private set; }
	//public ReactiveProperty<int> MinutesProperty { get; private set; }
	public ReactiveProperty<DateTime> Time { get; private set; }
	
	private readonly WaitForSeconds _oneSecond = new WaitForSeconds(15);

	//1min = 15 sekunden
	//1h = 60*15 = 900 sekunden (= 15 min)

	public TimerModel(DateTime startTime)
	{
		Time = new ReactiveProperty<DateTime>(startTime);
		MainThreadDispatcher.StartCoroutine(TimeTick()); //Observable.Intervall
	}
	

	private IEnumerator TimeTick()
	{
		while (true)
		{
			yield return _oneSecond;
			Time.Value = Time.Value.AddMinutes(1);
		}
	
	}
	
}
