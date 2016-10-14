using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountdownManager : MonoBehaviour {

    //the script that updates the time the player has survived
    [SerializeField]
    private TimeSurvived timeSurvived;

    //text that shows the 3,2,1
    private Text countDownText;
    //the countdown itself
    private float countDown;

    // Use this for initialization
	void Start() 
	{
        //disable the time script so the game doesn't start the timer during the countdown
        timeSurvived.enabled = false;

        countDownText = GetComponent<Text>();

        countDownText.text = "";

        countDown = 8;
	}

	// Update is called once per frame
	void Update()
	{
        //start counting down
        countDown -= Time.smoothDeltaTime;

        //display the 3,2,1 depending on the countdown
        if(countDown < 5.0f && countDown >= 3.5f)
        {
            countDownText.text = "3";
        }
        else if(countDown < 3.5f && countDown >= 2.5f)
        {
            countDownText.text = "2";
        }
        else if(countDown < 2.5f && countDown >= 1.5f)
        {
            countDownText.text = "1";
        }
        else if(countDown < 1.5f && countDown >= 0.5f)
        {
            countDownText.text = "GO!";
        }
        else if(countDown < 0.5f)
        {
            countDownText.text = "";
            //starts the timer and then dsiables this gameobject/script
            timeSurvived.enabled = true;
            gameObject.SetActive(false);
        }
	}
}