using System;
using App;
using UnityEngine;
using UniRx;
using Object = UnityEngine.Object;

public class EventModel
{
    private ReactiveProperty<DateTime> StartTime  { get; set; }
    private readonly PushNotificationConfig _pushnote;
    private readonly AppConfigurations _app;

    public EventModel(DateTime eventTime, TimerModel timerModel, PushNotificationConfig pushnote, AppConfigurations app, GameObject parent)
    {
        StartTime = new ReactiveProperty<DateTime>(eventTime);
        _pushnote = pushnote;
        _app = app;
        SubscribeToTimer(timerModel, parent);
    } 

    private void SubscribeToTimer(TimerModel timerModel, GameObject parent)
    {
        //Where, Combine latest, Take (automatisch disposed)
        timerModel.Time.Where(x => x==StartTime.Value).Take(1).Subscribe(_ => StartEvent(parent));
        
    }

    private void StartEvent(GameObject parent)
    {
        //Debug.Log("An event triggered.");
        PushNotificationConfig pushnote =  Object.Instantiate(_pushnote, parent.transform);
        pushnote.Icon = _app.Icon;
        pushnote.Title = _app.Name.ToString();
        pushnote.Content = _app.PushNoteContent;
        Object.Destroy(pushnote, pushnote.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);  //Zeitpunkt destroy in Pushnotificationconfig
    }
}
