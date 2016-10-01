using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {

    private Text text;

    void Start()
    {
        text = GetComponent<Text>();

        text.text = "Score: " + PlayerScore.score;
    }

    void OnEnable()
    {
        EnemyHealth.OnUpdateScore += UpdateText;
        ScorePowerup.OnUpdateScore += UpdateText;
    }

	void UpdateText()
	{
        text.text = "Score: " + PlayerScore.score;
	}

    void OnDisable()
    {
        EnemyHealth.OnUpdateScore -= UpdateText;
        ScorePowerup.OnUpdateScore -= UpdateText;
    }
}