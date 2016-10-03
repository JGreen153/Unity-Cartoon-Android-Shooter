using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrophyCount : MonoBehaviour {

    public static int trophyCount = 0;

    [SerializeField]
    private Text trophyCountText;

    void Start()
    {
        trophyCountText.text = "x" + trophyCount;
    }

}