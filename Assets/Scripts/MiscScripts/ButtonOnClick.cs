using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonOnClick : MonoBehaviour {

    //the level that i want to load
    [SerializeField]
    private int level;

    //amount of medals required to start the stage
    [SerializeField]
    private int medalsRequiredForStage;

    private Button button;

    // Use this for initialization
    void Start()
    {
        button = GetComponent<Button>();

        //if the player has the amount of medals required for the stage then load the scene specified by level (the int variable)
        //if they don't have the required amount then send them back to the main menu
        if (TrophyCount.trophyCount >= medalsRequiredForStage)
            button.onClick.AddListener(() => LevelLoad.instance.LoadMethod(level));
        else
            button.onClick.AddListener(() => LevelLoad.instance.LoadMethod(0));
    }
}