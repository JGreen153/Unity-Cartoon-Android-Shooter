using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {

    //text to display the score
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();

        //initially set the text equal to the players current score
        text.text = "Score: " + PlayerScore.score;
    }

    void OnEnable()
    {
        //call update text whenever these events are called
        EnemyHealth.OnUpdateScore += UpdateText;
        ScorePowerup.OnUpdateScore += UpdateText;
    }

	void UpdateText()
	{
        //update the score
        text.text = "Score: " + PlayerScore.score;
	}

    void OnDisable()
    {
        EnemyHealth.OnUpdateScore -= UpdateText;
        ScorePowerup.OnUpdateScore -= UpdateText;
    }
}