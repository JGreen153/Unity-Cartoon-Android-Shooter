using UnityEngine;
using System;
using System.Collections;

public class TimeSurvived : MonoBehaviour {

    public delegate void TimeUpdate();
    public static event TimeUpdate OnTimeUpdated;

    public static float time;

    private float seconds;

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
        PlayerHealth.OnTimeStopped += StopTime;
        FinishManager.OnGameFinished += StopTime;
    }

	// Update is called once per frame
	void Update()
	{
        if (!shouldStop)
        {
            seconds += Time.deltaTime;
            time = Mathf.Round(seconds);

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