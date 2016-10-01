using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour {

    private Text text;

    // Use this for initialization
	void Start() 
	{
        text = GetComponent<Text>();
	}

    void OnEnable()
    {
        TimeSurvived.OnTimeUpdated += UpdateText;
    }

	// Update is called once per frame
	void UpdateText()
	{
        text.text = "" + TimeSurvived.time;
	}

    void OnDisable()
    {
        TimeSurvived.OnTimeUpdated -= UpdateText;
    }
}