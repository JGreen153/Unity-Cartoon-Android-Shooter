using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {

    public enum LEVEL
    {
        SUNNY,
        MISTY,
        SPACE
    };

    private LEVEL level = LEVEL.SUNNY;

    private Text selectedLevel;

    [SerializeField]
    private Button leftButton, rightButton;

    private int levelIndex;

    private LevelLoad levelLoader;
    private Button button;

    void Start()
    {
        levelIndex = 1;

        levelLoader = FindObjectOfType<LevelLoad>();
        button = GetComponent<Button>();

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

                level = LEVEL.SUNNY;
                break;
            case LEVEL.SPACE:
                levelIndex = 2;

                selectedLevel.text = "Misty";
                selectedLevel.color = Color.grey;

                level = LEVEL.MISTY;
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

                level = LEVEL.MISTY;
                break;
            case LEVEL.MISTY:
                levelIndex = 3;

                selectedLevel.text = "Space";
                selectedLevel.color = Color.magenta;

                level = LEVEL.SPACE;
                break;
        }

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => levelLoader.LoadMethod(levelIndex));
    }

}