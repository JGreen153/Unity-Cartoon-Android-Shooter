using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

    //script that loads the levels
    private LevelLoad levelLoader;
    private Button button;

    // Use this for initialization
    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoad>();
        button = GetComponent<Button>();
        //adds an action to the button that reloads the current scene
        button.onClick.AddListener(() => levelLoader.LoadMethod(SceneManager.GetActiveScene().buildIndex));
    }
}