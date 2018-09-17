using System;
using UnityEngine;

public class CalenderEvent : EventModel
{   
    public CalenderEvent(DateTime eventTime, TimerModel timerModel) : base(eventTime, timerModel)
    {
    }
    
    protected override void StartEvent()
    {
        Debug.LogFormat("Calender Event triggered at {0}", StartTime.Value);
    }
}