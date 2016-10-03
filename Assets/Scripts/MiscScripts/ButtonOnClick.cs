using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonOnClick : MonoBehaviour {

    [SerializeField]
    private int level;

    private LevelLoad levelLoader;
    private Button button;

    // Use this for initialization
    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoad>();
        button = GetComponent<Button>();
        button.onClick.AddListener(() => levelLoader.LoadMethod(level));
    }
}