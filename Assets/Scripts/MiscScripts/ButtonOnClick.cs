using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonOnClick : MonoBehaviour {

    [SerializeField]
    private int level;

    [SerializeField]
    private int medalsRequiredForStage;

    private LevelLoad levelLoader;
    private Button button;

    // Use this for initialization
    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoad>();
        button = GetComponent<Button>();

        if (TrophyCount.trophyCount >= medalsRequiredForStage)
            button.onClick.AddListener(() => levelLoader.LoadMethod(level));
        else
            button.onClick.AddListener(() => levelLoader.LoadMethod(0));
    }
}