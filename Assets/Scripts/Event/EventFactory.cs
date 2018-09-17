using System;

public class EventFactory
{
    public EventModel CreateEvent(string eventName, DateTime startEvent, TimerModel timer)
    {
        switch (eventName)
        {
            case "Calendar": return new CalenderEvent(startEvent, timer);
            case "Messages": return new MessageEvent(startEvent,timer);
            case "default": return null;
        }

        return null;
    }
        
   
}