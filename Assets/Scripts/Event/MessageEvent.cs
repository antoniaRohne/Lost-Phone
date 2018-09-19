using System;
using App;
using UnityEngine;

public class MessageEvent : EventModel
{    
    public MessageEvent(DateTime eventTime, TimerModel timerModel, GameObject pushnote, AppConfigurations app) : base(eventTime, timerModel, pushnote, app)
    {
    }
}