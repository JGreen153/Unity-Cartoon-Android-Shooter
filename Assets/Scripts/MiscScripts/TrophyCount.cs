using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrophyCount : MonoBehaviour {

    public static int trophyCount = 0;

    [SerializeField]
    private Text trophyCountText;

    void Awake()
    {
        trophyCount = PlayerPrefs.GetInt("trophyCount");
    }

    void Start()
    {
        trophyCountText.text = "x" + trophyCount;
    }

    void OnEnable()
    {
        OptionsMenu.OnUpdateTrophyText += UpdateText;
    }

    void UpdateText()
    {
        trophyCountText.text = "x" + trophyCount;
    }

    void OnDisable()
    {
        OptionsMenu.OnUpdateTrophyText -= UpdateText;
    }

}