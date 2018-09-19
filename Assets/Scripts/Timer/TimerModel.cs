using System;
using System.Collections;
using UniRx;
using UnityEngine;

public class TimerModel
{
	public ReactiveProperty<DateTime> Time { get; private set; }
	
	private readonly WaitForSeconds _oneMinute = new WaitForSeconds(15);

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
			yield return _oneMinute;
			Time.Value = Time.Value.AddMinutes(1);
		}
	
	}
	
}
