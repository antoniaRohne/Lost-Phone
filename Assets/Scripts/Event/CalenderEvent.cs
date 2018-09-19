using System;
using App;
using UnityEngine;

public class CalenderEvent : EventModel
{   
    public CalenderEvent(DateTime eventTime, TimerModel timerModel, GameObject pushnote, AppConfigurations app) : base(eventTime, timerModel, pushnote, app)
    {
    }
}