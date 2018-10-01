using System;
using App;
using UnityEngine;
using UniRx;
using Object = UnityEngine.Object;

public class EventModel
{
    private ReactiveProperty<DateTime> StartTime  { get; set; }
    private readonly GameObject _pushnote; //Pushnotification object -> unten kein get component 
    private AppConfigurations _app;

    public EventModel(DateTime eventTime, TimerModel timerModel, GameObject pushnote, AppConfigurations app)
    {
        StartTime = new ReactiveProperty<DateTime>(eventTime);
        _pushnote = pushnote;
        _app = app;
        SubscribeToTimer(timerModel);
    } 

    private void SubscribeToTimer(TimerModel timerModel)
    {
        //Where, Combine latest, Take (automatisch disposed)
        timerModel.Time.Where(x => x==StartTime.Value).Take(1).Subscribe(_ => StartEvent());
        
    }

    private void StartEvent()
    {
        //Debug.Log("An event triggered.");
        var pushnote =  Object.Instantiate(_pushnote, GameObject.Find("Canvas").transform); // static bzw. durchgeben
        pushnote.GetComponent<PushNotificationConfig>().Icon = _app.Icon;
        pushnote.GetComponent<PushNotificationConfig>().Title = _app.Name.ToString();
        pushnote.GetComponent<PushNotificationConfig>().Content = _app.PushNoteContent;
        Object.Destroy(pushnote, pushnote.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);  //Zeitpunkt destroy in Pushnotificationconfig
    }
}
