using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrophyCount : MonoBehaviour {

    //the amount of medals/trophies that the player has
    public static int trophyCount = 0;
    
    //the text that indicates the number of medals/trophies the player has
    [SerializeField]
    private Text trophyCountText;

    void Awake()
    {
        //get the players saved trophyCount before anything else in the game starts
        trophyCount = PlayerPrefs.GetInt("trophyCount");
    }

    void Start()
    {
        //update the text after the trophyCount
        trophyCountText.text = "x" + trophyCount;
    }

    void OnEnable()
    {
        OptionsMenu.OnUpdateTrophyText += UpdateText;
    }

    void UpdateText()
    {
        //this method is called when progress is cleared in the options menu
        trophyCountText.text = "x" + trophyCount;
    }

    void OnDisable()
    {
        OptionsMenu.OnUpdateTrophyText -= UpdateText;
    }

}