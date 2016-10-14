using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {

    //an enum defining all the different levels
    public enum LEVEL
    {
        SUNNY,
        MISTY,
        SPACE,
        DESERT,
        DAWN,
        MOUNTAINS,
        GHOSTS
    };

    //a variable of type LEVEL initialised as the first level
    private LEVEL level = LEVEL.SUNNY;

    //the text that changes to indicate the selected level
    private Text selectedLevel;

    //the button that starts the game when pressed
    [SerializeField]
    private Button button;

    //text that says the amount of medals required to unlock a stage and text that says whether or not it's locked
    [SerializeField]
    private Text medalAmountText, lockedText;

    //variables that define the amount of medals required to unlock various stages
    [SerializeField]
    private float medalsForDesert, medalsForDawn, medalsForMountains, medalsForGhosts;

    //variable used to load levels according to their build index
    private int levelIndex;

    //variable for the object that loads the levels/scenes
    private LevelLoad levelLoader;

    void Start()
    {
        //initially level index is set to the first level
        levelIndex = 1;

        //gets the Levelload object in the scene which is a singleton
        levelLoader = FindObjectOfType<LevelLoad>();

        //text that indicates whether or not something is locked is set to nothing
        lockedText.text = "";

        //adds an action to the button that allows it to load the scene defined by levelIndex
        button.onClick.AddListener(() => levelLoader.LoadMethod(levelIndex));
    }

    //method for when the left button has been pressed
    public void ChangeToLeftLevel()
    {
        selectedLevel = GetComponent<Text>();

        switch (level)
        {
            //if the "misty" level is currently selected...
            case LEVEL.MISTY:

                //...change the level index to the one below...
                levelIndex = 1;

                //...change the text to the name of the first level "Sunny"...
                selectedLevel.text = "Sunny";
                //...change the colour to yellow... 
                selectedLevel.color = Color.yellow;

                //...change the text that says "locked" to nothing...
                lockedText.text = "";

                //...change the text that represents the amount of medals required to unlock the stage to 0...
                medalAmountText.text = "x0";

                //...and finally, change the level to "Sunny" aka the first level
                level = LEVEL.SUNNY;

                break;
            case LEVEL.SPACE:

                levelIndex = 2;

                selectedLevel.text = "Misty";
                selectedLevel.color = Color.grey;

                lockedText.text = "";

                medalAmountText.text = "x0";

                level = LEVEL.MISTY;

                break;
            case LEVEL.DESERT:

                levelIndex = 3;

                selectedLevel.text = "Space";
                selectedLevel.color = Color.magenta;

                lockedText.text = "";

                medalAmountText.text = "x0";

                level = LEVEL.SPACE;

                break;
            case LEVEL.DAWN:

                //the text says locked to indicate that the player hasn't unlocked the stage
                lockedText.text = "Locked";

                //if the player has the required amount of trophies to unlock the stage then change the level index to the selected stage,
                //and remove the text that says "locked"
                if (TrophyCount.trophyCount >= medalsForDesert)
                {
                    levelIndex = 4;
                    lockedText.text = "";
                }

                selectedLevel.text = "Desert";
                selectedLevel.color = new Color(1.0f, 0.85f, 0.7f);

                //the text is changed to say the amount of medals required to unlock the stage
                medalAmountText.text = "x" + medalsForDesert;

                level = LEVEL.DESERT;

                break;
            case LEVEL.MOUNTAINS:

                lockedText.text = "Locked";

                if (TrophyCount.trophyCount >= medalsForDawn)
                {
                    levelIndex = 5;
                    lockedText.text = "";
                }

                selectedLevel.text = "Dawn";
                selectedLevel.color = new Color(0.7f, 0.2f, 0.2f);

                medalAmountText.text = "x" + medalsForDawn;

                level = LEVEL.DAWN;

                break;
            case LEVEL.GHOSTS:

                lockedText.text = "Locked";

                if (TrophyCount.trophyCount >= medalsForMountains)
                {
                    levelIndex = 6;
                    lockedText.text = "";
                }

                selectedLevel.text = "Mountains";
                selectedLevel.color = Color.cyan;

                medalAmountText.text = "x" + medalsForMountains;

                level = LEVEL.MOUNTAINS;

                break;
        }

        //removes any actions/listeners that are on the button
        button.onClick.RemoveAllListeners();
        //adds an action to the button that loads the scene defined by the levelIndex
        button.onClick.AddListener(() => levelLoader.LoadMethod(levelIndex));
    }

    //same as the method above, except it changes the level to the one on the right
    public void ChangeToRightLevel()
    {
        selectedLevel = GetComponent<Text>();

        switch (level)
        {
            case LEVEL.SUNNY:

                levelIndex = 2;

                selectedLevel.text = "Misty";
                selectedLevel.color = Color.grey;

                lockedText.text = "";

                medalAmountText.text = "x0";

                level = LEVEL.MISTY;

                break;
            case LEVEL.MISTY:

                levelIndex = 3;

                selectedLevel.text = "Space";
                selectedLevel.color = Color.magenta;

                lockedText.text = "";

                medalAmountText.text = "x0";

                level = LEVEL.SPACE;

                break;
            case LEVEL.SPACE:

                selectedLevel.text = "Desert";
                selectedLevel.color = new Color(1.0f, 0.85f, 0.7f);

                lockedText.text = "Locked";

                if (TrophyCount.trophyCount >= medalsForDesert)
                {
                    levelIndex = 4;
                    lockedText.text = "";
                }

                medalAmountText.text = "x" + medalsForDesert;

                level = LEVEL.DESERT;

                break;
            case LEVEL.DESERT:

                selectedLevel.text = "Dawn";
                selectedLevel.color = new Color(0.7f, 0.2f, 0.2f);

                lockedText.text = "Locked";

                if (TrophyCount.trophyCount >= medalsForDawn)
                {
                    levelIndex = 5;
                    lockedText.text = "";
                }

                medalAmountText.text = "x" + medalsForDawn;

                level = LEVEL.DAWN;

                break;
            case LEVEL.DAWN:

                selectedLevel.text = "Mountains";
                selectedLevel.color = Color.cyan;

                lockedText.text = "Locked";

                if (TrophyCount.trophyCount >= medalsForMountains)
                {
                    levelIndex = 6;
                    lockedText.text = "";
                }

                medalAmountText.text = "x" + medalsForMountains;

                level = LEVEL.MOUNTAINS;

                break;
            case LEVEL.MOUNTAINS:

                selectedLevel.text = "Ghosts";
                selectedLevel.color = Color.white;

                lockedText.text = "Locked";

                if (TrophyCount.trophyCount >= medalsForGhosts)
                {
                    levelIndex = 7;
                    lockedText.text = "";
                }

                medalAmountText.text = "x" + medalsForGhosts;

                level = LEVEL.GHOSTS;

                break;
        }

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => levelLoader.LoadMethod(levelIndex));
    }

}