using System;
using UnityEngine;
using System.Collections;
using TMPro;
using UniRx;

public class Clock : MonoBehaviour {

	//-- set start time 00:00
    public int minutes = 0;
    public int hour = 0;
    private DateTime _time;
	
    public GameObject pointerMinutes;
    public GameObject pointerHours;

void Start() 
{
    hour=AppController.Instance.Timer.Time.Value.Hour;
    minutes=AppController.Instance.Timer.Time.Value.Minute;

    AppController.Instance.Timer.Time.Subscribe(SetTime);
}

void Update() 
{
    //-- calculate pointer angles
    float rotationMinutes = (360.0f / 60.0f)  * minutes;
    float rotationHours   = ((360.0f / 12.0f) * hour) + ((360.0f / (60.0f * 12.0f)) * minutes);

    //-- draw pointers
    pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
    pointerHours.transform.localEulerAngles   = new Vector3(0.0f, 0.0f, rotationHours);

}

private void SetTime(DateTime time)
{
    hour = time.Hour;
    minutes = time.Minute;
}
}
