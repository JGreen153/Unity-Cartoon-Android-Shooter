using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

    private PlayerHealth player;

    private Text text;

    // Use this for initialization
	void Start() 
	{
        text = GetComponent<Text>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

        text.text = "Health: " + player.GetHealth;
	}

    void OnEnable()
    {
        PlayerHealth.OnHealthUpdated += UpdateText;
        HealthPowerup.OnHealthUpdated += UpdateText;
    }

    void UpdateText()
    {
        if (player.GetHealth < 100 && player.GetHealth > 0)
            text.text = "Health: " + player.GetHealth;
    }

    void OnDisable()
    {
        PlayerHealth.OnHealthUpdated -= UpdateText;
        HealthPowerup.OnHealthUpdated -= UpdateText;
    }

}