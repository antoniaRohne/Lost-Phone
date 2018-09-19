using System;
using App;
using UnityEngine;

public class EventFactory
{
    public EventModel CreateEvent(string eventName, DateTime startEvent, TimerModel timer, GameObject pushnote, AppConfigurations app)
    {
        switch (eventName)
        {
            case "Calendar": return new CalenderEvent(startEvent, timer, pushnote, app);
            case "Messages": return new MessageEvent(startEvent,timer,pushnote, app);
            case "default": return null;
        }

        return null;
    }
        
   
}