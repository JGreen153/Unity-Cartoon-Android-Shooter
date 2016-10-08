using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {

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

    private LEVEL level = LEVEL.SUNNY;

    private Text selectedLevel;

    [SerializeField]
    private Text medalAmountText, lockedText;

    [SerializeField]
    private float medalsForDesert, medalsForDawn, medalsForMountains, medalsForGhosts;

    [SerializeField]
    private Button button;

    private int levelIndex;

    private LevelLoad levelLoader;

    void Start()
    {
        levelIndex = 1;

        levelLoader = FindObjectOfType<LevelLoad>();

        lockedText.text = "";

        button.onClick.AddListener(() => levelLoader.LoadMethod(levelIndex));
    }

    public void ChangeToLeftLevel()
    {
        selectedLevel = GetComponent<Text>();

        switch (level)
        {
            case LEVEL.MISTY:

                levelIndex = 1;

                selectedLevel.text = "Sunny";
                selectedLevel.color = Color.yellow;

                lockedText.text = "";

                medalAmountText.text = "x0";

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

                lockedText.text = "Locked";

                if (TrophyCount.trophyCount >= medalsForDesert)
                {
                    levelIndex = 4;
                    lockedText.text = "";
                }

                selectedLevel.text = "Desert";
                selectedLevel.color = new Color(1.0f, 0.85f, 0.7f);

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

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => levelLoader.LoadMethod(levelIndex));
    }

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