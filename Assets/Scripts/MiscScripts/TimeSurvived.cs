using UnityEngine;
using System;
using System.Collections;

public class TimeSurvived : MonoBehaviour {

    //delegate/event to notify the ui on when to update the text showing the timer
    public delegate void TimeUpdate();
    public static event TimeUpdate OnTimeUpdated;

    //the timer that will be incremented every second
    public static float time;

    //variable to help get the correct timer
    private float seconds;

    //determines whether or the timer should or shouldn't stop
    private bool shouldStop;

    // Use this for initialization
	void Start() 
	{
        time = 0;
        seconds = 0;

        shouldStop = false;
	}

    void OnEnable()
    {
        //events that let the timer know when to stop counting/updating
        PlayerHealth.OnTimeStopped += StopTime;
        FinishManager.OnGameFinished += StopTime;
    }

	// Update is called once per frame
	void Update()
	{
        //if the timer shouldn't stop...
        if (!shouldStop)
        {
            //...increment the seconds variable using deltaTime to get seconds...
            seconds += Time.deltaTime;
            //...then round seconds off so that it becomes an integer
            time = Mathf.Round(seconds);

            //call the delegate/event
            if (OnTimeUpdated != null)
                OnTimeUpdated();
        }
	}

    void OnDisable()
    {
        PlayerHealth.OnTimeStopped -= StopTime;
        FinishManager.OnGameFinished -= StopTime;
    }

    void StopTime()
    {
        shouldStop = true;
    }
}