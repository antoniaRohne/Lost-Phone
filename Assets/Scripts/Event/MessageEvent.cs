using System;
using UnityEngine;

public class MessageEvent : EventModel
{    
    public MessageEvent(DateTime eventTime, TimerModel timerModel) : base(eventTime, timerModel)
    {
    }
    
    protected override void StartEvent()
    {
        Debug.LogFormat("Message Event triggered at {0}", StartTime.Value);
    }

}