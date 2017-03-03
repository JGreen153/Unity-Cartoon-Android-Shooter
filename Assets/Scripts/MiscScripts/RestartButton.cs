using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

    private Button button;

    // Use this for initialization
    void Start()
    {
        button = GetComponent<Button>();
        //adds an action to the button that reloads the current scene
        button.onClick.AddListener(() => LevelLoad.instance.LoadMethod(SceneManager.GetActiveScene().buildIndex));
    }
}