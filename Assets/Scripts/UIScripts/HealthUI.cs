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

        //a local variable that gets the player
        GameObject p = GameObject.FindGameObjectWithTag("Player");

        //if the player is in the scene get the PlayerHealth component on the player
        if (p != null)
            player = p.GetComponent<PlayerHealth>();

        //initialise text with players health
        text.text = "Health: " + player.GetHealth;
	}

    void OnEnable()
    {
        //call UpdateText whenever the players health is changed 
        PlayerHealth.OnHealthUpdated += UpdateText;
        HealthPowerup.OnHealthUpdated += UpdateText;
    }

    void UpdateText()
    {
        text.text = "Health: " + player.GetHealth;
    }

    void OnDisable()
    {
        PlayerHealth.OnHealthUpdated -= UpdateText;
        HealthPowerup.OnHealthUpdated -= UpdateText;
    }

}