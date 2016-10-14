using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour {

    //text that displays the timer
    private Text text;

    // Use this for initialization
	void Start() 
	{
        text = GetComponent<Text>();
	}

    void OnEnable()
    {
        //call UpdateText whenever the event is called
        TimeSurvived.OnTimeUpdated += UpdateText;
    }

	void UpdateText()
	{
        //update the timer ui
        text.text = "Time: " + TimeSurvived.time;
	}

    void OnDisable()
    {
        TimeSurvived.OnTimeUpdated -= UpdateText;
    }
}