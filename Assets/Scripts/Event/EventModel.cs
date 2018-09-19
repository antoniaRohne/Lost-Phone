using System;
using App;
using UnityEngine;
using UniRx;
using Object = UnityEngine.Object;

public abstract class EventModel
{
    protected ReactiveProperty<DateTime> StartTime  { get; private set; }
    private readonly GameObject _pushnote;
    private AppConfigurations _app;
   
    protected EventModel(DateTime eventTime, TimerModel timerModel, GameObject pushnote, AppConfigurations app)
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

    protected virtual void StartEvent()
    {
        Debug.Log("A event triggered.");
        var pushnote =  Object.Instantiate(_pushnote, GameObject.Find("Canvas").transform);
        pushnote.GetComponent<PushNotificationConfig>().Icon = _app.Icon;
        pushnote.GetComponent<PushNotificationConfig>().Title = _app.App.ToString();
        pushnote.GetComponent<PushNotificationConfig>().Content = _app.PushNoteContent;
        Object.Destroy(pushnote, pushnote.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length); 
    }
}
