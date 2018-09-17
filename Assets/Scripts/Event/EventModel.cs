using System;
using UnityEngine;
using UniRx;

public abstract class EventModel
{
    //private geht nicht weil dann sonst Events nicht darauf zugreifen können?!
    //Properties; fields nie public
    
    //public readonly int _hour;
    //public readonly int _minute;

    protected ReactiveProperty<DateTime> StartTime  { get; private set; }

    protected EventModel(DateTime eventTime, TimerModel timerModel)
    {
        StartTime = new ReactiveProperty<DateTime>(eventTime);
        SubscribeToTimer(timerModel);
    } 

    private void SubscribeToTimer(TimerModel timerModel)
    {
        //Where, Combine latest, Take (automatisch disposed)
        timerModel.Time.Where(x => x==StartTime.Value).Take(1).Subscribe(_ => StartEvent());
        
    }

    protected virtual void StartEvent()
    {
        Debug.Log("A event triggered.");
    }
}
